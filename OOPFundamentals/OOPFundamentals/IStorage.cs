using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOPFundamentals.Entities;

namespace OOPFundamentals
{
    internal interface IStorage
    {
        public List<Document> Read();

        public void Write(Document document);

        public List<string> Search(int documentNumber);
    }
}
