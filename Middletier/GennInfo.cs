using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Middletier
{
    public class GennInfo
    {
        public string solutionname { get; set; }//setovano
        public string version { get; set; }
        public string VSLocation { get; set; }//setovano
        public string dbName { get; set; } //setovao
        public string dbServerName { get; set; }//setovao

        public string locationUI { get; set; }
        public string locationObj { get; set; }
        public string locationMid { get; set; }
        public string locationDom { get; set; }
        public string locationConfigFile { get; set; }

        public bool GenerateSP { get; set; }//setovano
        public bool GenerateUI { get; set; }//set
        public bool GenerateOb { get; set; }//setovano
        public bool GenereateDomain { get; set; }//setovano
        public bool GenerateSolution { get; set; }//setovano

        public string UiType { get; set; }
    }
}
