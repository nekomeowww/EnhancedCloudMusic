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
            if(param[0] == "")
            {
                TagCommandHelp();
                return;
            }
            else if(param[0] == "-convert" || param[0] == "-get")
            {
                Console.WriteLine("Checking params");
                Console.WriteLine("Current tag Command Mode: " + param[0]);
                Console.WriteLine("param after mode is: " + param[1]);
                if(param[1] == "--type" || param[1] == "--path" || param[1] == "--format")
                {
                    switch (param[1])
                    {
                        case "--path":
                            Console.WriteLine("Path Get.");
                            break;
                        case "--type":
                            Console.WriteLine("Convert Type Get.");
                            break;
                        case "--format":
                            Console.WriteLine("Target Format Get.");
                            break;
                        default:
                            TagCommandHelp();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Unknown Parameter.");
                    TagCommandHelp();
                }
            }
            else
            {
                TagCommandHelp();
            }
        }

        public static void ParametersControl(string mode, string nextparam)
        {

        }

        private static void Mode(string mode)
        {
            switch (mode)
            {
                case "debug":
                    // debug log mode
                default:
                    Console.WriteLine("未知命令。");
                    TagCommandHelp();
                    break;
            }
            return;
        }

        private static void TagCommandHelp()
        {
            //Create a new list to store the helping content
            List<string> taghelp = new List<string>();

            //Add the helping content into the List
            taghelp.Add("");
            taghelp.Add("Usage:    [tag -convert [--path [path of track]]] | Convert param is for converting ID3Tag.");
            taghelp.Add("          Options: [--type] Specify the converting type. Acceptable values: CM, deCM, default is CM");
            taghelp.Add("                   --type CM is for converting the source to compatiable to CloudMusic and store it into a folder.");
            taghelp.Add("                   --type deCM is for de-converting the converted or the downloaded source into the regular tagging format.");
            taghelp.Add("");
            taghelp.Add("                   [--format] Specify the converting source format, current acceptable values:mp3, flac.");
            taghelp.Add("                   --format mp3 is for converting the ID3Tag of a MP3 file into the CM-compatiable version");
            taghelp.Add("                   --format flac is for converting the ID3Tag of a FLAC file into the CM-compatiable version");
            taghelp.Add("");
            taghelp.Add("          [tag -get [--path [path of track]] | Get param is for gathering ID3Tag data from source file");
            taghelp.Add("          Options: [--format] Specify the converting source format, current acceptable values:mp3, flac.");
            taghelp.Add("                   --format mp3 is for converting the ID3Tag of a MP3 file into the CM-compatiable version");
            taghelp.Add("                   --format flac is for converting the ID3Tag of a FLAC file into the CM-compatiable version");

            //display the helptext
            foreach (string line in taghelp)
            {
                Console.WriteLine(line);
            }
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
