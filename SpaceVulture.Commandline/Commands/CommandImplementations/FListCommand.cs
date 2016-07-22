using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceVulture.Core.MarketFeed;

namespace SpaceVulture.Commandline.Commands.CommandImplementations
{
    public class FListCommand : ICommand
    {
        public void Execute(string[] Params = null)
        {
            MarketHistoryFeed.StopListening = false;
        }
    }
}
