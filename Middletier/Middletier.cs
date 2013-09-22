using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
//using Database_Access_Generator;

namespace Middletier
{
    public class MiddletierManager
    {
        private DBAdmin dbManager; 
        private DBBrokerReflection dbb;
        private string serverName;
        private string dbName;

        public MiddletierManager()
        {
            LoadConfigurationSettings();
            this.dbManager = new DBAdmin("Data Source=" + serverName + ";Initial Catalog=" + dbName + ";Integrated Security=True");
            this.dbb = new DBBrokerReflection("Data Source=" + serverName + ";Initial Catalog=" + dbName + ";Integrated Security=True"); 
        }

        private void LoadConfigurationSettings()
        {
           string confiFileLocation = string.Format(@"{0}\Config.txt",Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
            string[] options = new string[15];
            using (StreamReader sr = new StreamReader(confiFileLocation))
            {
                string option = "";
                int index = 0;
                while ((option = sr.ReadLine()) != null)
                {
                    options[index] = option;
                    index++;
                }
            }

            foreach (var option in options)
            {
                if (option != null && !option.Equals(string.Empty))
                {
                    string optionName = option.Split('|')[0];
                    string optionValue = option.Split('|')[1];
                    switch (optionName)
                    {
                        case "Dbname":
                            this.dbName= optionValue;
                            break;
                        case "DBServerName":
                            this.serverName= optionValue;
                            break;
                    }
                }
            }
        }

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

        public List<object> FindAllReferenced(object ob, string tableName, string keyColumn, int parentID)
        {
            List<object> result;

            result = dbb.SelectAllRefs(ob, tableName, keyColumn, parentID);
            return result;
        }
    }
}
