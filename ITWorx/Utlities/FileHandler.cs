using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITWorx.Utlities
{
    public class FileHandler
    {
        public static void WriteDataToNotePade(string path, List<string> players)
        {
            TextWriter spec = new StreamWriter(path + "\\Name.txt");
            foreach (string p in players)
            {
                spec.WriteLine(p);
            }
            spec.Close();
        }
    }
}
