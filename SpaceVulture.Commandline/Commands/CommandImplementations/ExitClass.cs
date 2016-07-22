using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceVulture.Commandline.Commands.CommandImplementations
{
    public class ExitClass : ICommand
    {
        public void Execute(string[] Params = null)
        {
            System.Environment.Exit(1);
        }
    }
}
