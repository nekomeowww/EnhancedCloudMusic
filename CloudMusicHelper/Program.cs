using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            string result = FileControl.GetHistory();
            if(result == null)
            {
                Console.WriteLine("File cant be found, check your directory.");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("文件的绝对路径是在：" + result);
                Console.ReadLine();
                return;
            }
        }
    }

    class CloudMusic
    {

    }

    class Helper
    {
        
    }

    class History
    {

    }

    class HistoryControl
    {
        public static void History()
        {
            Read();
        }

        private static string Read()
        {
            string historytext = null;
            string path = FileControl.GetHistory();

            //Read the file into historytext
            try
            {
                historytext = System.IO.File.ReadAllText(path);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //Read and send data to processor
            JsonControl.Parser(historytext);

            return historytext;
        }
    }

    class FileControl
    {
        public static string GetHistory() //GetHistory方法，获得history文件
        {
            string history = LoadFile("\\webdata\\file", "history"); //在确认网易云本地API前请勿更改此行

            if (history == null)
            {
                Console.WriteLine("Exception: FileNotFound, 文件未找到，检查是否正确运行过网易云音乐w");
                return null;
            }
            else
            {
                Console.WriteLine("历史记录文件已找到，正在传回数据...");
                return history;
            }
        }

        private static string LoadFile(string subPath, string file)
        {
            var pathWithEnv = @"%USERPROFILE%\AppData\Local\Netease\CloudMusic"; //设置环境量
            string pathEnv = Environment.ExpandEnvironmentVariables(pathWithEnv); //转化环境量
            string pathSource = pathEnv + subPath; //将要寻找的子目录和网易云音乐本地文件API目录合并
            string[] filelist = Directory.GetFiles(pathSource); //保存所有的文件绝对地址到filelist
            string filepath = pathSource + "\\" + file; //将判定值设定为 目录+文件名
            int count = 0;

            try
            {
                foreach (string filename in filelist)
                {
                    //Print all files - Debug Only
                    //Console.WriteLine("正在搜索...");

                    //发行版本中请注释以下Console.WriteLine()
                    //Console.WriteLine(filename);
                    count++;
                    //Console.WriteLine(count);

                    if (filelist.Length == 0)
                    {
                        Console.WriteLine("出现了致命错误：没有发现任何文件。");
                        Console.WriteLine("你真的有安装网易云音乐吗？试试看运行一次呢？");
                        Console.WriteLine("这个错误也许是因为开发的问题或者网易云API变更导致的w，可以汇报到issue喔w");
                        return null;
                    }
                    else
                    {
                        if (filename == filepath)
                        {
                            Console.WriteLine("已经找到了文件！");
                            return filepath;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }

    class JsonControl
    {
        public static void Parser(string jsonfile)
        {
            //file in
            string lines = jsonfile;


            //setup the interface for the data that has been pulled out


        }
    }

    class Modules
    {

    }

    class Data
    {

    }

    class Debug
    {

    }
}
