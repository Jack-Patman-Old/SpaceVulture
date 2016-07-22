using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using SpaceVulture.Core.Errors;
using SpaceVulture.Core.Utility.Extensions;
using SpaceVulture.EveMarketDataRelay.MarketBlotter;
using ZMQ;
using Context = ZMQ.Context;
using MarketHistoryRoot = SpaceVulture.EveMarketDataRelay.MarketFeed.Json.MarketHistoryRoot;
using MarketOrderJson = SpaceVulture.EveMarketDataRelay.MarketFeed.Json.MarketOrderJson;
using SocketType = ZMQ.SocketType;

namespace SpaceVulture.EveMarketDataRelay.MarketFeed
{
    public class MarketHistoryFeed
    {
        public static bool StopListening;

        public void Subscribe(MarketHistoryBlotter persister, string relayAddress)
        {
            StopListening = true;
            Task.Run(() =>
            {
                using (Context context = new Context())
                {
                    using (Socket subscriber = context.Socket(SocketType.SUB))
                    {
                        try
                        {
                            subscriber.Connect(relayAddress);
                        }
                        catch (ZMQ.Exception ex)
                        {
                            Console.WriteLine(Error.EmdrRelayNotReachable.Message(new object[] { relayAddress, ex.Message }));
                        }
                        subscriber.SetSockOpt(SocketOpt.SUBSCRIBE, Encoding.UTF8.GetBytes(""));
                        while (StopListening)
                        {
                            try
                            {
                                byte[] receivedData = subscriber.Recv();
                                byte[] decompressed;
                                byte[] choppedRawData = new byte[(receivedData.Length - 4)];
                                Array.Copy(receivedData, choppedRawData, choppedRawData.Length);
                                choppedRawData = choppedRawData.Skip(2).ToArray();
                                using (MemoryStream inStream = new MemoryStream(choppedRawData))
                                using (MemoryStream outStream = new MemoryStream())
                                {
                                    DeflateStream outZStream = new DeflateStream(inStream, CompressionMode.Decompress);
                                    outZStream.CopyTo(outStream);
                                    decompressed = outStream.ToArray();
                                }

                                string marketJson = Encoding.UTF8.GetString(decompressed);


                                JavaScriptSerializer serializer = new JavaScriptSerializer();

                                try
                                {
                                    if (marketJson.Contains("\"resultType\":\"Orders\""))
                                    {
                                        MarketOrderJson.MarketOrderRoot marketOrder = serializer.Deserialize<MarketOrderJson.MarketOrderRoot>(marketJson);
                                        persister.AddMarketOrderRecord(marketOrder);
                                    }
                                    else if ((marketJson.Contains("\"resultType\":\"History\"")))
                                    {
                                        MarketHistoryRoot historicalRecord = serializer.Deserialize<MarketHistoryRoot>(marketJson);
                                        historicalRecord.OriginalJson = marketJson;
                                        persister.AddMarketHistoryRecord(historicalRecord);                                        
                                    }

                                }
                                catch (ArgumentException ex)
                                {
                                    Console.WriteLine(
                                        Error.MarketFeedParseError.Message(new object[] { marketJson, ex.Message }));
                                }
                                catch (InvalidOperationException ex)
                                {
                                    Console.WriteLine(
                                        Error.MarketFeedParseError.Message(new object[] { marketJson, ex.Message, }));

                                }

                            }
                            catch (ZMQ.Exception ex)
                            {
                                Console.WriteLine(Error.MarketFeedUncaughtError.Message(new object[] { ex.Message }));
                            }
                        }

                    }
                }
            });
        }
    }
}
