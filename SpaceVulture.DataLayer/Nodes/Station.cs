
using Newtonsoft.Json;

namespace SpaceVulture.DataLayer.Nodes
{
    public class Station : IGraphNode
    {
        [JsonProperty(PropertyName = "Name")]
        public string NodeName { get; set; }

        [JsonProperty(PropertyName = "StationId")]
        public int StationId { get; set; }

        [JsonProperty(PropertyName = "StationName")]
        public string StationName { get; set; }
        
        public string GetNodeCreationString()
        {
            return new NodeCreationUtility().GetNodeCreationCommand(GetType(), NodeName, this);
        }
    }
}
