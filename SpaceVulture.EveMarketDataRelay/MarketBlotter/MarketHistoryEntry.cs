using System;
using System.Security.Cryptography;
using System.Text;

namespace SpaceVulture.EveMarketDataRelay.MarketBlotter
{
    public class MarketHistoryEntry
    {
        public DateTime SettlementDate { get; set; }
        public int Orders { get; set; }
        public int Quantity { get; set; }
        public int ItemId { get; set; }
        public int RegionId { get; set; }


        public decimal LowestPrice { get; set; }
        public decimal HighestPrice { get; set; }
        public decimal SettlementPrice { get; set; }
        public decimal OpenPrice { get; set; }

        public Guid BlotterKey => CreateBlotterKey($"{SettlementDate}{ItemId}{RegionId}");

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
