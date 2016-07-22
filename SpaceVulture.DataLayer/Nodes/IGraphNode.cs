namespace SpaceVulture.DataLayer.Nodes
{
    public interface IGraphNode
    {
        string Name { get; set; }
        string GetNodeCreationString();
    }
}
