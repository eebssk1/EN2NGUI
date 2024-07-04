using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EN2NGui
{
    public partial class PeerForm : Form
    {
        private System.Data.DataTable table = new DataTable("Peers");
        private BindingSource source = new BindingSource();
        private bool NeedStop = true;
        private bool exit = false;
        internal bool connected = false;
        internal static PeerForm instance;

        public PeerForm()
        {
            InitializeComponent();
            instance = this;
            if (StringRes.locale == StringRes.LocaleT.ChN)
            {
                Text = "对等方窗口";
            }
        }

        private void PeerForm_Load(object sender, EventArgs e)
        {
            DataColumn[] cls = new DataColumn[] {new DataColumn
            {
                ColumnName = "Nick",
                ReadOnly = true,
                DataType = typeof(string),
            },
            new DataColumn
            {
                ColumnName = "Mode",
                ReadOnly = true,
                DataType = typeof(string),
            },
            new DataColumn
            {
                ColumnName = "IP",
                ReadOnly = true,
                DataType = typeof(string),
            },
            new DataColumn
            {
                ColumnName = "MAC",
                ReadOnly = true,
                DataType = typeof(string),
            },
            new DataColumn
            {
                ColumnName = "Peer",
                ReadOnly = true,
                DataType = typeof(string),
            },
            new DataColumn
            {
                ColumnName = "Seen",
                ReadOnly = true,
                DataType = typeof(string),
            },
            };
            table.PrimaryKey = null;
            table.Columns.AddRange(cls);
            source.DataSource = table;
            Action act = () => { dataGridView1.DataSource = source; };
            dataGridView1.Invoke(act);
            Thread t = new Thread(Do);
            t.IsBackground = true;
            t.Priority = ThreadPriority.BelowNormal;
            t.Start();
        }

        private void PeerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
            else
            {
                exit = true;
            }

        }
        private void Do()
        {
            List<byte[]> pkts = new List<byte[]>();
            UdpClient client = null;
            var sd = Encoding.UTF8.GetBytes("r 233:1:n2n edges");
            var Target = new IPEndPoint(IPAddress.Loopback, 5644);
            while (true)
            {
                if (exit) return;
                if (NeedStop || (!GUI.instance.started || GUI.instance.needStop))
                {
                    if (!Thread.Yield())
                        Thread.Sleep(300);
                    else
                        Thread.Sleep(225);
                    continue;
                }
                try
                {
                    if (!connected)
                    {
                        client = new UdpClient();
                        client.Client.ReceiveTimeout = 850;
                        client.Client.SendTimeout = 850;
                        client.Connect(Target);
                    }
                    connected = true;

                }
                catch (Exception) { connected = false; Thread.Sleep(850); continue; };
                pkts.Clear();
                client.Send(sd, sd.Length);
                Thread.Sleep(125);
                while (true)
                {
                    try
                    {
                        var pkt = client.Receive(ref Target);
                        pkts.Add(pkt);
                        string s = Encoding.UTF8.GetString(pkt);
                        var d = (JObject)JsonConvert.DeserializeObject(s);
                        if (d == null) break;
                        if (d.Value<string>("_type") == "end")
                            break;

                    }
                    catch (Exception) { break; };
                }
                if (pkts.Count == 0) continue;
                foreach (byte[] B in pkts)
                {
                    string s = Encoding.UTF8.GetString(B);
                    var d = (JObject)JsonConvert.DeserializeObject(s);
                    if (d == null) continue;
                    if (d.Value<string>("_type") != "row") continue;
                    DataRow r = table.NewRow();
                    r["Nick"] = d.Value<string>("desc");
                    r["Mode"] = d.Value<string>("mode");
                    r["IP"] = d.Value<string>("ip4addr");
                    r["MAC"] = d.Value<string>("macaddr");
                    r["Peer"] = d.Value<string>("sockaddr");
                    r["Seen"] = DateTimeOffset.FromUnixTimeSeconds(d.Value<int>("last_seen")).ToLocalTime().ToString();
                    if (table.Rows.Count != 0)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            if (((string)dr["Nick"]).Equals(d.Value<string>("desc")))
                            {
                                Action act = () => { table.Rows.Remove(dr); };
                                dataGridView1.Invoke(act);
                                break;
                            }
                        }
                    }
                    Action act1 = () => { table.Rows.Add(r); };
                    dataGridView1.Invoke(act1);
                }
                Thread.Yield();
                Thread.Sleep(2550);
            }

        }

        private void PeerForm_VisibleChanged(object sender, EventArgs e)
        {
            NeedStop = !Visible;
        }
    }
}
