using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using smalldblib;

namespace smallasg5
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Reservation r = new Reservation();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<String> cust = r.listCustomers();
            foreach (String s in cust)
                ListBox1.Items.Add(s);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("listreservations.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListAvailable1.aspx");
        }
    }
}