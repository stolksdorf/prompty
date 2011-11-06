using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prompty.baseCommands
{
    class Clear : Command
    {
        public override string Name()
        {
            return "clear";
        }

        public override string BriefDescription()
        {
            return "Clears the console screen";
        }

        public override string[] Aliases()
        {
            return new string[] { "cls" };
        }

        public override string FullDescription()
        {
            return "Clears the console screen";
        }

        public override void run(string[] options, string[] parameters)
        {
            Console.Clear();
        }
    }
}
