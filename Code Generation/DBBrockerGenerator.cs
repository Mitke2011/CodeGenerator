using System.IO;
using TypeLib;
using System.Data.SqlClient;

namespace Code_Generation
{
    public class DBBrockerGenerator : IDBManagerGenerator
    {
        #region Fields
        ObjectDefinition oDef;
        string SourceCode = null;
        string connectionString;        
        public SqlCommand command;
        SqlConnection connection;
        #endregion
        
        #region Constructor
        public DBBrockerGenerator(string className, string constr)
        {
            this.oDef = TypeManager.GetType(className);
            this.connectionString = constr;
        }

        #endregion

        #region Class generation methods

        public void SaveCode(string path)
        {
            if (string.IsNullOrEmpty(SourceCode)) this.Build();

            StreamWriter sw = new StreamWriter(path);
            sw.Write(SourceCode);
            sw.Flush();
            sw.Close();
        }

        public void Build()
        {
            TextWritter indent = new TextWritter();
            
            indent.WriteLine("using System;");
            indent.WriteLine("using System.Collections.Generic;");
            indent.WriteLine("using System.Linq;");
            indent.WriteLine("using System.Web;");
            indent.WriteLine("using System.Data.SqlClient;");

            indent.WriteLine();
            indent.WriteLine("namespace {0}", this.oDef.ClassNamespace);
            indent.WriteLine("{");
            indent.Indent();

            GenerateClassBody(this.oDef, indent);
            
        }

       
        public void GenerateClassBody(ObjectDefinition oDef,TextWritter indent)
        {
            indent.WriteLine("public class {0}DBManager", this.oDef.ClassName);
            indent.WriteLine("{");
            indent.WriteLine();
            indent.WriteLine();
            
            indent.WriteLine("public static SqlCommand comand;");
            indent.WriteLine("public static SqlConnection connection;");
            indent.WriteLine(@"static string conString = " + '"' + connectionString + '"' + ";");
            indent.WriteLine();
            indent.WriteLine("public {0} ()DBManager", this.oDef.ClassName);
            indent.WriteLine("{");
            indent.WriteLine("}");
            indent.WriteLine();

            InitializeConnectionParameters(indent);

            CreateSelectAllQuery(indent);
            CreateSelectSingleQuery(indent);
            CreateUpdateQuery(indent);
            CreateInsertQuerry(indent);
            CreateDeleteQuery(indent);

            indent.WriteLine();
            indent.WriteLine("}");
            indent.WriteLine("}");
            SourceCode = indent.ToString();
        }

        public void InitializeConnectionParameters(TextWritter indent)
        {
            indent.WriteLine("public void InitializeConnectionParams ()");
            indent.WriteLine("{");
            indent.WriteLine();

            indent.WriteLine("connection = new SqlConnection(conString);");
            indent.WriteLine("comand = new SqlCommand();");
            indent.WriteLine("comand.CommandType = System.Data.CommandType.Text;");
            indent.WriteLine("comand.Connection = connection;");

            indent.WriteLine();
            indent.WriteLine("}");
        }

        #endregion

        #region Query Generation Methods
        public void CreateDeleteQuery(TextWritter indent)
        {
            indent.WriteLine("public void DeleteSingle ({0} {1})",oDef.IDproperty().PropDataType,oDef.IDproperty().PropertyName);
            indent.WriteLine("{");
            indent.WriteLine();
            indent.WriteLine("string sql = " + '"' + "DELETE  FROM " + this.oDef.ClassName + " WHERE " + this.oDef.IDproperty().PropertyName + " = " + '"' + '+' + "{0}" + ";", this.oDef.IDproperty().PropertyName);



            indent.Write("try");
            indent.Write("{");
            indent.WriteLine("InitializeConnectionParams ();");

            indent.WriteLine();
            indent.WriteLine("connection.Open();");
            indent.WriteLine("comand.CommandText = sql;");
            indent.WriteLine("comand.ExecuteNonQuery();");

            indent.WriteLine("}");
            indent.WriteLine("catch (Exception)");
            indent.WriteLine("{");
            indent.Write("throw;");
            indent.WriteLine("}");
            indent.WriteLine("finally");
            indent.WriteLine("{");
            indent.WriteLine("if (connection != null)");
            indent.WriteLine("connection.Close();");
            indent.WriteLine("}");
            indent.WriteLine();
            indent.WriteLine("}");
        }

