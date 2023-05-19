using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedC__Task1
{
    public class FileSystemVisitor
    {
        public IEnumerable<string> Search(string sDir)
        {
            foreach (var file in Directory.EnumerateFiles(sDir))
            {
                //Console.WriteLine($"inside search {file}");
                yield return file;
            }

            foreach (var directory in Directory.GetDirectories(sDir))
            {
                Console.WriteLine($"Folder: {directory.Split("/").Last()}");
                foreach (var file in Search(directory))
                    yield return file;
            }
        }
    }
}
