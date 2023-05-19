using AdvancedC__Task1;

FileSystemVisitor fileSystemVisitor = new();
//fileSystemVisitor.ProcessDirectory("/Users/Mehmet_Topuz/Desktop");
foreach(string file in fileSystemVisitor.Search("/Users/Mehmet_Topuz/Desktop/test"))
{
    Console.WriteLine($"File:{file.Split("/").Last()}");
}

Console.ReadLine();
