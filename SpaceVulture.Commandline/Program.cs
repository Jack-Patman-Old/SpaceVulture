using System;
using System.Linq;
using SpaceVulture.Commandline.Commands;
using SpaceVulture.DataLayer.Context;
using SpaceVulture.DataLayer.Enums;
using SpaceVulture.DataLayer.Nodes;

namespace SpaceVulture.Commandline
{
    public class Program
    {
        private static Command command;

        public static void Main()
        {
            Order order = new Order(guid, 10, new DateTime(),  ActivityType.Buy, 10);
            DatabaseContext context = new DatabaseContext();
            context.CreateNode(order);
            //while (command != Command.Exit)
            //{
            //    string input = Console.ReadLine();
            //    string[] terms = input.Split(' ');
            //    if (terms.Any() && terms[0].StartsWith("/"))
            //    {
            //        terms[0] = terms[0].Replace("/", "");
            //        if (Enum.TryParse(terms[0], true, out command))
            //        {
            //            command.ExecuteCommand(terms);
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine($"Input {input} is unrecognized, please type /help for a list of commands");
            //    }
            //}
        }
    }
}
