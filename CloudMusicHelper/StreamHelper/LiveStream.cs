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
            string apipath = Data.nowplayingfullPath;

            //Track Name
            string track_name = Data.track.name;
            string artist_name = Data.trackArtistsItem.name;
            string album_name = Data.album.name;

            string outputprefix = "正在播放：";
            string output = outputprefix + track_name + " by " + artist_name;

            //stream to log
            do
            {
                Debug.Logger("更新的内容：" + output);
                Debug.Logger("正在把更新内容写入到API文件...");
                ApiWrite(apipath, output);
                Debug.Logger("写入成功！");
            }
            while (false);
        }

        public static string NowPlayingApiCreate()
        {
            //set path for api file
            string appPath = AppDomain.CurrentDomain.BaseDirectory;
            string apiPath = Path.Combine(appPath, @"api\");
            string apiname = "NowPlaying";
            string apiextn = ".txt";
            string apifile = apiname; //combine CloudMusicHelperLog- with 2017-10-04-02-13-55
            string apifull = apiPath + apifile + apiextn;

            if(!Directory.Exists(apiPath))
            {
                System.IO.Directory.CreateDirectory(apiPath);
            }

            //create log file
            var newlog = File.Create(apifull);

            //close file stream
            newlog.Close();

            //Set Verifier
            bool havelog = File.Exists(apifull);

            //debug

            if (havelog)
            {
                Debug.Logger("NowPlaying API文件已创建：" + apifile + apiextn, "Trace");
            }
            else
            {
                Debug.Logger("NowPlaying API文件创建失败：" + apifile + apiextn, "Error");
            }

            //finish create
            Data.nowplayingfullPath = apifull;
            return apifull;
        }

        public static void ApiWrite(string path, string text)
        {
            if (path == null)
            {
                Debug.Logger("API文件尚未创建", "Fatal");
                return;
            }

            //Write the info into file
            File.WriteAllText(path, text);

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
