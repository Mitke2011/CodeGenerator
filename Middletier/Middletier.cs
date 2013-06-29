using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Database_Access_Generator;

namespace Middletier
{
    public class MiddletierManager
    {
        DBAdmin dbManager = new DBAdmin("Data Source=MITKE-PC;Initial Catalog=ASPBaza;Integrated Security=True");
        DBBrokerReflection dbb = new DBBrokerReflection("Data Source=MITKE-PC;Initial Catalog=ASPBaza;Integrated Security=True");

        public void Save(object o, bool useSP)
        {
            if (useSP)
            {
                dbManager.ExecuteSaveProcedure(o);
            }
            else
            {
                dbb.InsertQuery(o);
            }
            
        }

        public void Update(object o, bool useSP)
        {
            if (useSP)
            {
                dbManager.ExecuteUpdateProcedure(o);
            }
            else
            {
                dbb.UpdateQuery(o);
            }
            
        }

        public void Delete(object o, bool useSP)
        {
            if (useSP)
            {
                dbManager.ExecuteDeleteprocedure(o);
            }
            else
            {
                dbb.DeleteQuery(o);
            }
            
        }

        public object FindOne(object ob, bool useSP)
        {
            object result;
            if (useSP)
            {
                result = dbManager.ExecuteSelectOneProcedure(ob);
                return result;
            }
            else
            {
               return result=dbb.SelectOneQuery(ob);
            }
            
        }

        public List<object> FindAll(object ob, string tableName,bool useSP)
        {
            List<object> result;
            if (useSP)
            {
                result = dbManager.ExecuteSelectAllProcedure(ob, tableName);
                return result;
            }
            else
            {
                result = dbb.SelectAllQuery(ob);
                return result;
            }
            
        }
    }
}
