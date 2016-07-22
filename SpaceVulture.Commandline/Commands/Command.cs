using System.Collections;
using System.Collections.Generic;

namespace SpaceVulture.Commandline.Commands
{
    public enum Command
    {
        SList,
        FList,
        Help,
        Exit        
    }

    public static class CommandExtensions
    {
        public static void ExecuteCommand(this Command command, string[] parameters = null)
        {
            CommandFactory.ExecuteCommand(command, parameters);
        }
    }
}
