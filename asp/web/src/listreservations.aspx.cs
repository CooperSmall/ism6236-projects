using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using smalldblib;

namespace smallasg5
{
    public partial class listreservations : System.Web.UI.Page
    {
        Reservation r = new Reservation();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text.Length > 0)
            {
                ListBox1.Items.Clear();
                try
                {
                    int cid = Int32.Parse(TextBox1.Text);
                    List<String> res = r.ListReservations(cid);
                    foreach (String s in res)
                        ListBox1.Items.Add(s);
                }
                catch (Exception)
                {
                    TextBox1.Text = String.Empty;
                    Response.Write(@"<script language='javascript'>alert('Please Enter a valid ID')</script>");
                }
            }
            else
            {
                Response.Write(@"<script language='javascript'>alert('Please Enter an ID')</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}