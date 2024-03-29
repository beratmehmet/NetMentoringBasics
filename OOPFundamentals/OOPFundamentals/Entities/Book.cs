﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OOPFundamentals.Entities
{
    internal class Book : Document
    {
        [JsonPropertyName("numberOfPages")]
        public int NumberOfPages { get; set; }

        [JsonIgnore]
        public override Type _documentType => typeof(Book);

        [JsonPropertyName("publisher")]
        public string Publisher;

        public Book(
            string title, 
            List<string> authors, 
            DateTime datePublished, 
            int numberOfPages, 
            string publisher
            ) : base(title, authors, datePublished)
        {
            NumberOfPages = numberOfPages;
            Publisher = publisher;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nPublisher: {Publisher}\nNumber Of Pages: {NumberOfPages}";
        }
    }
}
