
using Newtonsoft.Json;

namespace SpaceVulture.DataLayer.Nodes
{
    public class System : IGraphNode
    {
        [JsonProperty(PropertyName = "Name")]
        public string NodeName { get; set; }

        [JsonProperty(PropertyName = "SystemId")]
        public int SystemId { get; set; }

        [JsonProperty(PropertyName = "SystemName")]
        public string SystemName { get; set; }

        [JsonProperty(PropertyName = "Security")]
        public decimal SystemSecurity { get; set; }

        public string GetNodeCreationString()
        {
            return new NodeCreationUtility().GetNodeCreationCommand(GetType(), NodeName, this);
        }
    }
}
