using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Data.SqlClient;
using Code_Generation;

namespace Middletier
{
    public class DBAdmin
    {
        public string connectionString;
        public SqlCommand cmd;
        public SqlConnection connection;//= new SqlConnection(connectionString);

        public DBAdmin(string connectionString)
        {
            connection = new SqlConnection(connectionString);
            cmd = new SqlCommand();
        }

        public void ExecuteSaveProcedure(object ob)
        {
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Insert" + GetTableName(ob);

                connection.Open();

                Type obType = ob.GetType();
                PropertyInfo[] props = obType.GetProperties();
                List<PropertyInfo> lp = props.ToList();
                #region demo
                //int idProp = 0;


                //MethodInfo mInfo = obType.GetMethod("GetIDField");
                //int resultIDValue = (int)mInfo.Invoke(ob, null);
                //var retType = mInfo.ReturnType.Name;



                /*                 
                  foreach (var property in props)
                {
                    property.GetValue(ob,null);
                    string propName = property.Name;

                    var att = property.GetCustomAttributes(true);
                    var j = att[0];
                    if (j is CodeAttribute)
                    {
                        var codeAttribute = j as CodeAttribute;
                        string tableName = codeAttribute.tableName;
                        string columnName = codeAttribute.columnName;
                    }
                }                 
                 */
                #endregion

                List<PropertyInfo> templp = lp.Where(x => !x.Name.Equals(GetIDPropertyName(ob))).ToList();
                props = templp.ToArray();


                SqlParameter[] parameters = new SqlParameter[props.Count()];

                for (int i = 0; i < props.Count(); i++)
                {
                    if (props[i].GetCustomAttributes(true).Count() > 0)
                    {
                        var att = props[i].GetCustomAttributes(true)[0] as CodeAttribute;
                        parameters[i] = new SqlParameter(att.columnName, props[i].GetValue(ob, null));
                    }
                }

                cmd.Parameters.AddRange(parameters);
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }

            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        private string GetIDPropertyName(object ob)
        {
            Type type = ob.GetType();

            string result = (string)type.GetMethod("GetIDPropertyName").Invoke(null, null);
            return result;
        }

        private string GetTableName(object ob)
        {
            string result = "";
            Type obType = ob.GetType();
            List<PropertyInfo> pi= obType.GetProperties().ToList().Where(x => x.Name.Equals(GetIDPropertyName(ob))).ToList();
            var attributes = pi.First().GetCustomAttributes(true)[0] as CodeAttribute;

            result = attributes.tableName;

            return result;
        }