        public void CreateUpdateQuery(TextWritter indent)
        {
            indent.WriteLine("public void Update (" + this.oDef.ClassName + " value" + ")");
            indent.WriteLine("{");
            indent.WriteLine();
            string tableColumns = null;

            foreach (PropertyDefinition prop in this.oDef.Property)
            {
                tableColumns += prop.PropertyName + ",";
            }

            tableColumns = tableColumns.Remove(tableColumns.LastIndexOf(','));
            string sqlParameters = null;

            foreach (PropertyDefinition prop in this.oDef.Property)
            {
                sqlParameters += prop.PropertyName + " = "+'@' + prop.PropertyName + ",";
            }

            sqlParameters = sqlParameters.Remove(sqlParameters.LastIndexOf(','));

            indent.Write("try");
            indent.Write("{");
            indent.WriteLine("string sql = " + '"' + "UPDATE " + this.oDef.ClassName + " SET (" + sqlParameters + " WHERE " + this.oDef.IDproperty().PropertyName + " = " + '"'+'+' + "value." + this.oDef.IDproperty().PropertyName + ";");
            indent.Indent();
            indent.WriteLine("InitializeConnectionParams ();");
            string sqlParametersArray = null;
            indent.WriteLine("SqlParameter[] parameters = new SqlParameter []  {");
            indent.Indent();
            foreach (PropertyDefinition propr in this.oDef.Property)
            {
                sqlParametersArray += "\n new SqlParameter(" + '"' + '@' + propr.PropertyName + '"' + "," + "value." + propr.PropertyName + "),";
            }

            sqlParametersArray = sqlParametersArray.Remove(sqlParametersArray.LastIndexOf(','));
            indent.Indent();
            indent.WriteLine(sqlParametersArray);
            indent.WriteLine("};");
            indent.WriteLine("comand.Parameters.AddRange(parameters);");
            indent.WriteLine("connection.Open();");
            indent.WriteLine("comand.CommandText = sql;");
            indent.WriteLine("comand.ExecuteNonQuery();");
            indent.WriteLine("}");
            indent.WriteLine("catch (Exception)");
            indent.WriteLine("{");
            indent.Write("throw;");
            indent.WriteLine("}");
            indent.WriteLine("finally");
            indent.WriteLine("{");
            indent.WriteLine("if (connection != null)");
            indent.WriteLine("connection.Close();");
            indent.WriteLine("}");
            indent.WriteLine();
            indent.WriteLine("}");
        }

        public void CreateSelectSingleQuery(TextWritter indent)
        {
            indent.WriteLine("public " + this.oDef.ClassName + " SelectSingle ({0} {1})",oDef.IDproperty().PropDataType,oDef.IDproperty().PropertyName);
            indent.WriteLine("{");
            indent.WriteLine();
            indent.WriteLine("string sql = " + '"' + "SELECT * FROM " + this.oDef.ClassName + " WHERE " + this.oDef.IDproperty().PropertyName + " = " + '"' + '+' + "{0}" + ";",oDef.IDproperty().PropertyName);

            indent.Write("try");
            indent.Write("{");
            indent.WriteLine("InitializeConnectionParams ();");

            indent.WriteLine();
            indent.WriteLine("connection.Open();");
            indent.WriteLine("comand.CommandText = sql;");
            indent.WriteLine("SqlDataReader reader = comand.ExecuteReader();");
            indent.WriteLine();
            indent.WriteLine(this.oDef.ClassName + " " + "obj = new " + this.oDef.ClassName + " ();");
            indent.WriteLine("while (reader.Read())");
            indent.WriteLine("{");

            foreach (PropertyDefinition prop in this.oDef.Property)
            {
                indent.WriteLine("obj." + prop.PropertyName + " = (" + prop.PropDataType + ")reader[" + '"' + prop.PropertyName + '"' + "];");
            }
            indent.WriteLine();
            indent.WriteLine("}");
            indent.WriteLine("return obj;");
            indent.WriteLine("}");
            indent.WriteLine("catch (Exception)");
            indent.WriteLine("{");
            indent.Write("throw;");
            indent.WriteLine("}");
            indent.WriteLine("finally");
            indent.WriteLine("{");
            indent.WriteLine("if (connection != null)");
            indent.Write("connection.Close();");
            indent.WriteLine("}");
            indent.WriteLine();
            indent.WriteLine("}");
        }

