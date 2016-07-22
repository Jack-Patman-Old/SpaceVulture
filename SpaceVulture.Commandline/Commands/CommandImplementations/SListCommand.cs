
using SpaceVulture.Core.MarketBlotter;
using SpaceVulture.Core.MarketFeed;

namespace SpaceVulture.Commandline.Commands.CommandImplementations
{
    public class SListCommand : ICommand
    {
        public void Execute(string[] Params = null)
        {
            MarketHistoryBlotter persistanceService = new MarketHistoryBlotter();
            MarketHistoryFeed sub = new MarketHistoryFeed();
            sub.Subscribe(persistanceService, "tcp://relay-us-west-1.eve-emdr.com:8050");
            sub.Subscribe(persistanceService, "tcp://relay-us-central-1.eve-emdr.com:8050");
            sub.Subscribe(persistanceService, "tcp://relay-eu-germany-1.eve-emdr.com:8050");
            sub.Subscribe(persistanceService, "tcp://relay-eu-germany-2.eve-emdr.com:8050");
            sub.Subscribe(persistanceService, "tcp://relay-eu-germany-4.eve-emdr.com:8050");
            sub.Subscribe(persistanceService, "tcp://relay-eu-denmark-1.eve-emdr.com:8050");
        }
    }
}
