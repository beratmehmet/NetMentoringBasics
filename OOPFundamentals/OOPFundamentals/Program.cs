using System.Text.RegularExpressions;
using OOPFundamentals;
using OOPFundamentals.Entities;

Console.WriteLine("ses");
Patent patent = new Patent("test title", new string[1] {"berat"}, new DateTime(2019, 7, 26), new DateTime(2019, 7, 26).AddMonths(5));
LocalizedBook localizedBook = new LocalizedBook("LBook", new string[2] { "Raman", "Berat" }, new DateTime(2019, 7, 26),50,"EA","IS","TR");
FileSystemDocumentRepository repository = new FileSystemDocumentRepository();
repository.Write(patent);
repository.Write(localizedBook);
Regex regex = new Regex(@"./(.*?)_");
//var regex2 = Regex.Matches(repository.Search(1).First(),$"");
//var result = regex.Match(repository.Search(1).First()).Groups[1].Value;
Console.WriteLine(repository.Search(2).First());
Console.ReadKey();