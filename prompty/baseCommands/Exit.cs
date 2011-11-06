using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prompty.baseCommands
{
    class Exit : Command
    {
        
        public override string Name()
        {
            return "exit";
        }
        public override string BriefDescription()
        {
            return "Exits out of the shell";
        }

        public override string[] Aliases()
        {
            return new string[] { "q", "quit"};
        }

        public override string FullDescription()
        {
            return "Exits out of the shell";
        }

        public override void run(string[] options, string[] parameters)
        {
            Schema.exitOnTrue = true;
        }
    }
}
