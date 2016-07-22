namespace SpaceVulture.DataLayer.Nodes
{
    public interface IGraphNode
    {
        string NodeName { get; set; }
        string GetNodeCreationString();
    }
}
