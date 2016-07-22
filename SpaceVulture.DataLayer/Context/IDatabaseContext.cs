using System.Threading.Tasks;
using SpaceVulture.DataLayer.Nodes;

namespace SpaceVulture.DataLayer.Context
{
    public interface IDatabaseContext
    {
        Task CreateNode(IGraphNode node);
    }
}
