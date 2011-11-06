using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using prompty;

namespace promptyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            CLI newCLI = new CLI("prompty");

            newCLI.AddCommand(new testCommand());


            newCLI.RunConsole();


        }
    }
}
