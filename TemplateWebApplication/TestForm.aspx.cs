using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TemplateWebApplication
{
    public partial class TestForm : System.Web.UI.Page
    {
        private List<Testone> lt;
        protected void Page_Load(object sender, EventArgs e)
        {
            lt = new List<Testone>(new Testone[] { new Testone(1, "Stefan", "Kakanjska 17"), new Testone(2, "Nemanja", "Kakanjska 17"), new Testone(3, "Slavica", "Mrakovicka 41") });
           
                this.GridView1.DataSource = lt;
                this.GridView1.DataBind();
            
            
        }

        protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int a = int.Parse(e.CommandArgument.ToString());
            GridViewRow row = GridView1.Rows[a];
            int columnidex = GetColumnIndex(row, Testone.getString());
            string tekst = this.GridView1.Rows[a].Cells[columnidex].Text;//ID kolona, ime joj uzmi preko objekat.GetIDColumnNAme metode
            hdnID.Value = tekst;
            Response.Redirect("RedirectForm.aspx?objectid=" + hdnID.Value);//dodaj kolonu u URl kao parametar. Citaj ga preko String s = Request.QueryString["field1"];
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
    }
}