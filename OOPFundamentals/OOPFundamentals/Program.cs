using OOPFundamentals;
using OOPFundamentals.Entities;

Console.WriteLine("ses");
Patent patent = new Patent("test title", new string[1] {"berat"}, new DateTime(2019, 7, 26), new DateTime(2019, 7, 26).AddMonths(5));
LocalizedBook localizedBook = new LocalizedBook("LBook", new string[2] { "Raman", "Berat" }, new DateTime(2019, 7, 26), PublicationType.LocalizedBook,50,"EA","İŞ","TR");
FileSystemDocumentRepository repository = new FileSystemDocumentRepository();
repository.Write(patent);
repository.Write(localizedBook);
Console.WriteLine(repository.Search(1).First());