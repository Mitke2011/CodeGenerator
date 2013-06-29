
                using System;
                using System.Collections.Generic;
                using System.Linq;
                using System.Web;
                using System.Web.UI;
                using System.Web.UI.WebControls;
                using Middletier;

                namespace WebUI
                {
                public partial class KupacList : System.Web.UI.Page
                {
                
        protected void Page_Load(object sender, EventArgs e)
        {
            MiddletierManager mm = new MiddletierManager();
            List<Kupac> lt = new List<Kupac>();
            
            foreach (Kupac item in mm.FindAll((new Kupac()),"Kupac",true))
            {
                lt.Add(item);
            }
            
            this.GridView1.DataSource = lt;
            this.GridView1.DataBind();
        }
    
        protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            

        int a = -1;
        if (int.TryParse(e.CommandArgument.ToString(),out a) && (e.CommandName.Equals("Edit") || e.CommandName.Equals("Delete")))
        {
        if (a>=0)
        {
        GridViewRow row = GridView1.Rows[a];
        int columnidex = GetColumnIndex(row, Kupac.GetIDPropertyName());
        string tekst = this.GridView1.Rows[a].Cells[columnidex].Text;
        Response.Redirect("KupacEdit.aspx?objectid=" + tekst);
        }
        }
        else
        {
        Response.Redirect("KupacEdit.aspx");
        }

        }
    

                private int GetColumnIndex(GridViewRow row, string columnName)
                {
                int columnindex = 0;
                foreach (DataControlFieldCell c in row.Cells)
                {
                if (c.ContainingField is BoundField)
                {
                if ((c.ContainingField as BoundField).DataField.Equals(columnName))
                {
                break;
                }
                }
                columnindex++;
                }
                return columnindex;
                }
                protected void GridView1_OnRowCreated(object sender, GridViewRowEventArgs e)
                {
                e.Row.Cells[2].Visible = false;
                }
                }
                }

            