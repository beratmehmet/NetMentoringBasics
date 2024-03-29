﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OOPFundamentals.Entities
{
    public class Magazine : Document
    {
        [JsonPropertyName("releaseNumber")]
        public int ReleaseNumber { get; set; }

        public override Type _documentType => typeof(Magazine);

        public Magazine(
            string title,
            List<string> authors,
            DateTime datePublished,
            int releaseNumber
            ) : base(title, authors, datePublished)
        {
            ReleaseNumber = releaseNumber;
        }


        public override string ToString()
        {
            return base.ToString() + $"\nRelease Number: {ReleaseNumber}";
        }
    }
}
