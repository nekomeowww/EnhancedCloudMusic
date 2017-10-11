using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;

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

            try
            {

            }
            catch(Exception e)
            {
                Debug.Logger(e.Message, "Error");
            }


        }

        private static string HttpPost(string url, string data)
        {
            try
            {
                //创建post请求
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "GET";
                request.ContentType = "application/json;charset=UTF-8";
                byte[] payload = Encoding.UTF8.GetBytes(data);
                request.ContentLength = payload.Length;

                //发送post的请求
                Stream writer = request.GetRequestStream();
                writer.Write(payload, 0, payload.Length);
                writer.Close();

                //接受返回来的数据
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string value = reader.ReadToEnd();

                reader.Close();
                stream.Close();
                response.Close();

                return value;
            }
            catch(Exception e)
            {
                Debug.Logger(e.Message, "Error");
                return "";
            }
        }
    }
}
