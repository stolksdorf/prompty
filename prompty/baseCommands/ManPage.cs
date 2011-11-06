using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prompty.baseCommands
{
    public class manPage : Command
    {
        public override string Name()
        {
            return "help";
        }
        public override string BriefDescription()
        {
            return "Displays all available commands or a command's manpage";
        }

        public override string[] Aliases()
        {
            return new string[] { "man", "h", "?" };
        }

        public override string FullDescription()
        {
            return "help without any parameters will display each command available, it's alaises and a brief description. " +
            "When given a parameter of a command name it will display its manpage which will cover each of it's aliases, " +
            "and a more in-depth description.";
        }

        public override void run(string[] options, string[] parameters)
        {
            if (parameters.Length == 0)
            {
                Console.WriteLine("List of Commands:");
                foreach (Command cmd in Schema.Commands)
                {
                    Console.Write("  ");
                    Console.WriteLine("{0} ({1}) : {2}", cmd.Name(), String.Join(",", cmd.Aliases()), cmd.BriefDescription());
                }
            }
            else
            {
                foreach (string parameter in parameters)
                {
                    bool found = false;
                    foreach (Command cmd in Schema.Commands)
                    {
                        if (cmd.isMatch(parameter))
                        {
                            Console.WriteLine("NAME");
                            Console.WriteLine("    {0} - {1}", cmd.Name(), cmd.BriefDescription());
                            Console.WriteLine("\nDESCRIPTION");
                            Console.WriteLine("    {0}", cmd.FullDescription());
                            found = true;
                        }
                    }
                    if (!found)
                        Console.WriteLine("Command not recognized");
                }
            }
        }
    }
}
