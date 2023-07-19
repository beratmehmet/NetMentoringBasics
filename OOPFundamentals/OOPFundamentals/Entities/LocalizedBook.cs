
namespace OOPFundamentals.Entities
{
    internal class LocalizedBook : Book
    {
        public string LocalPublisher { get; set; }

        public string CountryOfLocalization { get; set; }

        public LocalizedBook(string title, string[] authors, DateTime datePublished, PublicationType publicationType, int numberOfPages, string originalPublisher, string localPublisher, string countryOfLocalization) : base(title, authors, datePublished, publicationType, numberOfPages, originalPublisher)
        {
            LocalPublisher = localPublisher;
            CountryOfLocalization = countryOfLocalization;
        }
    }
}
