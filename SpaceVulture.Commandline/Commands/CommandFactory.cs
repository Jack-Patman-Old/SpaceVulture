using SpaceVulture.Commandline.Commands.CommandImplementations;

namespace SpaceVulture.Commandline.Commands
{
    public class CommandFactory
    {
        public static void ExecuteCommand(Command command, string[] parameters)
        {
            switch (command)
            {
                case Command.Exit:
                    new ExitClass().Execute(parameters);
                    break;
                case Command.SList:
                    new SListCommand().Execute(parameters);
                    break;
                case Command.FList:
                    new FListCommand().Execute(parameters);
                    break;
                case Command.Help:
                    new HelpCommand().Execute(parameters);
                    break;
            }
        }
    }
}
