using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicHelper.TagConvert
{
    class TagConvert
    {
        //link the track to taglib file object
        public static void CreateTaglib(string track)
        {
            //this will create a object to the tagFile and read from track
            TagLib.File tagFile = TagLib.File.Create(track);

            //for example if you want to get the value
            //uint year = tagFile.Tag.Year;

            //for example if you want to set the value
            //tagFile.Tag.Year = year;

            //for example if you want to save the changes
            //tagFile.Save();
        }
    }
}
