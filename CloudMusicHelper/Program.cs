using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;
using System.Threading.Tasks;
using System.Security.Permissions;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

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
            Helper.Run();
            Console.ReadLine();
        }
    }

    class Helper
    {
        public static void Run()
        {
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            DateTime localDate = DateTime.Now;
            var format = new CultureInfo("zh-CN");

            //start
            Console.WriteLine("[*Welcome*] " + localDate.ToString(format) + " : " + "欢迎使用Enhanced CloudMusic喵~");

            

            Debug.Logger("你好喵，欢迎来到Enhanced CloudMusic Debug Log模式w", "Debug Log");
            Debug.Logger("正在准备一些小惊喜喔w！Web服务初始化中...", "Debug Log");
            
            //WebApp Init
            //string webappPath = Path.Combine(appPath, "\\webapp\\public");
            //WebControl.WebAppServerContributed webappInstance = new WebControl.WebAppServerContributed(webappPath, 25108);

            Debug.Logger("本地服务器初始化完成啦，在浏览器中访问 " + "http://localhost:" + /*webappInstance.Port.ToString()*/ "25108" + " 就可以了喵w", "Debug Log");

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
        public static string logfullPath = null;
    }

    class Debug
    {
        public static FileStream fs;
        public static int CallCount = 0;

        public static void NullTracker()
        {

        }

        

        private static void LoggerWrite(string path, string text)
        {
            if(path == null)
            {
                return;
            }
            Thread.Sleep(2000);
            File.WriteAllText(path, text);
        }

        public static void Logger(string text, string type)
        {
            DateTime localDate = DateTime.Now;
            var format = new CultureInfo("zh-CN");
            string output = "[" + type + "] " + localDate.ToString(format) + " : " + text;
            Console.WriteLine(output);
            LoggerWrite(Data.logfullPath, "One");
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
