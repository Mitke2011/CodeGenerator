using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data.SqlClient;

namespace Database_Access_Generator
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
            this.comand = new SqlCommand {CommandType = System.Data.CommandType.Text, Connection = this.connection};
        }
        #endregion

        #region Query Methods
        public object SelectOneQuery(object dataObject)
        {
            object result = dataObject;

            Type objectType = dataObject.GetType();

            PropertyInfo[] allProps = objectType.GetProperties();
          
            SetValueForID(objectType);
            
            string sqlQuery = "Select * FROM " + objectType.Name + " WHERE " + objectType.Name + "ID = " + IDfield;
            this.comand.CommandText = sqlQuery;
            this.connection.Open();

            try
            {
                SqlDataReader reader = this.comand.ExecuteReader();

                if (reader.HasRows)
                {
                    foreach (PropertyInfo t in allProps)
                    {
                        for (int j = 0; j < reader.FieldCount; j++)
                        {
                            if (t.Name.Equals(reader.GetName(j)))
                                t.SetValue(result, reader.GetOrdinal(reader.GetName(j)), null);
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

            string sqlQuery = "SELECT * FROM " + dataObject.GetType().Name; ;
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

            string sqlQuery = "insert into " + obType.Name + " values (" + SetQueryParameters(properties, ob) + ")";

            this.connection.Open();
            this.comand.Parameters.AddRange(SetSQLParameters(properties,ob));
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

        private string SetQueryParameters(PropertyInfo[] prop, object ob)
        {
            string result = "";
            foreach (PropertyInfo propertyInfo in prop)
            {
                //var parameter = new SqlParameter("@" + propertyInfo.Name, propertyInfo.GetValue(ob, null));
                //result += " " + propertyInfo.Name + " = " + parameter.ParameterName + ",";
                result += " " + propertyInfo.Name + " = @" + propertyInfo.Name + ",";
            }
            result.Remove(result.LastIndexOf(','));
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

        public void UpdateQuery(object ob)
        {
            Type obType = ob.GetType();

            SetValueForID(obType);

            PropertyInfo[] properties = ob.GetType().GetProperties();

            //SetValueForID(obType);

            string sqlQuery = "update " + obType.Name + " set " + SetQueryParameters(properties, ob) + " where "+obType.Name+" ID "+" = "+this.IDfield;

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
            SetValueForID(obType);
            PropertyInfo[] properties = ob.GetType().GetProperties();

            //SetValueForID(obType);

            string sqlQuery = "delete from " + obType.Name +  " where " + obType.Name + " ID " + "= " + this.IDfield;

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

        private void SetValueForID(Type objectType)
        {
            PropertyInfo[] allProps = objectType.GetProperties();

            for (int i = 0; i < allProps.Length; i++)
            {
                if (allProps[i].Name.Equals("" + objectType.Name + "ID"))
                {
                    this.IDfield = (int)allProps[i].GetValue(objectType, null);
                }
            }
        }

        #endregion
    }
}
