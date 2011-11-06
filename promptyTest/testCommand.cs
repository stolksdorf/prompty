using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using prompty;

namespace promptyTest
{
    class testCommand : Command
    {
        public override string Name()
        {
            return "test";
        }

        public override string BriefDescription()
        {
            return "Just a test command"; 
        }

        public override string[] Aliases()
        {
            return new string[] {"t", "test"} ;
        }

        public override string FullDescription()
        {
            return "Full description";
        }

        public override void run(string[] options, string[] parameters)
        {
            Console.WriteLine("I'm a test!");
        }


    }
}