        public void CreateSelectAllQuery(TextWritter indent)
        {
            indent.WriteLine("public List<" + this.oDef.ClassName + ">" + " SelectAll ({0} {1})", oDef.IDproperty().PropDataType, oDef.IDproperty().PropertyName);
            indent.WriteLine("{");
            indent.WriteLine();
            indent.WriteLine("string sql = " + '"' + "SELECT * FROM " + this.oDef.ClassName + '"' + ';');
            indent.WriteLine("List<" + this.oDef.ClassName + ">  objList = new List<" + this.oDef.ClassName + ">()" + ";");

            indent.Write("try");
            indent.Write("{");
            indent.WriteLine("InitializeConnectionParams ();");

            indent.WriteLine();
            indent.WriteLine("connection.Open();");
            indent.WriteLine("comand.CommandText = sql;");
            indent.WriteLine("SqlDataReader reader = comand.ExecuteReader();");
            indent.WriteLine();

            indent.WriteLine("while (reader.Read())");
            indent.WriteLine("{");
            indent.WriteLine(this.oDef.ClassName + " objt = new " + this.oDef.ClassName + "()" + ';');
            foreach (PropertyDefinition prop in this.oDef.Property)
            {
                if (!prop.PropType.ToString().Equals(PropertyType.ListSimple.ToString("f")))
                {
                    indent.WriteLine("objt." + prop.PropertyName + " = (" + prop.PropDataType + ")reader[" + '"' + prop.PropertyName + '"' + "];");
                }
                else
                {
                    indent.WriteLine("objt." + prop.PropertyName + ".Add((" + prop.PropDataType + ")reader[" + '"' + prop.PropertyName + '"' + "]);");
                }
            }
            indent.WriteLine("objList.Add(objt);");
            indent.WriteLine();
            indent.WriteLine("}");
            indent.WriteLine("return objList;");
            indent.WriteLine("}");
            indent.WriteLine("catch (Exception)");
            indent.WriteLine("{");
            indent.Write("throw;");
            indent.WriteLine("}");
            indent.WriteLine("finally");
            indent.WriteLine("{");
            indent.WriteLine("if (connection != null)");
            indent.Write("connection.Close();");
            indent.WriteLine("}");
            indent.WriteLine();
            indent.WriteLine("}");

        }

        public void CreateInsertQuerry(TextWritter indent)
        {
            indent.WriteLine("public void Insert (" + this.oDef.ClassName + " value" + ")");
            indent.WriteLine("{");
            indent.WriteLine();
            string tableColumns = null;

            foreach (PropertyDefinition prop in this.oDef.Property)
            {
                tableColumns += prop.PropertyName + ",";
            }

            tableColumns = tableColumns.Remove(tableColumns.LastIndexOf(','));
            string sqlParameters = null;

            foreach (PropertyDefinition prop in this.oDef.Property)
            {
                sqlParameters += "@" + prop.PropertyName + ",";
            }

            sqlParameters = sqlParameters.Remove(sqlParameters.LastIndexOf(','));

            indent.Write("try");
            indent.Write("{");
            indent.WriteLine("string sql = " + '"' + "INSERT INTO " + this.oDef.ClassName + " (" + tableColumns + ") VALUES (" + sqlParameters + ")" + '"' + ";");
            indent.Indent();
            indent.WriteLine("InitializeConnectionParams ();");
            string sqlParametersArray = null;
            indent.WriteLine("SqlParameter[] parameters = new SqlParameter []  {");
            indent.Indent();
            foreach (PropertyDefinition propr in this.oDef.Property)
            {
                sqlParametersArray += "\n new SqlParameter(" + '"' + '@' + propr.PropertyName + '"' + "," + "value." + propr.PropertyName + "),";
            }

            sqlParametersArray = sqlParametersArray.Remove(sqlParametersArray.LastIndexOf(','));
            indent.Indent();
            indent.WriteLine(sqlParametersArray);
            indent.WriteLine("};");
            indent.WriteLine("comand.Parameters.AddRange(parameters);");
            indent.WriteLine("connection.Open();");
            indent.WriteLine("comand.CommandText = sql;");
            indent.WriteLine("comand.ExecuteNonQuery();");
            indent.WriteLine("}");
            indent.WriteLine("catch (Exception)");
            indent.WriteLine("{");
            indent.WriteLine("throw;");
            indent.WriteLine("}");
            indent.WriteLine("finally");
            indent.WriteLine("{");
            indent.WriteLine("if (connection != null)");
            indent.Write("connection.Close();");
            indent.WriteLine("}");
            indent.WriteLine();
            indent.WriteLine("}");
        }
        #endregion

        #region Database Table Managment
        private void CreateDBTable(string dbName, ObjectDefinition odef)
        {

        }
        #endregion
        
    }
}
