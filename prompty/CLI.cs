using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prompty
{
    public class CLI
    {
        private string prompt;

        public CLI(string promptName)
        {
            prompt = promptName;
            //Add on the base Commands
            Schema.Commands.Add(new baseCommands.Clear());
            Schema.Commands.Add(new baseCommands.manPage());
            Schema.Commands.Add(new baseCommands.Exit());
        }

        public void AddCommand(Command cmd)
        {
            Schema.Commands.Add(cmd);
        }

        public void RunConsole()
        {
            string rawInput = "";
            while (!Schema.exitOnTrue)
            {
                Console.Write("$"+prompt+"> ");
                rawInput = Console.ReadLine();

                ParseResult input = parseRawInput(rawInput);

                bool cmdValid = false;
                foreach (Command cmd in Schema.Commands)
                {
                    if (cmd.isMatch(input.cmd) && cmd.Enabled)
                    {
                        cmdValid = true;
                        cmd.run(input.options, input.parameters);
                        break;
                    }
                }

                //Unrecognized Command
                if (!cmdValid && input.cmd != "")
                    Console.WriteLine("Command not recognized: {0}", input.cmd);

                Console.WriteLine("");
            }
        }

        //Takes in a raw input and converts it into a commnd, options and parameters
        private ParseResult parseRawInput(string rawInput)
        {
            ParseResult result = new ParseResult();
            List<string> options = new List<string>();
            List<string> parameters = new List<string>();

            //extract out the command name
            result.cmd = rawInput.TrimStart(' ').Split(' ')[0];

            rawInput = rawInput.Substring(result.cmd.Length);
            string[] parts = rawInput.TrimStart(' ').Split(' ');

            bool isString = false;
            string tempString = "";

            foreach (string part in parts)
            {
                if (part.StartsWith("-"))
                    options.Add(part.Substring(1));
                else if (part.Length > 1)
                {
                    //handles if the user enters a string as a parameter
                    if (part.StartsWith('"'.ToString()) && !isString)
                    {
                        isString = true;
                        tempString = part;
                    }
                    else if (isString && part.EndsWith('"'.ToString()))
                    {
                        isString = false;
                        parameters.Add(tempString + " " + part);
                    }
                    else if (isString)
                        tempString += " " + part;

                    //handles everything else
                    else
                        parameters.Add(part);
                }

            }
            result.options = options.ToArray();
            result.parameters = parameters.ToArray();
            return result;
        }
    }
}
