using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using OOPFundamentals.Entities;

namespace OOPFundamentals
{
    internal class FileSystemDocumentRepository : IStorage
    {
        public List<Document> Read()
        {
            throw new NotImplementedException();
        }

        public List<string> Search(int documentNumber)
        {

            return Directory.EnumerateFiles(".", $"*#{documentNumber}.json", SearchOption.AllDirectories).ToList();
        }

        public void Write(Document document)
        {
            string fileName = $"{document.PublicationType}_#{document.ID}.json";
            var options = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) };
            string jsonString = JsonSerializer.Serialize<object>(document, options);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
