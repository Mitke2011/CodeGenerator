using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TypeLib;

namespace Code_Generation
{
    public class JavaDBBrockerGenerator:IDBManagerGenerator
    {
        ObjectDefinition oDef;
        private TextWritter tw;
        private string SourceCode = null;
        private string connectionString;
        private string dbDriver;

        public JavaDBBrockerGenerator(string className, string connectionString, string dbDriver)
        {
            this.oDef = TypeLib.TypeManager.GetType(className);
            this.tw = new TextWritter();
            this.connectionString = connectionString;
            this.dbDriver = dbDriver;
        }

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
            tw.WriteLine("package {0};", oDef.ClassNamespace);
            tw.WriteLine();
            tw.WriteLine("import java.sql.Connection;");
            tw.WriteLine("import java.sql.DriverManager;");
            tw.WriteLine("import java.sql.PreparedStatement;");
            tw.WriteLine("import java.sql.ResultSet;");
            tw.WriteLine("import java.sql.SQLException;");
            tw.WriteLine("import java.sql.Statement;");
            tw.WriteLine("import java.util.ArrayList;");
            tw.WriteLine("import java.util.List;");
            tw.WriteLine("import java.util.logging.Level;");
            tw.WriteLine("import java.util.logging.Logger;");
            tw.WriteLine();
            tw.WriteLine("public class {0}DBManager", oDef.ClassName);
            tw.WriteLine("{");
            tw.WriteLine();
            GenerateClassBody(oDef, tw);
            tw.WriteLine();
            tw.WriteLine("}");

            SourceCode = tw.ToString();
        }

        public void GenerateClassBody(ObjectDefinition oDef, TextWritter tw)
        {
            tw.WriteLine("Connection dbConnection;");
            tw.WriteLine();
            InitializeConnectionParameters(tw);

            CreateDeleteQuery(tw);
            CreateUpdateQuery(tw);
            CreateSelectSingleQuery(tw);
            CreateSelectAllQuery(tw);
            CreateInsertQuerry(tw);
        }

        public void CreateDeleteQuery(TextWritter tw)
        {
            tw.WriteLine("public void DeleteSingle ({0} {1})",oDef.IDproperty().PropDataType,oDef.IDproperty().PropertyName);
            tw.WriteLine("{");
            tw.WriteLine("try {");
            tw.WriteLine("String query = " + '"' + "DELETE  FROM " + this.oDef.ClassName + " WHERE " + this.oDef.IDproperty().PropertyName + " = " + '"' + '+' + "{0}" + ";", this.oDef.IDproperty().PropertyName);
            tw.WriteLine("Statement sql = dbConnection.createStatement();");
            tw.WriteLine("sql.executeUpdate(query);");
            tw.WriteLine("}");
            tw.WriteLine("catch (SQLException ex)");
            tw.WriteLine("{");
            tw.WriteLine("Logger.getLogger(Avion.class.getName()).log(Level.SEVERE, null, ex);");
            tw.WriteLine("}");
            tw.WriteLine("}");
        }

        public void CreateUpdateQuery(TextWritter tw)
        {            
            string preparedStatement = "";
            
            foreach (PropertyDefinition prop in this.oDef.Property)
            {
                preparedStatement += prop.PropertyName + " = ? " + ",";
            }
            preparedStatement = preparedStatement.Remove(preparedStatement.LastIndexOf(','));

            tw.WriteLine("public void Update (" + this.oDef.ClassName + " value" + "){");

            tw.WriteLine("String sql =" + '"' + "UPDATE " + this.oDef.ClassName + " VALUES (" + preparedStatement + ") WHERE " + this.oDef.IDproperty().PropertyName + "=" + '"' + '+' + "value.get{0}" + ";", this.oDef.IDproperty().PropertyName);
            tw.WriteLine("try {");
            tw.WriteLine("PreparedStatement pstmt = dbConnection.prepareStatement(sql);");
            
            int counter = 1;
            foreach (PropertyDefinition prop in oDef.Property)
            {
                tw.WriteLine("pstmt.set" + prop.PropDataType + "(" + counter + "," + "value.get" + prop.PropertyName + "()" + ");");
                counter++;
            }

            tw.WriteLine("pstmt.executeUpdate();");
            tw.WriteLine("}");
            tw.WriteLine("catch (SQLException ex)");
            tw.WriteLine("{");
            tw.WriteLine("Logger.getLogger(Avion.class.getName()).log(Level.SEVERE, null, ex);");
            tw.WriteLine("}");
            tw.WriteLine("}");           
            tw.WriteLine("}");
        }

