using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OOPFundamentals.Entities
{
    public enum PublicationType { Patent, Book, LocalizedBook };
    public abstract class Document
    {
        public int ID { get; set; }

        static int nextID;

        public string Title { get; set; }

        public string[] Authors { get; set; }

        DateTime DatePublished { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public PublicationType PublicationType { get; set; }

        public Document(string title, string[] authors, DateTime datePublished, PublicationType publicationType)
        {
            Title = title;
            Authors = authors;
            DatePublished = datePublished;
            PublicationType = publicationType;
            ID = Interlocked.Increment(ref nextID);

        }


    }
}
