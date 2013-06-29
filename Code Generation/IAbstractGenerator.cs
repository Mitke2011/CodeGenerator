using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TypeLib;

namespace Code_Generation
{
    public interface IAbstractGenerator
    {
        void SaveCode(string Path);
        void Build();
        void GenerateClassBody(ObjectDefinition oDef, TextWritter indent);
    }
}
