using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Text_Editor_Assignment_2
{
    public class GlobalFunctions
    {
        //FILE Methods
        public bool CreateFile(string fileName, string content)
        {
            string path = GetFilePath() + fileName + ".txt";
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(content);
                }
            }
            return true;
        }

        //get the file path
        public string GetFilePath()
        {
            //System.IO.Directory.GetCurrentDirectory();
            return "Files\\";
        }

        //get account details
        public string AccountDetails(string accNo)
        {
            string filePath = GetFilePath() + accNo + ".txt"; ;
            if (File.Exists(filePath))
            {
                //read all lines from the file
                string[] lines = File.ReadAllLines(filePath);
                string content = "";
                for (int i = 0; i < lines.Length; i++)
                {
                    if (!String.IsNullOrEmpty(lines[i]))
                    {
                        content += lines[i].Split(',')[1] + ',';
                    }
                }
                return content;
            }
            return "";
        }


    }

}
