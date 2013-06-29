using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TypeLib
{
   public class TypeManager
    {
        static Dictionary<string, ObjectDefinition> Types = new Dictionary<string, ObjectDefinition>();

        public static bool IsDefined(string TypeName)
        {
            return Types.ContainsKey(TypeName);
        }

        public static void RegisterType(ObjectDefinition oDef)
        {
            Types[oDef.ClassName] = oDef;
        }

        public static ObjectDefinition GetType(string TypeName)
        {
            if (IsDefined(TypeName))
                return Types[TypeName];

            throw new Exception(string.Format("Unknown fake type '{0}'", TypeName));
        }
    }
}
