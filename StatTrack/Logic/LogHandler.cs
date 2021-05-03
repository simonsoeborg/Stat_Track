using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace StatTrack.Logic
{
    public class LogHandler
    {
        public static void saveToFile(string path, string userId)
        {
            DateTime date = new DateTime();
            string timestamp = date.Day + "-" + date.Month + "-" + date.Year + "_" + date.Hour + "_" + date.Minute + "_";
            string fileName = userId + "gameFile_" + timestamp + ".txt";
            string folderName = "gameLogs";

            string wwwPath = Path.Combine(path, folderName);
            if (!Directory.Exists(wwwPath))
            {
                Directory.CreateDirectory(wwwPath);
            }


        }

    }
}
