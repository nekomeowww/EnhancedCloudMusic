using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMusicHelper.TagConvert
{
    class TagConvert
    {
        public static void TagCommand(List<string> param)
        {

        }

        private static void TagCommandHelp()
        {
            //Create a new list to store the helping content
            List<string> helptext = new List<string>();

            //Add the helping content into the List
            helptext.Add("");

            //display the helptext
            foreach (string line in helptext)
            {
                Console.WriteLine(line);
            }
            return;
        }

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
