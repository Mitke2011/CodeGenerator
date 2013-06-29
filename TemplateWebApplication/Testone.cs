using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TemplateWebApplication
{
    public class Testone
    {
        private string name;
        private static string staticName;
        public int ID { get; set; }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        
        public string Address { get; set; }

        public Testone(int id, string name, string adress)
        {
            this.ID = id;
            this.Name = name;
            this.Address = adress;
            staticName = Name;
        }

        public Testone()
        {
                
        }

        public static string getString()
        {
            return "ID";//name
        }
    }
}