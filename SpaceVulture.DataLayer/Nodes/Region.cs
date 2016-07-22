
using Newtonsoft.Json;

namespace SpaceVulture.DataLayer.Nodes
{
    public class Region : IGraphNode
    {
        [JsonProperty(PropertyName = "Name")]
        public string NodeName { get; set; }

        [JsonProperty(PropertyName = "RegionId")]
        public int RegionId { get; set; }

        [JsonProperty(PropertyName = "RegionName")]
        public string RegionName { get; set; }


        public string GetNodeCreationString()
        {
            return new NodeCreationUtility().GetNodeCreationCommand(GetType(), NodeName, this);
        }
    }
}
