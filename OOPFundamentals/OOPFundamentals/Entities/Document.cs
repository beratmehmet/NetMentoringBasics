using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OOPFundamentals.Entities
{
    public abstract class Document
    {
        public int ID { get; set; }

        static int nextID;

        public string Title { get; set; }

        public string[] Authors { get; set; }

        [JsonIgnore]
        DateTime DatePublished { get; set; }

        [JsonIgnore]
        public abstract Type _documentType { get; }

        public string DocumentType { get => _documentType.Name; }

        public Document(string title, string[] authors, DateTime datePublished, int id, string documentType = null)
        {
            Title = title;
            Authors = authors;
            DatePublished = datePublished;
            ID = Interlocked.Increment(ref nextID);

        }
    }
}
