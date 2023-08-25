using OOPFundamentals.Entities;

namespace OOPFundamentals
{
    internal interface IStorage
    {
        public Document Read(string fileName);

        public void Write(Document document);

        public List<Document> Search(int documentNumber);
    }
}
