using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UI
{
    public class Visual_Studio
    {
        string name { get; set; }
        string version { get; set; }

        public Visual_Studio(string name, string version)
        {
            this.name = name;
            this.version = version;
        }
    }
}
