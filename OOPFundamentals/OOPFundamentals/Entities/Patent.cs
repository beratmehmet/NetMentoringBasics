using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Transactions;

namespace OOPFundamentals.Entities
{
    internal class Patent : Document
    {
        [JsonPropertyName("expirationDate")]
        public DateTime ExpirationDate { get; set; }

        [JsonIgnore]
        public override Type _documentType => typeof(Patent);

        public Patent(
            string title,
            List<string> authors,
            DateTime datePublished,
            DateTime expirationDate) : base(title, authors, datePublished)
        {
            ExpirationDate = expirationDate;
        }

        public override string ToString()
        {
            return base.ToString() + $"\nExpiration Date: {ExpirationDate}";
        }
    }
}
