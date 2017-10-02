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
            string appPath = AppDomain.CurrentDomain.BaseDirectory;

            DateTime localDate = DateTime.Now;
            var format = new CultureInfo("zh-CN");
            Console.WriteLine("[*Welcome*] " + localDate.ToString(format) + " : " + "欢迎使用Enhanced CloudMusic喵~");
            Debug.Logger("你好喵，欢迎来到Enhanced CloudMusic Debug Log模式w");
            Debug.Logger("正在准备一些小惊喜喔w！Web服务初始化中...");

            //WebApp Init
            //string webappPath = Path.Combine(appPath, "\\webapp\\public");
            //WebAppServerContributed webappInstance = new WebAppServerContributed(webappPath, 25108);
            Debug.Logger("本地服务器初始化完成啦，在浏览器中访问 " + "http://localhost:" + /*webappInstance.Port.ToString()*/ "25108" + " 就可以了喵w");

            DynamicControl.HistoryFileTracker(FileControl.GetHistory());
            do
            {
                HistoryControl.History();
            }
            while(false);

            //webappInstance.Stop(); //停止服务器
            Console.ReadLine();
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

            //debug
            //Console.WriteLine(historytext);

            //Read and send data to processor
            JsonControl.HistoryParser(historytext);

            return historytext;
        }
    }

    //[PermissionSet(SecurityAction.Demand, Name = "FullTrust")] //管理员权限，webapp需求
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
        public static Hierarchy HistoryParser(string jsonfile)
        {
            //file in
            string lines = jsonfile;
            //json into hierarchy
            //Hierarchy hierarchy = JsonConvert.DeserializeObject<Hierarchy>(lines);
            JArray jarray = (JArray)JsonConvert.DeserializeObject(lines);

            Hierarchy hirerachy = new Hierarchy();

            //list
            string hierarchy = jarray[0].ToString();
            string id = jarray[0]["id"].ToString();
            string track = jarray[0]["track"].ToString();
            string track_name = jarray[0]["track"]["name"].ToString();
            string artist_name = jarray[0]["track"]["artists"][0]["name"].ToString();
            string album_name = jarray[0]["track"]["album"]["name"].ToString();
            string source = jarray[0]["text"].ToString();

            Debug.Logger("正在播放：" + track_name + " by " + artist_name);
            Debug.Logger("专辑信息：" + album_name);
            Debug.Logger("项目来源：" + source);
            //hirerachy.track.name = jobj["track"];
            //hirerachy.track.id = ;

            return hirerachy;
        }
    }

    class WebAppMain
    {
        
    }

    class WebAppServerContributed
    {
        /*****************************************************************************
         * 
         * This part of code is made by @aksakalli
         * Gist: https://gist.github.com/aksakalli/9191056#file-simplehttpserver-cs-L9
         * 
         *****************************************************************************/

        //这是索引文件/
        //这些文件只可读喔
        private readonly string[] _indexFiles =
        {
        "index.html",
        "index.htm",
        "default.html",
        "default.htm"
        };

        //webapp的文件类型列表/
        private static IDictionary<string, string> _mimeTypeMappings = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase)
        {
        #region extension to MIME type list
        {".asf", "video/x-ms-asf"},
        {".asx", "video/x-ms-asf"},
        {".avi", "video/x-msvideo"},
        {".bin", "application/octet-stream"},
        {".cco", "application/x-cocoa"},
        {".crt", "application/x-x509-ca-cert"},
        {".css", "text/css"},
        {".deb", "application/octet-stream"},
        {".der", "application/x-x509-ca-cert"},
        {".dll", "application/octet-stream"},
        {".dmg", "application/octet-stream"},
        {".ear", "application/java-archive"},
        {".eot", "application/octet-stream"},
        {".exe", "application/octet-stream"},
        {".flv", "video/x-flv"},
        {".gif", "image/gif"},
        {".hqx", "application/mac-binhex40"},
        {".htc", "text/x-component"},
        {".htm", "text/html"},
        {".html", "text/html"},
        {".ico", "image/x-icon"},
        {".img", "application/octet-stream"},
        {".iso", "application/octet-stream"},
        {".jar", "application/java-archive"},
        {".jardiff", "application/x-java-archive-diff"},
        {".jng", "image/x-jng"},
        {".jnlp", "application/x-java-jnlp-file"},
        {".jpeg", "image/jpeg"},
        {".jpg", "image/jpeg"},
        {".js", "application/x-javascript"},
        {".mml", "text/mathml"},
        {".mng", "video/x-mng"},
        {".mov", "video/quicktime"},
        {".mp3", "audio/mpeg"},
        {".mpeg", "video/mpeg"},
        {".mpg", "video/mpeg"},
        {".msi", "application/octet-stream"},
        {".msm", "application/octet-stream"},
        {".msp", "application/octet-stream"},
        {".pdb", "application/x-pilot"},
        {".pdf", "application/pdf"},
        {".pem", "application/x-x509-ca-cert"},
        {".pl", "application/x-perl"},
        {".pm", "application/x-perl"},
        {".png", "image/png"},
        {".prc", "application/x-pilot"},
        {".ra", "audio/x-realaudio"},
        {".rar", "application/x-rar-compressed"},
        {".rpm", "application/x-redhat-package-manager"},
        {".rss", "text/xml"},
        {".run", "application/x-makeself"},
        {".sea", "application/x-sea"},
        {".shtml", "text/html"},
        {".sit", "application/x-stuffit"},
        {".swf", "application/x-shockwave-flash"},
        {".tcl", "application/x-tcl"},
        {".tk", "application/x-tcl"},
        {".txt", "text/plain"},
        {".war", "application/java-archive"},
        {".wbmp", "image/vnd.wap.wbmp"},
        {".wmv", "video/x-ms-wmv"},
        {".xml", "text/xml"},
        {".xpi", "application/x-xpinstall"},
        {".zip", "application/zip"},
        #endregion
        };

        private Thread _serverThread; //新建一个服务器线程
        private string _rootDirectory; //设置服务器根目录
        private HttpListener _listener; //新建一个Http请求监听器
        private int _port; //新建一个端口

        public int Port
        {
            get { return _port; }
            private set { }
        }

        /// <summary>
        /// Construct server with given port.
        /// </summary>
        /// <param name="path">Directory path to serve.</param>
        /// <param name="port">Port of the server.</param>
        public WebAppServerContributed(string path, int port)
        {
            this.Initialize(path, port);
        }

        /// <summary>
        /// Construct server with suitable port.
        /// </summary>
        /// <param name="path">Directory path to serve.</param>
        public WebAppServerContributed(string path)
        {
            //get an empty port
            TcpListener l = new TcpListener(IPAddress.Loopback, 0);
            l.Start();
            int port = ((IPEndPoint)l.LocalEndpoint).Port;
            l.Stop();
            this.Initialize(path, port);
        }

        /// <summary>
        /// Stop server and dispose all functions.
        /// </summary>
        public void Stop()
        {
            _serverThread.Abort();
            _listener.Stop();
        }

        private void Listen()
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add("http://*:" + _port.ToString() + "/");
            _listener.Start();
            while (true)
            {
                try
                {
                    HttpListenerContext context = _listener.GetContext();
                    Process(context);
                }
                catch (Exception ex)
                {
                    Debug.Logger(ex.Message);
                }
            }
        }

        private void Process(HttpListenerContext context)
        {
            string filename = context.Request.Url.AbsolutePath;
            Console.WriteLine(filename);
            filename = filename.Substring(1);

            if (string.IsNullOrEmpty(filename))
            {
                foreach (string indexFile in _indexFiles)
                {
                    if (File.Exists(Path.Combine(_rootDirectory, indexFile)))
                    {
                        filename = indexFile;
                        break;
                    }
                }
            }

            filename = Path.Combine(_rootDirectory, filename);

            if (File.Exists(filename))
            {
                try
                {
                    Stream input = new FileStream(filename, FileMode.Open);

                    //Adding permanent http response headers
                    string mime;
                    context.Response.ContentType = _mimeTypeMappings.TryGetValue(Path.GetExtension(filename), out mime) ? mime : "application/octet-stream";
                    context.Response.ContentLength64 = input.Length;
                    context.Response.AddHeader("Date", DateTime.Now.ToString("r"));
                    context.Response.AddHeader("Last-Modified", System.IO.File.GetLastWriteTime(filename).ToString("r"));

                    byte[] buffer = new byte[1024 * 16];
                    int nbytes;
                    while ((nbytes = input.Read(buffer, 0, buffer.Length)) > 0)
                        context.Response.OutputStream.Write(buffer, 0, nbytes);
                    input.Close();

                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    context.Response.OutputStream.Flush();
                }
                catch (Exception ex)
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                }

            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }

            context.Response.OutputStream.Close();
        }

        private void Initialize(string path, int port)
        {
            this._rootDirectory = path;
            this._port = port;
            _serverThread = new Thread(this.Listen);
            _serverThread.Start();
        }
    }

    class WebAppControl
    {

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

    class DynamicControl
    {
        public static void HistoryFileTracker(string path)
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            /* Watch for changes in LastAccess and LastWrite times, and the renaming of files or directories. */

            string filename = "history";
            path = System.Text.RegularExpressions.Regex.Replace(path, "history", "");

            watcher.Path = path;
            watcher.NotifyFilter = NotifyFilters.LastAccess | 
                                   NotifyFilters.LastWrite | 
                                   NotifyFilters.FileName | 
                                   NotifyFilters.DirectoryName;

            watcher.Filter = "history";

            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            //watcher.Created += new FileSystemEventHandler(OnChanged);
            //watcher.Deleted += new FileSystemEventHandler(OnChanged);
            //watcher.Renamed += new RenamedEventHandler(OnRenamed);
            watcher.Error += new ErrorEventHandler(OnError);

            watcher.EnableRaisingEvents = true;
        }

        private static void HistoryUpdated()
        {
            HistoryControl.History();
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            //Debug tool = new Debug();

            int i = 0;
            int counter;
            i++;

            counter = Debug.methodCallCount();

            if(Debug.CallCount == 2)
            {
                Debug.Logger(Modules.DataRefreshMessages());
                Thread.Sleep(500); //Avoid file io stream error
                HistoryUpdated();

                Debug.CallCount = 0;
            }
            else
            {
                if(Debug.CallCount >= 3)
                {
                    Debug.CallCount = 0;
                }
            }

            //HistoryUpdated();

            /*
             * 这里有个小bug，因为读取之后似乎文件被改变了，导致这个event被触发了一次
             * 正在思考如何解决这个问题w
             * 
             * 这个bug解决啦w
             * 使用的方法是采用方法调用计数，一旦调用超过一定数值才会响应w
             */

            /*
            if (e.ChangeType.ToString() == "Changed")
            {
                Debug.Logger("数据更新中...");
            }
            */
        }
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            // Specify what is done when a file is renamed.
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }

        private static void OnError(object source, ErrorEventArgs e)
        {
            //  Show that an error has been detected.
            Console.WriteLine("The FileSystemWatcher has detected an error");
            //  Give more information if the error is due to an internal buffer overflow.
            if (e.GetException().GetType() == typeof(InternalBufferOverflowException))
            {
                //  This can happen if Windows is reporting many file system events quickly 
                //  and internal buffer of the  FileSystemWatcher is not large enough to handle this
                //  rate of events. The InternalBufferOverflowException error informs the application
                //  that some of the file system events are being lost.
                Console.WriteLine(("The file system watcher experienced an internal buffer overflow: " + e.GetException().Message));
            }
        }
    }

    class Data
    {

    }

    class Debug
    {
        public static int CallCount = 0;
        public static void NullTracker()
        {

        }

        public static void Logger(string text)
        {
            DateTime localDate = DateTime.Now;
            var format = new CultureInfo("zh-CN");
            Console.WriteLine("[Debug Log] " + localDate.ToString(format) + " : " + text);
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
