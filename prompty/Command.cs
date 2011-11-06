using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prompty
{
    public abstract class Command
    {
        public Command() { }

        public bool Enabled = true;

        public abstract string Name();
        public abstract string BriefDescription();
        public abstract string FullDescription();
        public abstract string[] Aliases();

        
        
        public abstract void run(string[] options, string[] parameters);


        public bool isMatch(string input)
        {
            return Name() == input || Aliases().Contains(input);
        }
            




        /*
        public CommandTemplate(string name, Action<string> cmd, string info)
        {
            Name = name;
            Info = info;
            Command = cmd;
        }*/
    }
}
