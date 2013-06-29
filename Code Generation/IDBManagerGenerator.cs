using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TypeLib;

namespace Code_Generation
{
    public interface IDBManagerGenerator : IAbstractGenerator
    {
        void CreateDeleteQuery(TextWritter indent);
        void CreateUpdateQuery(TextWritter indent);
        void CreateSelectSingleQuery(TextWritter indent);
        void CreateSelectAllQuery(TextWritter indent);
        void CreateInsertQuerry(TextWritter indent);
        void InitializeConnectionParameters(TextWritter indent);
    }
}
