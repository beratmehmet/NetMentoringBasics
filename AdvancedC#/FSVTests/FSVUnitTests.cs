using AdvancedC__Task1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSVTests
{
    public class FSVUnitTests: IDisposable
    {
        public readonly string _testFolder;
        
        private List<string> _directories;
        public FSVUnitTests()
        {
            _testFolder = Path.Combine(Path.GetTempPath(), "FSVTESTS");
            Directory.CreateDirectory(_testFolder);
            Directory.CreateDirectory(Path.Combine(_testFolder, "dir1"));
            Directory.CreateDirectory(Path.Combine(_testFolder, "dir2"));
            File.WriteAllText(Path.Combine(_testFolder, "file1.txt"), "test");
            File.WriteAllText(Path.Combine(_testFolder, "file2.txt"), "test");
            File.WriteAllText(Path.Combine(_testFolder, "dir1", "file3.txt"), "test");
            File.WriteAllText(Path.Combine(_testFolder, "dir2", "file4.txt"), "test");
        }
        [Fact]
        public void SearchFiles_ReturnAllFilesAndDirectories() 
        {
           List<string> files = new List<string> { _testFolder,
                Path.Combine(_testFolder, "file1.txt"),
                Path.Combine(_testFolder, "file2.txt"),
                Path.Combine(_testFolder, "dir1"),
                Path.Combine(_testFolder, "dir1", "file3.txt"),
                Path.Combine(_testFolder, "dir2"),
                Path.Combine(_testFolder, "dir2", "file4.txt")
            };
            FileSystemVisitor fileSystemVisitor = new FileSystemVisitor(_testFolder);
            var result = fileSystemVisitor.SearchFiles();
            Console.Write(result);
            Assert.Equal(files, result);
        }

        [Fact]
        public void SearchFiles_ReturnsFilteredFiles()
        {
            List<string> files = new List<string> {
                Path.Combine(_testFolder, "file1.txt"),
                Path.Combine(_testFolder, "file2.txt"),
                Path.Combine(_testFolder, "dir1", "file3.txt"),
                Path.Combine(_testFolder, "dir2", "file4.txt")
            };

            FileSystemVisitor fileSystemVisitor = new FileSystemVisitor(_testFolder, (x => Path.GetExtension(x) == ".txt"));
            var result = fileSystemVisitor.SearchFiles();
            Assert.Equal(files, result);
        }

        [Fact]
        public void SearchFiles_ReturnsFilteredFilesAndFolders()
        {
            List<string> directories = new List<string>{
                Path.Combine(_testFolder, "dir1"),
                Path.Combine(_testFolder, "dir1", "file3.txt"),
                Path.Combine(_testFolder, "dir2"),
                Path.Combine(_testFolder, "dir2", "file4.txt")
            };

            FileSystemVisitor fileSystemVisitor = new FileSystemVisitor(_testFolder, (x => x.Contains("dir")));
            var result = fileSystemVisitor.SearchFiles();
            Assert.Equal(directories, result);
        }

        public void Dispose()
        {
           Directory.Delete(_testFolder, true);
        }
    }
}
