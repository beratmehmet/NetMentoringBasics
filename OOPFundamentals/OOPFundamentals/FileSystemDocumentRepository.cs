using System.Runtime.Caching;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using OOPFundamentals.Entities;

namespace OOPFundamentals
{
    internal class FileSystemDocumentRepository : IStorage
    {
        public Document Read(string fileName)
        {

            var jsonString = File.ReadAllText(fileName);
            JsonNode jsonNode = JsonNode.Parse(jsonString);
            string documentType = (string)jsonNode!["documentType"];
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                //PropertyNameCaseInsensitive = true,
                //Converters = {new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)},
            };
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
                    throw new InvalidOperationException("Invalid Document Type");
            }
            return document;
        }

        public List<Document> Search(int documentNumber)
        {
            List<Document> foundDocuments = new List<Document>();

            if (DocumentCash.IsCached(documentNumber))
            {
                Console.WriteLine(documentNumber + "is cached");
                foundDocuments.Add(DocumentCash.GetItem(documentNumber) as Document);
                return foundDocuments;
            }

            IEnumerable<string> foundFiles =  Directory.EnumerateFiles(".", $"*#{documentNumber}.json", SearchOption.AllDirectories).ToList();

            foreach(string fileName in foundFiles)
            {
                Document document = Read(fileName);

                if (document != null)
                {
                    foundDocuments.Add(document);
                    DocumentCash.AddItem(documentNumber.ToString(), document, document.CacheItemPolicy);
                }
            }

            return foundDocuments;
        }

        public void Write(Document document)
        {
            string fileName = $"{document.DocumentType}_#{document.ID}.json";
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                IncludeFields = true,
            };
            string jsonString = JsonSerializer.Serialize<object>(document, options);
            File.WriteAllText(fileName, jsonString);
        }
    }
}
