using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedC__Task1
{
    public class FileSystemVisitor
    {

        public void ProcessDirectory(string path)
        {
            string[] files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                ProcessFile(file);
            }
        }

        public void ProcessFile(string path)
        {
            Console.WriteLine("Processed file '{0}.'", path);
        }
    }
}
