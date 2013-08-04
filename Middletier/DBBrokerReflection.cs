using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data.SqlClient;

namespace Middletier
{
    public class DBBrokerReflection
    {
        private SqlCommand comand;
        private SqlConnection connection;
        private int IDfield;

        #region Constructor
        public DBBrokerReflection(string connectionString)
        {
            this.connection = new SqlConnection(connectionString);
            this.comand = new SqlCommand { CommandType = System.Data.CommandType.Text, Connection = this.connection };
        }
        #endregion

        #region Query Methods
        public object SelectOneQuery(object dataObject)
        {
            object result = dataObject;

            Type objectType = dataObject.GetType();

            PropertyInfo[] allProps = objectType.GetProperties();

            SetValueForID(dataObject);//ubaci objekat

            string tableName = GetTableName(dataObject);
            string idcolumn = GetIDPropertyName(dataObject);

            string sqlQuery = "Select * FROM " + tableName + " WHERE " + idcolumn + " = " + IDfield;
            this.comand.CommandText = sqlQuery;
            this.connection.Open();

            try
            {
                SqlDataReader reader = this.comand.ExecuteReader();

                if (reader.Read())
                {
                    foreach (PropertyInfo t in allProps)
                    {
                        //for (int j = 0; j < reader.FieldCount; j++)
                        //{
                        //    if (t.Name.Equals(reader.GetName(j)))
                        //        t.SetValue(result, reader.GetOrdinal(reader.GetName(j)), null);
                        //}
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
            }
            finally
            {
                this.connection.Close();
            }

            return result;
        }

        public List<object> SelectAllQuery(object dataObject)
        {
            var resultList = new List<object>();

            Type objectType = dataObject.GetType();
            PropertyInfo[] properties = objectType.GetProperties();
            string tableName = GetTableName(dataObject);

            string sqlQuery = "SELECT * FROM " + tableName;
            this.connection.Open();
            this.comand.CommandText = sqlQuery;
            try
            {
                SqlDataReader reader = comand.ExecuteReader();

                while (reader.Read())
                {
                    object ob = new object();
                    ob = Activator.CreateInstance(objectType);
                    foreach (PropertyInfo propertyInfo in properties)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (propertyInfo.Name.Equals(reader.GetName(i)))
                            {
                                propertyInfo.SetValue(ob, reader.GetValue(i), null);
                                break;
                            }
                        }

                    }
                    resultList.Add(ob);
                }
            }
            finally
            {
                this.connection.Close();
            }
            return resultList;
        }

        public void InsertQuery(object ob)
        {
            Type obType = ob.GetType();
            PropertyInfo[] properties = ob.GetType().GetProperties();
            string tableName = GetTableName(ob);
            //string idcolumn = GetIDPropertyName(dataObject);

            string sqlQuery = "insert into " + tableName + " " + SetColumns(properties,ob) + " values (" + SetInsertQueryParameters(properties, ob) + ")";

            this.connection.Open();
            this.comand.Parameters.AddRange(SetSQLParameters(properties, ob));
            this.comand.CommandText = sqlQuery;

            try
            {
                int executeNonQuery = this.comand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string message = e.Message;
            }
            finally
            {
                this.connection.Close();
            }
        }

        private string SetUpdateQueryParameters(PropertyInfo[] props, object ob)
        {
            string result = "";
            foreach (PropertyInfo propertyInfo in props)
            {
                if (propertyInfo.GetCustomAttributes(true).Count() > 0)
                {
                    var att = propertyInfo.GetCustomAttributes(true)[0] as CodeAttribute;
                    if (!att.isID)
                    {
                        result += " " + propertyInfo.Name + " = @" + propertyInfo.Name + ",";
                    }
                }
            }
            result = result.Remove(result.LastIndexOf(','), 1);
            return result;
        }

