using SpaceVulture.Core.Utility.Extensions;
using System;
using System.ComponentModel;

namespace SpaceVulture.Core.Errors
{

    public enum Error
    {
        [Description("An exception occurred when attempting to convert data returned from the Eve market data feed to Json, Json was {0}, exception was {1}")] MarketFeedParseError = 0,
        [Description("An uncaught exception occured during retrieval of the Eve Market data feed, exception was {0}")] MarketFeedUncaughtError = 1,
        [Description("An eve market data feed was unreachable, the relay address was {0}, the exception was {1}")] EmdrRelayNotReachable = 2
    }
}
