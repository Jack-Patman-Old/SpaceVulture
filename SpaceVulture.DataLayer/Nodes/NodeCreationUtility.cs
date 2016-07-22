using System;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SpaceVulture.DataLayer.Nodes
{
    public class NodeCreationUtility
    {
        public string GetNodeCreationCommand(Type t, string nodeName, IGraphNode node)
        {
            Type type = typeof(Order);
            string nodeType = node.GetType().Name;

            string attributesText = GetAttributesCreationText(type, node);
            return $"(`{nodeName}`:{nodeType} {{{attributesText}}})";
        }

       
        private string GetAttributesCreationText(Type type, IGraphNode node)
        {
            StringBuilder text = new StringBuilder();

            foreach (PropertyInfo prop in type.GetProperties())
            {
                string attributeKey = prop.Name;
                if (!attributeKey.Equals("Name", StringComparison.InvariantCultureIgnoreCase))
                {
                    object attributeValue = prop.GetValue(node, null);
                    if (attributeValue != null)
                    {
                        text.Append(prop == type.GetProperties().Last()
                            ? $"{attributeKey}:'{attributeValue}'"
                            : $"{attributeKey}:'{attributeValue}', ");
                    }
                }

            }

            return text.ToString();
        }
    }
}
