using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Unicode;
using OOPFundamentals.Entities;

namespace OOPFundamentals
{
    internal class FileSystemDocumentRepository : IStorage
    {
        public Document Read(string fileName)
        {
            var jsonString = File.ReadAllText(fileName);
            JsonNode jsonNode = JsonNode.Parse(jsonString);
            string documentType = (string)jsonNode!["DocumentType"];
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true,
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                PropertyNameCaseInsensitive = true };
            Document document;

            switch (documentType)
            {
                case "Patent":
                    document = jsonNode.Deserialize<Patent>(options);
                    break;
                case "Book":
                    document = jsonNode.Deserialize<Book>(options);
                    break;
                case "LocalizedBook":
                    document = jsonNode.Deserialize<LocalizedBook>(options);
                    break;
                default:
                    throw new InvalidOperationException("Invalid type value in JSON.");
            }
            return document;
        }

        public List<Document> Search(int documentNumber)
        {
            List<Document> foundDocuments = new List<Document>();
            IEnumerable<string> foundFiles =  Directory.EnumerateFiles(".", $"*#{documentNumber}.json", SearchOption.AllDirectories).ToList();
            foreach(string fileName in foundFiles)
            {
                Document document = Read(fileName);
                if (document != null)
                {
                    foundDocuments.Add(document);
                }
            }
            return foundDocuments;
        }

        public void Write(Document document)
        {
            string fileName = $"{document.DocumentType}_#{document.ID}.json";
            var options = new JsonSerializerOptions { WriteIndented = true, IncludeFields = true, Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) };
            string jsonString = JsonSerializer.Serialize<object>(document, options);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
