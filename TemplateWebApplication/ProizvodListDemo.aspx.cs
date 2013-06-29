
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Middletier;

namespace TemplateWebApplication
{
    public partial class ProizvodListDemo : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            MiddletierManager mm = new MiddletierManager();
            List<ProizvodDemo> lt = new List<ProizvodDemo>();

            foreach (ProizvodDemo item in mm.FindAll((new ProizvodDemo()), "Proizvod", true))
            {
                lt.Add(item);
            }

            this.GridView1.DataSource = lt;
            this.GridView1.DataBind();
            //this.GridView1.Columns[0].Visible = false;
        }

        protected void GridView1_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            int a = -1;
            if (int.TryParse(e.CommandArgument.ToString(), out a))
            {
                if (a >= 0)
                {
                    GridViewRow row = GridView1.Rows[a];
                    int columnidex = GetColumnIndex(row, ProizvodDemo.GetIDPropertyName());
                    string tekst = this.GridView1.Rows[a].Cells[columnidex].Text;
                    if (e.CommandName.Equals("Edit"))
                    {
                        
                    }
                    Response.Redirect("ProizvodEdit.aspx?objectid=" + tekst);
                }
            }
            else
            {
                Response.Redirect("ProizvodEdit.aspx");
            }
            //int a = int.Parse(e.CommandArgument.ToString());
            //GridViewRow row = GridView1.Rows[a];
            //int columnidex = GetColumnIndex(row, Proizvod.GetIDPropertyName());
            //string tekst = this.GridView1.Rows[a].Cells[columnidex].Text;

            //Response.Redirect("ProizvodEdit.aspx?objectid=" + tekst);//dodaj kolonu u URl kao parametar. Citaj ga preko String s = Request.QueryString["objectid"];
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
