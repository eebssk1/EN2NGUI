using System;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace EN2NGui
{
    internal static class StringRes
    {

        internal enum LocaleT
        {
            ChN,
            Oth
        }

        internal enum StringT
        {
            Init,
            FileCheck,
            NoFile,
            WrongArch,
            Exit,
            Hello,
            ChkAdmin,
            NoAdmin,
            Error,
            FileDestr,
            FirsErr,
            TAPCfl,
            NoTAP,
            ExtExe,
            ContE,
            NoConf,
            LoadConf,
            Enable,
            Launch,
            Stop,
            WhyExit,
            CantFW,
            ConfrExit,
            ITDiscla,
            ITDone,
            NEnotMatch,
        }

        internal static LocaleT locale;

        static SortedDictionary<StringT, string> lower0 = new SortedDictionary<StringT, string>();
        static SortedDictionary<StringT, string> lower1 = new SortedDictionary<StringT, string>();
        static HybridDictionary upper = new HybridDictionary();

        public static readonly string exe = @"n2n-edge.exe";
        public static readonly string conf = @"n2n-config.json";

        static StringRes()
        {
            var loc = System.Globalization.CultureInfo.CurrentUICulture.Name;
            locale = loc == "zh-CN" ? LocaleT.ChN : LocaleT.Oth;

            upper[LocaleT.ChN] = lower0;
            upper[LocaleT.Oth] = lower1;

            InitString();
        }
        internal static string GetString(StringT t)
        {
            return ((SortedDictionary<StringT, string>)upper[locale])[t];
        }
        private static void InitString()
        {
            lower0[StringT.Init] = "正在初始化。。。";
            lower1[StringT.Init] = "Initiating...";
            lower0[StringT.FileCheck] = "检查N2N可执行文件是否存在。。。";
            lower1[StringT.FileCheck] = "Checking N2N executable availbility...";
            lower0[StringT.NoFile] = exe + " 没有被找到 !!";
            lower1[StringT.NoFile] = exe + " Not Found !!";
            lower0[StringT.WrongArch] = exe + " 可执行架构不匹配 !!";
            lower1[StringT.WrongArch] = exe + " Architecture not match !!";
            lower0[StringT.Exit] = "退出";
            lower1[StringT.Exit] = "Exit";
            lower0[StringT.Hello] = "你吼哇~";
            lower1[StringT.Hello] = "Hiya~";
            lower0[StringT.ChkAdmin] = "检查管理员权限。。。";
            lower1[StringT.ChkAdmin] = "Checking Admin priviledge...";
            lower0[StringT.NoAdmin] = "未以管理员模式运行 !!";
            lower1[StringT.NoAdmin] = "No admin priviledge !";
            lower0[StringT.Error] = "出现了某些错误 ?!";
            lower1[StringT.Error] = "Errors occured ?!";
            lower0[StringT.FileDestr] = exe + " 文件损坏 ??";
            lower1[StringT.FileDestr] = exe + " is broken ??";
            lower0[StringT.FirsErr] = "第一个错误: ";
            lower1[StringT.FirsErr] = "First Error: ";
            lower0[StringT.TAPCfl] = "至少有一个TAP接口已被连接，这非常可能会导致冲突！";
            lower1[StringT.TAPCfl] = "At least one TAP interface is already connected. This may very likely cause conflicts !";
            lower0[StringT.NoTAP] = "没有发现任何TAP接口！ 你需要安装一个TAP虚拟网卡才能正常工作。";
            lower1[StringT.NoTAP] = "No TAP interface avaiable! You need to install a TAP virtual NIC to work.";
            lower0[StringT.ExtExe] = "没有找到现存的N2N可执行文件，你想释放内嵌的版本吗？";
            lower1[StringT.ExtExe] = "No N2N executable found, Do you want to extract the internal one?";
            lower0[StringT.ContE] = "继续?";
            lower1[StringT.ContE] = "Continue?";
            lower0[StringT.NoConf] = "没有找到当前配置，将载入配置模板 :)";
            lower1[StringT.NoConf] = "No Configuration is found. Will load a template config :)";
            lower0[StringT.LoadConf] = "正在加载配置。。。";
            lower1[StringT.LoadConf] = "Loading Settings...";
            lower0[StringT.Enable] = "启用";
            lower1[StringT.Enable] = "Enable";
            lower0[StringT.Launch] = "启动!";
            lower1[StringT.Launch] = "Launch!";
            lower0[StringT.Stop] = "停止?";
            lower1[StringT.Stop] = "Stop?";
            lower0[StringT.WhyExit] = "N2N子进程异常退出!";
            lower1[StringT.WhyExit] = "N2N Subprocess terminated Unexpectedly!";
            lower0[StringT.CantFW] = "无法添加防火墙，请以管理员模式启动或者手动添加！";
            lower1[StringT.CantFW] = "Can not add to firewall! Pls run as Admin or manually add !";
            lower0[StringT.ConfrExit] = "正在运行，你确定要退出嘛？ N2N将会停止哦~";
            lower1[StringT.ConfrExit] = "Still running. Are you sure to exit? N2N will stop!";
            lower0[StringT.ITDiscla] = "你确定要安装EBK TAP虚拟网卡吗？" + Environment.NewLine + "这将会使该计算机信任EBK的不安全数字证书!";
            lower1[StringT.ITDiscla] = "Are you sure you want to install EBK's TAP Interface?" + Environment.NewLine +
                "This will make your computer trust EBK's unsecure Digital Signature!";
            lower0[StringT.ITDone] = "安装完成。请重新启动程序。";
            lower1[StringT.ITDone] = "Install Done. Pls restarted the program.";
            lower0[StringT.NEnotMatch] = "n2n可执行文件与内嵌版本哈希不匹配！你可能正在使用旧(新？)版或自定义n2n文件！" + Environment.NewLine + "你可以打开工作文件夹删除n2n文件后重新打开程序以重新释放。";
            lower1[StringT.NEnotMatch] = "N2N exe Hash does not match with the inbuilt one! You are probably using a old(new?) or custom one!" + Environment.NewLine + "You can open the working directory to delete the n2n file. Then restart the application to release file again.";
        }
    }
}
