using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTestExample
{
    public class FileExample
    {
        public string LoadTextFile(string file)
        {
            if (file.Length < 10)
            {
                //throw new System.IO.FileNotFoundException();
                throw new ArgumentException("File name is invalid","file");
            }
            return "Tiedoston lataus onnistui!";
        }
    }
}
