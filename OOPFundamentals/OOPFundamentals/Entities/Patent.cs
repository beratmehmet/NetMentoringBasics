using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPFundamentals.Entities
{
    internal class Patent : Document
    {
        DateTimeOffset ExpirationDate { get; set; }

        public Patent(string title, string[] authors, DateTime datePublished, DateTime expirationDate) : base(title, authors, datePublished, PublicationType.Patent)
        {
            ExpirationDate = expirationDate;
        }
    }
}
