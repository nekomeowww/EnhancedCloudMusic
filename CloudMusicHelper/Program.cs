using System;
using System.Collections.Generic;
using System.Globalization;

/**************************************************************
 *                                                            *
 * Project: Module of EnhancedCloudMuisc - CloudMusicHelper   *
 * Author: Ayaka Neko                                         *
 * Repo: https://github.com/nekomeowww/EnhancedCloudMusic     *
 * License: GNU General Public License v3.0                   *
 *                                                            *
 * Copyright (C) 2017  Ayaka Neko                             *
 *                                                            *
 **************************************************************/

namespace CloudMusicHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            //Helper.DebugInit();
            //remember to de-comment the section below when generating the release

            
            if(args == null)
            {
                Helper.CommandLineHelp();
                return;
            }
            else if(args != null)
            {
                Helper.CommandLineControl(args);
                return;
            }
            
        }
    }

    class Helper
    {
        public static void CommandLineControl(string[] args)
        {
            string mode = null;

            if(args == null)
            {
                CommandLineHelp();
                return;
            }
            else
            {
                try
                {
                    mode = args[0];
                    ParameterControl(args);
                    return;
                }
                catch(Exception)
                {
                    CommandLineHelp();
                    return;
                }
            }
        }

        public static void CommandLineHelp()
        {
            //Create a new list to store the helping content
            List<string> helptext = new List<string>();

            //Add the helping content into the List
            helptext.Add("");
            helptext.Add("help        Display the usage of CMHelper");
            helptext.Add("");
            helptext.Add("debug       Launch the CMHelper with Debug Log mode");
            helptext.Add("");
            helptext.Add("tag         Get the ID3tag infomation or Convert the tag to compatiable with CloudMusic");
            helptext.Add("            Usage: tag [-convert [--type] [--path [path of track]] [--format]] [-get [--path [path of track]] [--format]]");
            helptext.Add("");
            helptext.Add("getLyric    Get the lyric of the song, and return the Track ID that is currently playing or in the last record");
            helptext.Add("clear       Clear all the log files");
            helptext.Add("");

            //display the helptext
            foreach(string line in helptext)
            {
                Console.WriteLine(line);
            }
            return;
        }

        private static void ParameterControl(string[] args)
        {
            string mode = null;
            List<string> param = new List<string>();

            try
            {
                mode = args[0];
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            if(args.Length > 1)
            {
                for (int i = 1; i < args.Length; i++)
                {
                    param.Add(args[i]);
                }
            }

            //param could be null
            Mode(param, mode);
            return;
        }

        private static void Mode(List<string> param, string mode = "help")
        {
            //switch the mode
            switch (mode)
            {
                case "debug":
                    // debug log mode
                    DebugInit();
                    break;
                case "help":
                    // display help
                    CommandLineHelp();
                    break;
                case "clear":
                    Console.WriteLine("这个功能正在建造呢w");
                    break;
                case "localapi":
                    Console.WriteLine("这个功能正在建造呢w");
                    break;
                case "tag":
                    TagConvert.TagConvert.TagCommand(param);
                    break;
                case "getLyric":
                    WebAPIModules.Lyrics.GetLyrics();
                    break;
                //default:
                    //Console.WriteLine("未知命令。");
                    //CommandLineHelp();
                    //break;
            }
            return;
        }

        public static void DebugInit()
        {
            //Init log file
            Controller.FileControl.LoggerCreate();
            //Run the helper
            Run();
            Console.ReadLine();
        }

        private static void Run()
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;

            //start
            Console.WriteLine("[INFO] " + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " : " + "欢迎使用Enhanced CloudMusic喵~");

            Debug.Logger("你好喵，欢迎来到Enhanced CloudMusic Debug Log模式w", "Info");
            Debug.Logger("正在准备一些小惊喜喔w！Web服务初始化中...", "Info");
            
            //WebApp Init
            //string webappPath = Path.Combine(appPath, "\\webapp\\public");
            //WebControl.WebAppServerContributed webappInstance = new WebControl.WebAppServerContributed(webappPath, 25108);

            Debug.Logger("本地服务器初始化完成啦，在浏览器中访问 " + "http://localhost:" + /*webappInstance.Port.ToString()*/ "25108" + " 就可以了喵w", "Info");

            //这段需要更多的研究呢，此项需要要求管理员权限所以呢...需要研究如何提供，比如运行前或者运行后？
            //另外就是可以参考这个 http://www.cnblogs.com/cmdszh/archive/2012/08/16/httplistener.html
            //这篇文章有提到如何在管理员权限下添加localhost访问权限呢w
            //这篇文章提到了如何要求管理员权限 http://www.cnblogs.com/mayswind/p/3355649.html#para1

            //不过除了使用这些方法，也可以尝试从外部调用nodejs
            //这个部分还没有实践过呢，可以试试看

            //另外记得一定一定要模组化了，不能懒下去了
            //这样写下去迟早会出事的喵/
            //不过已经很棒啦w，一天就能弄完这么多，还给了网易云的整个API文档指南呢w
            //以上这段都是neko迷迷糊糊写出来的，请不要在意呢喵>_<

            Controller.DynamicControl.HistoryFileTracker(Controller.FileControl.GetHistory());
            do
            {
                Controller.HistoryControl.History();
            }
            while (false);

            Debug.Logger("当前歌曲ID:" + Data.track.id);

            //webappInstance.Stop(); //停止服务器
        }
    }

    class Modules
    {
        public static string DataRefreshMessages()
        {
            List<string> textList = new List<string>();

            textList.Add("数据已经刷新啦，正在解析呢喵..."); //0
            textList.Add("切歌了喵？解析新的数据中~"); //1
            textList.Add("网易云音乐小姐姐说正在播放新的东西呢，稍等moeBot酱写出来~"); //2
            textList.Add("这个是什么音乐呀？查查看w"); //3
            textList.Add("喵~知道在放另一首音乐啦，正在学习这个字怎么写呢>_<"); //4
            textList.Add("诶，这个是什么？新的音乐吗？"); //5
            textList.Add("喵喵。正在解析数据呢~"); //6
            textList.Add("主人不要着急喔，moeBot酱正在处理这首曲子的信息啦~"); //6
            textList.Add("据说...neko超喜欢听音乐，主人要去看看嘛？诶...切歌了...moeBot酱知道了呢"); //7
            textList.Add("乌拉！正在和电脑内存大战！她刚刚不想写入数据呢......诶诶，好啦！"); //8

            Random rnd = new Random();
            string TextOut = textList[rnd.Next(0, 8)];
            return TextOut;
        }
    }

    class Data
    {
        public static string logfullPath { get; set; }
        public static List<string> loglist { get; set; }

        public static Track track = new Track();
    }

    class Debug
    {
        public static int CallCount = 0;

        public static void NullTracker()
        {

        }

        public static void Logger(string text, string type = "Info", bool tolog = true)
        {
            string output = LoggerPrefix(type) + text;
            Console.WriteLine(output);
            if(tolog == true)
            {
                Controller.FileControl.LoggerWrite(Data.logfullPath, output);
            }
        }

        private static string LoggerPrefix(string key)
        {
            DateTime localDate = DateTime.Now;
            var formatCountry = new CultureInfo("zh-CN");
            string format = "yyyy/MM/dd HH:mm:ss";
            string output;

            Dictionary<string, string> TypeofLog = new Dictionary<string, string>();
            
            TypeofLog.Add("Trace",   "[TRACE]");
            TypeofLog.Add("Info",    "[INFO]");
            TypeofLog.Add("Debug",   "[DEBUG]");
            TypeofLog.Add("Warning", "[WARNING]");
            TypeofLog.Add("Error",   "[ERROR]");
            TypeofLog.Add("Fatal",   "[FATAL]");

            string value = TypeofLog[key];

            output = value + " " + localDate.ToString(format) + " : ";

            return output;
        }

        public static int methodCallCount()
        {
            CallCount++;
            int i= 0;
            i++;

            return i;
        }
    }
}
