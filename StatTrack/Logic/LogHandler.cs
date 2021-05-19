using System;
using System.IO;

namespace StatTrack.Logic
{
    public class LogHandler
    {
        public static void saveToFile(string path, string userId)
        {
            var date = new DateTime();
            var timestamp = date.Day + "-" + date.Month + "-" + date.Year + "_" + date.Hour + "_" + date.Minute + "_";
            var fileName = userId + "gameFile_" + timestamp + ".txt";
            var folderName = "gameLogs";

            var wwwPath = Path.Combine(path, folderName);
            if (!Directory.Exists(wwwPath)) Directory.CreateDirectory(wwwPath);
        }
    }
}