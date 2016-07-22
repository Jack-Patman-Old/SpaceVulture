using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SpaceVulture.Commandline.Commands.CommandImplementations
{
    public interface ICommand
    {
        void Execute(string[] Params);
    }
}
