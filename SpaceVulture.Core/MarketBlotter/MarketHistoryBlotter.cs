using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using SpaceVulture.Core.MarketFeed.Json;

namespace SpaceVulture.Core.MarketBlotter
{
    public class MarketHistoryBlotter
    {
        public ConcurrentDictionary<Guid, MarketHistoryEntry> HistoricalPricesBlotter { get; }
        public ConcurrentDictionary<Guid, MarketOrderEntry> MarketOrdersBlotter { get; }

        public MarketHistoryBlotter()
        {
            this.HistoricalPricesBlotter = new ConcurrentDictionary<Guid, MarketHistoryEntry>();
            this.MarketOrdersBlotter = new ConcurrentDictionary<Guid, MarketOrderEntry>();
        }

        public void AddMarketHistoryRecord(MarketHistoryRoot marketHistoryJson)
        {
            foreach(Rowset itemHistory in marketHistoryJson.rowsets)
            {
                foreach(List<object> settlementEntry in itemHistory.rows)
                {
                    MarketHistoryEntry history = new MarketHistoryEntry
                    {
                        ItemId = itemHistory.typeID,
                        RegionId = itemHistory.regionID,
                        SettlementDate = Convert.ToDateTime(settlementEntry[0].ToString()),
                        Orders = int.Parse(settlementEntry[1].ToString()),
                        Quantity = int.Parse(settlementEntry[2].ToString()),
                        LowestPrice = decimal.Parse(settlementEntry[3].ToString()),
                        HighestPrice = decimal.Parse(settlementEntry[4].ToString()),
                        SettlementPrice = decimal.Parse(settlementEntry[5].ToString())
                    };

                    history.SettlementDate = history.SettlementDate.ToUniversalTime();

                    if (!this.HistoricalPricesBlotter.ContainsKey(history.BlotterKey))
                    {
                        Console.WriteLine($"{this.HistoricalPricesBlotter.Count} entries.");
                        this.HistoricalPricesBlotter.TryAdd(history.BlotterKey, history);                                            
                    }
                    else
                    {
                        Console.WriteLine("Duplicate entry managed");
                    }

                }
            }
        }


        public void AddMarketOrderRecord(MarketOrderJson.MarketOrderRoot marketOrder)
        {
            foreach (MarketOrderJson.Rowset itemHistory in marketOrder.rowsets)
            {
                foreach (List<object> settlementEntry in itemHistory.rows)
                {
                    MarketOrderEntry order = new MarketOrderEntry
                    {
                        TypeId = itemHistory.typeID,
                        RegionId = itemHistory.regionID,
                        Price = decimal.Parse(settlementEntry[0].ToString()),
                        Range = int.Parse(settlementEntry[1].ToString()),
                        OrderId = int.Parse(settlementEntry[2].ToString()),
                        VolumeEntered = int.Parse(settlementEntry[3].ToString()),
                        MinimumVolume = int.Parse(settlementEntry[4].ToString()),
                        Bid = bool.Parse(settlementEntry[5].ToString()),
                        IssueDate = Convert.ToDateTime(settlementEntry[6].ToString()),
                        Duration = int.Parse(settlementEntry[7].ToString()),
                        StationId = int.Parse(settlementEntry[8].ToString()),
                        SolarSystemId =  (settlementEntry[9]) as int?

                    };




                    order.IssueDate = order.IssueDate.ToUniversalTime();

                    if (!this.MarketOrdersBlotter.ContainsKey(order.BlotterKey))
                    {
                        Console.WriteLine($"{this.MarketOrdersBlotter.Count} entries.");
                        this.MarketOrdersBlotter.TryAdd(order.BlotterKey, order);
                    }
                    else
                    {
                        Console.WriteLine("Duplicate entry managed");
                    }

                }
            }
        }
    }
}
