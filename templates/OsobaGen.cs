using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Linq;
using System.Text;

namespace Range
{
    
    
    public class Osoba
    {
        
        public Osoba()
        {
        }
        
        
        private Int32 IDField = 0;
        public Int32 ID
        {
            
            get
            {
                return IDField;
            }
            
            set
            {
                IDField = value;
            }
        }
        
        public Int32 GetIDProp
            {
            
            get
                {
                return this.ID;
                }
                
                }
            private String ImeField = null;
            public String Ime
            {
                
                get
                {
                    return ImeField;
                }
                
                set
                {
                    ImeField = value;
                }
            }
            
            private String PrezimeField = null;
            public String Prezime
            {
                
                get
                {
                    return PrezimeField;
                }
                
                set
                {
                    PrezimeField = value;
                }
            }
            
            
            }
            
            
        }
