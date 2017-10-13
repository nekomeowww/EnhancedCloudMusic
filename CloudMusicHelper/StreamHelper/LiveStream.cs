using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CloudMusicHelper.StreamHelper
{
    class LiveStream
    {
        //create a file to ./api, named NowPlaying.txt
        public static void NowPlaying()
        {
            //Ultilities
            string apipath1 = Data.nowplayingfullPath;
            string apipath2 = Data.nowplayingadfullPath;

            //Track Name
            string track_name = Data.track.name;
            string artist_name = Data.trackArtistsItem.name;
            string album_name = Data.album.name;

            //string placeholder = "";
            string outputprefix = "正在播放：";
            string outputprefix2 = " 正在播放：";
            string outputinfo = " " + track_name + " - " + artist_name;
            string output = outputprefix + track_name + " - " + artist_name;

            //output list for advanced
            string[] outputlines = new string[3];

            //insert lines into outputlines
            //there is a problem here, cannot stream out
            outputlines[0] = outputprefix2;
            outputlines[1] = outputinfo;

            //stream to log
            do
            {
                Debug.Logger("更新的内容：" + output);
                Debug.Logger("正在把更新内容写入到API文件...");
                ApiWrite(apipath1, output, outputlines);
                ApiWrite(apipath2, output, outputlines);

                Debug.Logger("写入成功！");
            }
            while (false);
        }

        public static string NowPlayingApiCreate()
        {
            //set path for api file
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string apiPath = Path.Combine(appPath, @"api\");
            string apiname1 = "NowPlaying";
            string apiname2 = "NowPlayingAdvanced";
            string apiextn = ".txt";
            string apifile1 = apiname1; //combine NowPlaying.txt
            string apifile2 = apiname2; //combine NowPlayingAdvanced.txt
            string apifull1 = apiPath + apifile1 + apiextn;
            string apifull2 = apiPath + apifile2 + apiextn;

            if(!Directory.Exists(apiPath))
            {
                Directory.CreateDirectory(apiPath);
            }

            //create log file
            var newapi1 = File.Create(apifull1);
            var newapi2 = File.Create(apifull2);

            //close file stream
            newapi1.Close();
            newapi2.Close();

            //Set Verifier
            bool haveapi1 = File.Exists(apifull1);
            bool haveapi2 = File.Exists(apifull2);

            //debug

            if (haveapi1 && haveapi2)
            {
                Debug.Logger("NowPlaying API文件已创建：" + apifile1 + apiextn, "Trace");
                Debug.Logger("NowPlaying API高级文件已创建：" + apifile2 + apiextn, "Trace");
            }
            else
            {
                Debug.Logger("NowPlaying API文件创建失败：" + apifile1 + apiextn, "Error");
                Debug.Logger("NowPlaying API高级文件已创建：" + apifile2 + apiextn, "Trace");
            }

            //finish create
            Data.nowplayingfullPath = apifull1;
            Data.nowplayingadfullPath = apifull2;

            return apifull1;
        }

        public static void ApiWrite(string path, string text, string[] lines)
        {
            if (path == null)
            {
                Debug.Logger("API文件尚未创建", "Fatal");
                return;
            }

            //Write the info into file
            if(path.Contains("NowPlayingAdvanced.txt"))
            {
                File.WriteAllLines(path, lines);
            }
            else
            {
                File.WriteAllText(path, text);
            }


            /*
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(path))
            {
                file.WriteLine(text);
                file.Close();
            }
            */
        }
    }
}
