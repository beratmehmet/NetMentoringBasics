using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OOPFundamentals.Entities
{
    internal class Patent : Document
    {
        [JsonIgnore]
        DateTimeOffset ExpirationDate { get; set; }

        [JsonIgnore]
        public override Type _documentType => typeof(Patent);

        public Patent(string title, string[] authors, DateTime datePublished, DateTime expirationDate) : base(title, authors, datePublished, 1)
        {
            ExpirationDate = expirationDate;
        }
    }
}
