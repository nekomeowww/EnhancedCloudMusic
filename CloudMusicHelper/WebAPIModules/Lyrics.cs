using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.IO;
using System.IO.Compression;

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
            string eapiurlsample = "http://music.163.com/eapi/song/lyric?id=";
            string weapiurlsample = "http://music.163.com/weapi/song/lyric?id=";

            string url = urlsample + id;

            Debug.Logger("当前API URL：" + url);

            //CookieCollection cookies = new CookieCollection();

            //weapi不能使用GET，试试看POST

            /*
            try
            {
                HttpWebResponse hwr = CreateGetHttpResponse(url, null, null, cookies);
                Stream stream = hwr.GetResponseStream();
                Stream feedback;
                StreamReader streamReader = new StreamReader(stream, Encoding.GetEncoding("utf-8"));
                string retString = streamReader.ReadToEnd();

                //Gzip parser

                feedback = new GZipStream(hwr.GetResponseStream(), CompressionMode.Decompress);
                StreamReader gzipReader = new StreamReader(feedback, Encoding.GetEncoding("utf-8"));
                string gzipResult = gzipReader.ReadToEnd();
                Debug.Logger("当前GZIP数据：" + gzipResult, "Debug");
                gzipReader.Close();
                
                switch (hwr.ContentEncoding.ToUpperInvariant())
                {
                    case "GZIP":
                        feedback = new GZipStream(hwr.GetResponseStream(), CompressionMode.Decompress);
                        StreamReader gzipReader = new StreamReader(feedback, Encoding.GetEncoding("utf-8"));
                        string gzipResult = gzipReader.ReadToEnd();
                        Debug.Logger("当前GZIP数据：" + gzipResult, "Debug");
                        gzipReader.Close();
                        break;
                    case "DEFLATE":
                        feedback = new DeflateStream(hwr.GetResponseStream(), CompressionMode.Decompress);
                        StreamReader deflateReader = new StreamReader(feedback, Encoding.GetEncoding("utf-8"));
                        string deflateResult = deflateReader.ReadToEnd();
                        Debug.Logger("当前DEFLATE数据：" + deflateResult, "Debug");
                        deflateReader.Close();
                        break;

                    default:
                        feedback = hwr.GetResponseStream();
                        break;
                }

                streamReader.Close();
                stream.Close();
                feedback.Close();

                Debug.Logger("当前返回数据：" + retString, "Trace");
            }
            catch(Exception e)
            {
                Debug.Logger(e.Message, "Error");
            }
            */

        }

        //看到有说api换掉了，试试看带param

        /*
        public static HttpWebResponse CreateGetHttpResponse(string url, int? timeout, string userAgent, CookieCollection cookies)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            if (!string.IsNullOrEmpty(userAgent))
            {
                request.UserAgent = userAgent;
            }
            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }
            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }
            return request.GetResponse() as HttpWebResponse;
        }
        */

        /*
        #region 简易版
        private static string HttpGet(string url, string data)
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
        #endregion
        */
    }
}
