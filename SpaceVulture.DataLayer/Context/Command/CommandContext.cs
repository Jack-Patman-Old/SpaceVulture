using System;
using System.Threading.Tasks;
using System.Transactions;
using Neo4jClient;
using SpaceVulture.DataLayer.Nodes;

namespace SpaceVulture.DataLayer.Context.Command
{
    public class CommandContext : ICommandContext
    {
        public CommandContext()
        {
            this.TryConnect();
        }
        private GraphClient client;

        private bool TryConnect()
        {
            this.client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "Db101192");
            this.client.Connect();
            return this.client.IsConnected;
        }


        public async Task CreateNode(IGraphNode node)
        {
            try
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    try
                    {
                        string nodeCreationString = node.GetNodeCreationString();
                        this.client.Cypher.Create(nodeCreationString).ExecuteWithoutResults();
                        scope.Complete();
                    }
                    catch (Exception ex)
                    {

                        throw ex;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