        private string SetInsertQueryParameters(PropertyInfo[] props, object ob)
        {
            string result = "";
            foreach (PropertyInfo propertyInfo in props)
            {
                if (propertyInfo.GetCustomAttributes(true).Count() > 0)
                {
                    var att = propertyInfo.GetCustomAttributes(true)[0] as CodeAttribute;
                    if (!att.isID)
                    {
                        result += " " + "@" + propertyInfo.Name + ",";
                    }
                }
            }
            result = result.Remove(result.LastIndexOf(','), 1);
            return result;
        }

        private SqlParameter[] SetSQLParameters(PropertyInfo[] prop, object ob)
        {
            List<SqlParameter> result = new List<SqlParameter>();

            foreach (PropertyInfo propertyInfo in prop)
            {
                var parameter = new SqlParameter("@" + propertyInfo.Name, propertyInfo.GetValue(ob, null));
                result.Add(parameter);
            }
            return result.ToArray();
        }

        private string SetColumns(PropertyInfo[] prop, object ob)
        {
            string result = "(";

            foreach (PropertyInfo propertyInfo in prop)
            {
                var att = propertyInfo.GetCustomAttributes(true)[0] as CodeAttribute;
                if (!att.isID)
                {
                    result += propertyInfo.Name + ",";
                }                
            }
            result = result.Remove(result.LastIndexOf(','), 1)+")";

            return result;
        }

        public void UpdateQuery(object ob)
        {
            Type obType = ob.GetType();

            SetValueForID(ob);//ubaci obejakt

            PropertyInfo[] properties = ob.GetType().GetProperties();
            string tableName = GetTableName(ob);
            string idcolumn = GetIDPropertyName(ob);


            string sqlQuery = "update " + tableName + " set " + SetUpdateQueryParameters(properties, ob) + " where " + idcolumn + " = " + this.IDfield;

            this.connection.Open();
            this.comand.Parameters.AddRange(SetSQLParameters(properties, ob));
            this.comand.CommandText = sqlQuery;

            try
            {
                int executeNonQuery = this.comand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string message = e.Message;
            }
            finally
            {
                this.connection.Close();
            }
        }

        public void DeleteQuery(object ob)
        {
            Type obType = ob.GetType();
            SetValueForID(ob); //ubaci objekat
            PropertyInfo[] properties = ob.GetType().GetProperties();
            string tableName = GetTableName(ob);
            string idcolumn = GetIDPropertyName(ob);
            //SetValueForID(obType);

            string sqlQuery = "delete from " + tableName + " where " + idcolumn + "= " + this.IDfield;

            this.connection.Open();
            this.comand.CommandText = sqlQuery;

            try
            {
                int executeNonQuery = this.comand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                string message = e.Message;
            }
            finally
            {
                this.connection.Close();
            }
        }

        private void SetValueForID(object ob)
        {
            Type objectType = ob.GetType();
            PropertyInfo[] allProps = objectType.GetProperties();

            for (int i = 0; i < allProps.Length; i++)
            {
                //if (allProps[i].Name.Equals("" + objectType.Name + "ID"))
                //{
                //    this.IDfield = (int)allProps[i].GetValue(objectType, null);
                //}
                if (allProps[i].GetCustomAttributes(true).Count() > 0)
                {
                    var att = allProps[i].GetCustomAttributes(true)[0] as CodeAttribute;

                    if (att.isID)
                    {
                        IDfield = (int)allProps[i].GetValue(ob, null);
                    }
                }
            }
        }

        #endregion

        private string GetTableName(object ob)
        {
            string result = "";
            Type obType = ob.GetType();
            List<PropertyInfo> pi = obType.GetProperties().ToList().Where(x => x.Name.Equals(GetIDPropertyName(ob))).ToList();
            var attributes = pi.First().GetCustomAttributes(true)[0] as CodeAttribute;

            result = attributes.tableName;

            return result;
        }

        private string GetIDPropertyName(object ob)
        {
            Type type = ob.GetType();

            string result = (string)type.GetMethod("GetIDPropertyName").Invoke(null, null);
            return result;
        }
    }
}
