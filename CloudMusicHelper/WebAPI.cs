using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CloudMusicHelper.WebAPIModules;
using System.Net.Http;

namespace CloudMusicHelper
{
    class CloudMusicWebAPI
    {
        /*
        private static readonly HttpClient client = new HttpClient();

        public static async System.Threading.Tasks.Task PostAsync()
        {
            var values = new Dictionary<string, string>
            {
                { "thing1", "hello" },
                { "thing2", "world" }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("http://www.example.com/recepticle.aspx", content);

            var responseString = await response.Content.ReadAsStringAsync();

            //var responseString = await client.GetStringAsync("http://www.example.com/recepticle.aspx"); for GET
        }
        */

        //Doc for webapi
        //https://github.com/u3u/NeteaseCloudMusicApi

        //Lyric
        //http://music.163.com/api/song/lyric
        //get('http://y.dskui.com/api/music/lyric?id=29775505').then(json => console.info(json));

        //Playlist
        //http://music.163.com/api/playlist/detail
        //get('http://y.dskui.com/api/music/playlist?id=374755836').then(json => console.info(json));
    }
}