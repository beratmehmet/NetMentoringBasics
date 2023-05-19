using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedC__Task1
{
    public class FileSystemVisitor
    {
        public string rootFolder;
        private readonly Func<string, bool> _searchAlgorithm;
        public event EventHandler<EventArgs> Start;
        public event EventHandler<EventArgs> Finish;
        public event EventHandler<FileSystemVisitorEventArgs> FileFound;
        public event EventHandler<FileSystemVisitorEventArgs> DirectoryFound;
        public event EventHandler<FileSystemVisitorEventArgs> FilteredFileFound;
        public event EventHandler<FileSystemVisitorEventArgs> FilteredDirectoryFound;
        public FileSystemVisitor(string rootFolder, Func<string, bool> searchAlgorithm = null)
        {
            this.rootFolder = rootFolder;
            _searchAlgorithm = searchAlgorithm ?? (x => true);
        }

        public void SearchFiles()
        {
            OnStart();
            foreach(string file in SearchFiles(rootFolder))
            {
                Console.WriteLine($"File:{file}");
            }
            OnFinish();
        }

        public IEnumerable<string> SearchFiles(string sDir)
        {

            FileSystemVisitorEventArgs directoryArgs = new FileSystemVisitorEventArgs { path = sDir};
            if (_searchAlgorithm(sDir))
            {
                OnFilteredDirectoryFound(directoryArgs);
                yield return sDir;
            }
            
            if (Directory.Exists(sDir))
            {
                OnDirectoryFound(directoryArgs);
                foreach (var file in Directory.GetFiles(sDir))
                {
                    FileSystemVisitorEventArgs fileArgs = new FileSystemVisitorEventArgs { path = file};
                    OnFileFound(fileArgs);
                    
                    if (_searchAlgorithm(file))
                    {
                        OnFilteredFileFound(fileArgs);
                        yield return file;
                    }
                }

                foreach (var directory in Directory.GetDirectories(sDir))
                {
                    foreach (var file in SearchFiles(directory))
                        yield return file;
                }
            }
        }

        protected virtual void OnStart()
        {
            Start?.Invoke(this,EventArgs.Empty);
        }
        protected virtual void OnFinish()
        {
            Finish?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnFileFound(FileSystemVisitorEventArgs args)
        {
            args.eventName = "FileFound";
            FileFound?.Invoke(this, args);
        }
        protected virtual void OnDirectoryFound(FileSystemVisitorEventArgs args)
        {
            args.eventName = "DirectoryFound";
            DirectoryFound?.Invoke(this, args);
        }
        protected virtual void OnFilteredFileFound(FileSystemVisitorEventArgs args)
        {
            args.eventName = "FilteredFileFound";
            FilteredFileFound?.Invoke(this, args);
        }
        protected virtual void OnFilteredDirectoryFound(FileSystemVisitorEventArgs args)
        {
            args.eventName = "FilteredDirectoryFound";
            FilteredDirectoryFound?.Invoke(this, args);
        }
    }

    public class FileSystemVisitorEventArgs:EventArgs
    {
        public string path { get ; set; }
        public string eventName { get ; set; }
        public bool Exclude { get; set; } = false;
        public bool Abort { get; set; } = false;
    }
}
