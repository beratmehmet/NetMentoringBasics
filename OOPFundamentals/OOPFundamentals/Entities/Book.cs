using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFundamentals.Entities
{
    internal class Book : Document
    {
        public int NumberOfPages { get; set; }

        public string Publisher;
        public Book(string title, string[] authors, DateTime datePublished, PublicationType publicationType, int numberOfPages, string publisher) : base(title, authors, datePublished, publicationType)
        {
            NumberOfPages = numberOfPages;
            Publisher = publisher;
        }
    }
}
