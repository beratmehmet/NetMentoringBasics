
using System.Text.Json.Serialization;

namespace OOPFundamentals.Entities
{
    internal class LocalizedBook : Book
    {
        public string LocalPublisher { get; set; }

        public string CountryOfLocalization { get; set; }

        [JsonIgnore]
        public override Type _documentType => typeof(LocalizedBook);

        public LocalizedBook(string title, string[] authors, DateTime datePublished, int numberOfPages, string originalPublisher, string localPublisher, string countryOfLocalization) : base(title, authors, datePublished, numberOfPages, originalPublisher)
        {
            LocalPublisher = localPublisher;
            CountryOfLocalization = countryOfLocalization;
        }
    }
}
