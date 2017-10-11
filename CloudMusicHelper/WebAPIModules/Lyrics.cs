using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace CloudMusicHelper.WebAPIModules
{
    class Lyrics
    {
        public static void GetLyrics()
        {
            //pull pure data from PureHistoryParser()
            Controller.HistoryControl.PureHistory();

            int id = Data.track.id;

            Debug.Logger("当前歌曲ID: " + id);

            string urlsample = "http://music.163.com/api/song/lyric?id=";

            string url = urlsample + id;

            Debug.Logger("当前API URL：" + url);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        }
    }
}