        public void CreateSelectSingleQuery(TextWritter tw)
        {
            tw.WriteLine("public " + this.oDef.ClassName + " SelectSingle ({0} {1})", oDef.IDproperty().PropDataType, oDef.IDproperty().PropertyName);
            tw.WriteLine("{");
            tw.WriteLine("{0} val = new {0}();",oDef.ClassName);
            tw.WriteLine("String sql = " + '"' + "SELECT * FROM " + oDef.ClassName + " WHERE " + oDef.IDproperty().PropertyName + " = "+ '"' +'+'+ oDef.IDproperty().PropertyName+";");
            tw.WriteLine("Statement query = dbConnection.createStatement();");
            tw.WriteLine("ResultSet res = query.executeQuery(sql);");
            tw.WriteLine("try {");
            tw.WriteLine("if(res.next()){");
            foreach (PropertyDefinition prop in oDef.Property)
            {
                tw.WriteLine("val.set{0}(res.get{1}("+'"'+"{0}"+'"'+"));",prop.PropertyName,prop.PropDataType);
            }
            tw.WriteLine("} else return null;");
            tw.WriteLine("}");
            tw.WriteLine("catch (SQLException ex)");
            tw.WriteLine("{");
            tw.WriteLine("Logger.getLogger(Avion.class.getName()).log(Level.SEVERE, null, ex);");
            tw.WriteLine("}");
            tw.WriteLine("return val;");
            tw.WriteLine("}");
        }

        public void CreateSelectAllQuery(TextWritter tw)
        {
            tw.WriteLine("public List<" + this.oDef.ClassName + ">" + " SelectAll ({0} {1})", oDef.IDproperty().PropDataType, oDef.IDproperty().PropertyName);
            tw.WriteLine("{");

            tw.WriteLine("List<{0}> listObj = new ArrayList<{0}>();", oDef.ClassName);
            tw.WriteLine("String sql = " + '"' + "SELECT * FROM " + oDef.ClassName + " WHERE " + oDef.IDproperty().PropertyName + " = " + '"' + '+' + oDef.IDproperty().PropertyName + ";");
            
            tw.WriteLine("try {");
            tw.WriteLine("Statement query = dbConnection.createStatement();");
            tw.WriteLine("ResultSet res = query.executeQuery(sql);");
            tw.WriteLine("while (res.next()){");
            tw.WriteLine("{0} val = new {0}();",oDef.ClassName);
            foreach (PropertyDefinition prop in oDef.Property)
            {
                tw.WriteLine("val.set{0}(res.get{1}(" + '"' + "{0}" + '"' + "));", prop.PropertyName, prop.PropDataType);
            }
            tw.WriteLine("listObj.add(val);");
            
            tw.WriteLine("}");
            tw.WriteLine("}");
            tw.WriteLine("catch (SQLException ex)");
            tw.WriteLine("{");
            tw.WriteLine("Logger.getLogger(Avion.class.getName()).log(Level.SEVERE, null, ex);");
            tw.WriteLine("}");
            tw.WriteLine("return listObj;");
            tw.WriteLine("}");
           
        }

        public void CreateInsertQuerry(TextWritter tw)
        {
            string tableColumns="";
            string preparedStatement="";
            foreach (PropertyDefinition prop in this.oDef.Property)
            {
                tableColumns += prop.PropertyName + ",";
                preparedStatement += "?" + ",";
            }

            tableColumns = tableColumns.Remove(tableColumns.LastIndexOf(','));
            preparedStatement = preparedStatement.Remove(tableColumns.LastIndexOf(','));

            //string sqlParameters = null;
            tw.WriteLine("public void Insert (" + this.oDef.ClassName + " value" + ")");
            tw.WriteLine("{");
            tw.WriteLine("String sql =" + '"'+"INSERT INTO "+this.oDef.ClassName+" ("+tableColumns+") VALUES ("+preparedStatement+")" + '"'+";");
            tw.WriteLine("try {");
            tw.WriteLine("PreparedStatement pstmt = dbConnection.prepareStatement(sql);");
            int counter = 1;
            foreach (PropertyDefinition prop in oDef.Property)
            {
                tw.WriteLine("pstmt.set"+prop.PropDataType+"("+counter+","+"value.get"+prop.PropertyName+"()"+");");
                counter++;
            }
            tw.WriteLine("pstmt.executeUpdate();");
            tw.WriteLine("}");
            tw.WriteLine("catch (SQLException ex)");
            tw.WriteLine("{");
            tw.WriteLine("Logger.getLogger(Avion.class.getName()).log(Level.SEVERE, null, ex);");
            tw.WriteLine("}");
            tw.WriteLine("}");
           
        }

        public void InitializeConnectionParameters(TextWritter tw)
        {
            tw.WriteLine("public void InitializeConnectionParams (){");
            //tw.Indent();
            
            tw.WriteLine("try {");
            //tw.OutDent();
            tw.WriteLine("Class.forName("+'"' + "{0}" + '"'+");",this.dbDriver);
            tw.WriteLine("}");
            tw.WriteLine("catch (ClassNotFoundException ex) {");
            tw.WriteLine("Logger.getLogger({0}.class.getName()).log(Level.SEVERE, null, ex);",oDef.ClassName);
            tw.WriteLine("}");
            tw.WriteLine();

            //tw.Indent();
            tw.WriteLine("try {");
            //tw.OutDent();
            tw.WriteLine("dbConnection = DriverManager.getConnection("+'"'+"{0}"+'"'+");",this.connectionString);
            tw.WriteLine("}");
            tw.WriteLine("catch (SQLException ex) {");
            tw.WriteLine("Logger.getLogger({0}.class.getName()).log(Level.SEVERE, null, ex);", oDef.ClassName);
            tw.WriteLine("}");
            tw.OutDent();
            tw.WriteLine("}");
        }
    }
}
