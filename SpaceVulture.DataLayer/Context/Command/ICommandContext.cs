using System.Threading.Tasks;
using SpaceVulture.DataLayer.Nodes;

namespace SpaceVulture.DataLayer.Context.Command
{
    public interface ICommandContext
    {
        Task CreateNode(IGraphNode node);
    }
}
