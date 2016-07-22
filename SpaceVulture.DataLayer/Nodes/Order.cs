using System;
using Newtonsoft.Json;
using SpaceVulture.DataLayer.Context.Enums;

namespace SpaceVulture.DataLayer.Nodes
{
    public class Order : IGraphNode
    {
        public Order(Guid orderId, int quantity, DateTime date, ActivityType type, int duration)
        {
            NodeName = orderId.ToString();
            Quantity = quantity;
            OrderType = type;
            Date = date;
            Duration = duration;
        }

        [JsonProperty(PropertyName = "NodeName")]
        public string NodeName { get; set; }

        [JsonProperty(PropertyName = "Date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "Quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "OrderType")]
        public ActivityType OrderType { get; set; }

        [JsonProperty(PropertyName = "Duration")]
        public int Duration { get; set; }

        public string GetNodeCreationString()
        {
            return new NodeCreationUtility().GetNodeCreationCommand(GetType(), NodeName, this);
        }
    }
}
