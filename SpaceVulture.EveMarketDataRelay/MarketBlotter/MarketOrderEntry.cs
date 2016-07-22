using System;
using System.Security.Cryptography;
using System.Text;

namespace SpaceVulture.EveMarketDataRelay.MarketBlotter
{
    public class MarketOrderEntry
    {
        public decimal Price { get; set; }
        public int VolumeEntered { get; set; }
        public int VolumeRemaining { get; set; }
        public int Range { get; set; }
        public int OrderId { get; set; }
        public int MinimumVolume { get; set; }
        public bool Bid { get; set; }
        public DateTime IssueDate { get; set; }
        public int Duration { get; set; }
        public int StationId { get; set; }
        public int? SolarSystemId { get; set; }
        public int RegionId { get; set; }
        public int TypeId { get; set; }

        public Guid BlotterKey => CreateBlotterKey($"{OrderId}{IssueDate}");

        private Guid CreateBlotterKey(string input)
        {
            MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider();

            byte[] inputBytes = Encoding.Default.GetBytes(input);

            byte[] hashBytes = provider.ComputeHash(inputBytes);

            Guid hashGuid = new Guid(hashBytes);

            return hashGuid;

        }
    }
}
