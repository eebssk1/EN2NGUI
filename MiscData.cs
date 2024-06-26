using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.NetworkInformation;

namespace EN2NGui
{
    internal static class MiscData
    {
        public static readonly string PWD = AppDomain.CurrentDomain.BaseDirectory;
        public static bool isAdmin = true;
        public static bool haveTAP = true;
        public static bool haveExe = true;
        public static readonly Random random = new Random(Guid.NewGuid().GetHashCode());
        public static readonly Bitmap spl;
        public static Settings settings = null;
        public static bool isSplashExitAbornomal = false;
        public static SortedDictionary<string, string> TAPs = new SortedDictionary<string, string>();
        public static NetworkInterface currentTAP = null;
        public static bool isN2NmatchHash = true;
        public static string inbuiltN2NHash = null;

        static MiscData()
        {
            spl = (Bitmap)Properties.Resources.ResourceManager.GetObject("sp" + random.Next(0, 3));
        }
    }
}
