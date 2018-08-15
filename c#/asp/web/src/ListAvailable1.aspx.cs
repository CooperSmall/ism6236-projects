using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using smalldblib;

namespace smallasg5
{
    public partial class ListAvailable : System.Web.UI.Page
    {
        Reservation r = new Reservation();
        protected void Page_Load(object sender, EventArgs e)
        {
            tbxCId.ReadOnly = true;
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            try
            {
                lstAvailable.Items.Clear();
                List<String> av = r.listAvailable(tbxDateIn.Text, tbxDateOut.Text);
                foreach (String s in av)
                {
                    lstAvailable.Items.Add(s);
                }
                if (av[0].Equals("Please Enter a Date After 3/26/2018 12:00:00 AM"))
                {
                    Response.Write(@"<script language='javascript'>alert('Please Enter a Date After 3/26/2018 12:00:00 AM')</script>");
                    lstAvailable.Items.Clear();
                }
                else if (av[0].Equals("Please Enter a Date Before 5/14/2108 12:00:00 AM"))
                {
                    Response.Write(@"<script language='javascript'>alert('Please Enter a Date Before 5/14/2108 12:00:00 AM')</script>");
                    lstAvailable.Items.Clear();
                }
                else
                {
                    tbxCId.ReadOnly = false;
                    tbxDateIn.ReadOnly = true;
                    tbxDateOut.ReadOnly = true;
                }
            }
            catch (Exception)
            {
                Response.Write(@"<script language='javascript'>alert('Either there are no rooms available during the dates you selected or there was a formatting error')</script>");
                tbxDateIn.Text = String.Empty;
                tbxDateOut.Text = String.Empty;
            }

        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            try
            {
                string s = lstAvailable.SelectedItem.ToString();
                string[] l = s.Split(',');
                int roomNo = Int32.Parse(l[0]);
                int cID = Int32.Parse(tbxCId.Text);
                double price = 0;

                price = r.book(cID, roomNo, tbxDateIn.Text, tbxDateOut.Text);
            

                if (price > 0)
                {
                    String response = String.Format(@"<script language='javascript'>alert('Reservation Confirmed for ${0}')</script>", l[3]);
                    Response.Write(response);
                    tbxCId.ReadOnly = true;
                    tbxDateIn.ReadOnly = false;
                    tbxDateOut.ReadOnly = false;
                }
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Unable to Book')</script>"); 
                }

                lstAvailable.Items.Clear();
                tbxCId.Text = String.Empty;
                tbxDateIn.Text = String.Empty;
                tbxDateOut.Text = String.Empty;


            }
            catch (Exception)
            {
                if (lstAvailable.Items.Count == 0) Response.Write(@"<script language='javascript'>alert('Enter an Arriving Date and Departing Date')</script>");
                else
                {
                    Response.Write(@"<script language='javascript'>alert('Select a Room and a Customer')</script>");
                    tbxCId.ReadOnly = false;
                }
            }
        }

        protected void btnMain_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}