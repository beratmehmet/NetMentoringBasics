using AdvancedC__Task1;

FileSystemVisitor fileSystemVisitor = new(@"C:\test",(x => Path.GetExtension(x) == ".txt"));
fileSystemVisitor.Start += (sender, args) => Console.WriteLine("Started");
fileSystemVisitor.Finish += (sender, args) => Console.WriteLine("Finished");
fileSystemVisitor.DirectoryFound += EventProcessor;
fileSystemVisitor.FileFound += EventProcessor;
fileSystemVisitor.FilteredDirectoryFound += EventProcessor;
fileSystemVisitor.FilteredFileFound += EventProcessor;

//foreach (string file in fileSystemVisitor.SearchFiles())
//{
//    Console.WriteLine($"File:{file}");
//}
fileSystemVisitor.SearchFiles();
Console.ReadLine();

static void EventProcessor(object sender, FileSystemVisitorEventArgs args)
{
    Console.WriteLine($"{args.eventName} => {args.path}");
}
