using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TypeLib;

namespace Code_Generation
{
    public interface IBusinessClassGenerator:IAbstractGenerator
    {
        void GenerateSingularProperty(string typeName, PropertyDefinition pDef, TextWritter tw);
        void GenerateListProperty(PropertyDefinition pDef, TextWritter tw);
        void GenerateProperty(PropertyDefinition pDef, TextWritter tw);
        void GenerateIDProperty(PropertyDefinition pDef, TextWritter tw);
        string GetTypeName(PropertyDefinition pDef);
    }
}
