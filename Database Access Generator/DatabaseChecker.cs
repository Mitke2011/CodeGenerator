using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Database_Access_Generator
{
    public class DatabaseChecker
    {
        public static SqlCommand comand;
        public static SqlConnection connection;

        private string testText;
        private int testInt;

        public int TestInt
        {
            get { return testInt; }
            set { testInt = value; }
        }
        private bool testBool;

        public bool TestBool
        {
            get { return testBool; }
            set { testBool = value; }
        }

        public string TestText
        {
            get { return testText; }
            set { testText = value; }
        }

        static string conString = "Data Source=MITKE-PC;Initial Catalog=ASPBaza;Integrated Security=True";

        public static void InitParams()
        {
            connection = new SqlConnection(conString);
            comand = new SqlCommand();
            comand.CommandType = System.Data.CommandType.Text;
            comand.Connection = connection;
        }
    }
}