        public void ExecuteUpdateProcedure(object ob)
        {
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Update";// +tableName;

                Type objType = ob.GetType();
                PropertyInfo[] props = objType.GetProperties();

                SqlParameter[] param = new SqlParameter[props.Count()];

                for (int i = 0; i < props.Count(); i++)
                {
                    if (props[i].GetCustomAttributes(true).Count() > 0)
                    {
                        var att = props[i].GetCustomAttributes(true)[0] as CodeAttribute;
                        param[i] = new SqlParameter(att.columnName, props[i].GetValue(ob, null));

                        if (att.isID)
                        {
                            cmd.CommandText+=att.tableName;
                        }
                    }
                }

                connection.Open();
                cmd.Parameters.AddRange(param);
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public void ExecuteDeleteprocedure(object ob)
        {
            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Delete";// +tableName;

                Type obType = ob.GetType();
                PropertyInfo[] props = obType.GetProperties();
                SqlParameter sqlParam = new SqlParameter();

                for (int i = 0; i < props.Count(); i++)
                {
                    if (props[i].GetCustomAttributes(true).Count() > 0)
                    {
                        var att = props[i].GetCustomAttributes(true)[0] as CodeAttribute;

                        if (att.isID)
                        {
                            sqlParam = new SqlParameter(att.columnName, props[i].GetValue(ob, null));
                            cmd.CommandText += att.tableName;
                        }
                    }
                }
                cmd.Parameters.Add(sqlParam);
                connection.Open();
                cmd.Connection = connection;
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw e;
            }

            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public object ExecuteSelectOneProcedure(object ob)
        {
            object result = ob;

            Type objectType = ob.GetType();

            PropertyInfo[] allProps = objectType.GetProperties();

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectOne";// +tableName;
                cmd.Connection = this.connection;
                cmd.Connection.Open();

                PropertyInfo[] props = objectType.GetProperties();
                SqlParameter sqlParam = new SqlParameter();

                for (int i = 0; i < props.Count(); i++)
                {
                    if (props[i].GetCustomAttributes(true).Count() > 0)
                    {
                        var att = props[i].GetCustomAttributes(true)[0] as CodeAttribute;
                        if (att.isID)
                        {
                            sqlParam = new SqlParameter(att.columnName, props[i].GetValue(ob, null));
                            cmd.CommandText += att.tableName;
                        }
                    }
                }

                //DODAJ PARAMETAR ZA ID. NJEGA VADIS IZ OBJEKTA, POMOCU ACTIVATOR.CREATEINSTANCE NAPRAVI INSTANCU PA POZOVI METODU GETIDFIELD.
                cmd.Parameters.Add(sqlParam);
                SqlDataReader reader = this.cmd.ExecuteReader();

                if (reader.Read())
                {
                    foreach (PropertyInfo t in allProps)
                    {
                        for (int j = 0; j < reader.FieldCount; j++)
                        {
                            if (t.Name.Equals(reader.GetName(j)))
                            //promenio zbog imena svojstava kalse objekata: imaju _Property na kraju , pa to pravi problem. Promena u transformaciji za polja klase je resenje.
                            {
                                if (t.PropertyType == typeof(string))
                                {
                                    t.SetValue(result, reader.GetString(reader.GetOrdinal(reader.GetName(j))), null);
                                    break;
                                }

                                if (t.PropertyType == typeof(int))
                                {
                                    t.SetValue(result, reader.GetInt32(reader.GetOrdinal(reader.GetName(j))), null);
                                    break;
                                }
                                if (t.PropertyType == typeof(DateTime))
                                {
                                    t.SetValue(result, reader.GetDateTime(reader.GetOrdinal(reader.GetName(j))), null);
                                    break;
                                }
                                if (t.PropertyType == typeof(bool))
                                {
                                    t.SetValue(result, reader.GetBoolean(reader.GetOrdinal(reader.GetName(j))), null);
                                    break;
                                }

                                if (t.PropertyType == typeof(decimal))
                                {
                                    t.SetValue(result, reader.GetDecimal(reader.GetOrdinal(reader.GetName(j))), null);
                                    break;
                                }
                            }
                            //t.SetValue(result,reader.get);
                        }
                    }
                }

                return result;
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public List<object> ExecuteSelectAllProcedure(object ob, string tableName)
        {
            object result = ob;
            List<object> resultList = new List<object>();
            Type objectType = ob.GetType();

            PropertyInfo[] allProps = objectType.GetProperties();

            try
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SelectAll" + tableName;
                cmd.Connection = this.connection;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    object obj = new object();
                    obj = Activator.CreateInstance(objectType);
                    foreach (PropertyInfo propertyInfo in allProps)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            //if ((propertyInfo.Name.Substring(0, propertyInfo.Name.LastIndexOf('_'))).Equals(reader.GetName(i)))
                            //{
                            //    propertyInfo.SetValue(obj, reader.GetValue(i), null);
                            //    break;
                            //}
                            if (propertyInfo.Name.Equals(reader.GetName(i)))
                            {
                                propertyInfo.SetValue(obj, reader.GetValue(i), null);
                                break;
                            }
                        }

                    }
                    resultList.Add(obj);
                }
                return resultList;
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        public List<object> ExecuteSelectAllRefsProcedure(object ob, string tableName)
        {
            object result = ob;
            List<object> resultList = new List<object>();
            Type objectType = ob.GetType();

            PropertyInfo[] allProps = objectType.GetProperties();

            try
            {
                string sql = "select * from CHILD_TABLE where FOREIGN_KEY = "+"GETFOREIGNKEY(OB)";
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                cmd.Connection = this.connection;
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    object obj = new object();
                    obj = Activator.CreateInstance(objectType);
                    foreach (PropertyInfo propertyInfo in allProps)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {                            
                            if (propertyInfo.Name.Equals(reader.GetName(i)))
                            {
                                propertyInfo.SetValue(obj, reader.GetValue(i), null);
                                break;
                            }
                        }

                    }
                    resultList.Add(obj);
                }
                return resultList;
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }
    }
}
