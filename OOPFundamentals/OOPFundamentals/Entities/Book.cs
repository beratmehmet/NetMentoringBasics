using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OOPFundamentals.Entities
{
    internal class Book : Document
    {
        public int NumberOfPages { get; set; }

        [JsonIgnore]
        public override Type _documentType => typeof(Book);

        public string Publisher;

        public Book(string title, string[] authors, DateTime datePublished, int numberOfPages, string publisher) : base(title, authors, datePublished, 1)
        {
            NumberOfPages = numberOfPages;
            Publisher = publisher;
        }
    }
}
