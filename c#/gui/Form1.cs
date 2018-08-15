using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A5_smallCooper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Library l = new Library();

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Customer Name";
            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox3.Enabled = false;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Title";
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Title";
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool added = false;
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            if (radioButton1.Checked == true)
            {
                if (textBox1.Text.Length > 0)
                {
                    added = l.AddNewCustomer(textBox1.Text);
                    textBox1.Text = String.Empty;
                }
                else MessageBox.Show("Please Enter a Name");
            }
            else if (radioButton2.Checked == true)
            {
                if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
                {
                    added = l.AddNewBook(textBox1.Text, textBox2.Text);
                    textBox1.Text = String.Empty;
                    textBox2.Text = String.Empty;
                }
                else MessageBox.Show("Please Enter a Title and Author");
            }
            else
            {
                if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0 && textBox3.Text.Length > 0)
                {
                    int ed = Int32.Parse(textBox3.Text);
                    added = l.AddNewBook(textBox1.Text, textBox2.Text, ed);
                    textBox1.Text = String.Empty;
                    textBox2.Text = String.Empty;
                    textBox3.Text = String.Empty;
                }
                else MessageBox.Show("Please Enter a Title, Author, and Edition");
            }
            string[] cust = l.GetCustomerList();
            for (int i = 0; i < cust.Length; i++)
                if (cust[i] != null)
                listBox1.Items.Add(cust[i]);

            string[] books = l.GetBooksList();
            for (int i = 0; i < books.Length; i++)
                if (books[i] != null)
                    listBox2.Items.Add(books[i]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool issue = false;

            if (listBox1.SelectedIndex > -1 && listBox2.SelectedIndex > -1)
            {
                string getid = listBox1.GetItemText(listBox1.SelectedItem).Substring(0, 1);
                int cid = Int32.Parse(getid);

                string getcat = listBox2.GetItemText(listBox2.SelectedItem).Substring(0, 3);
                int cat = Int32.Parse(getcat);

                issue = l.IssueBook(cid, cat);
                if (issue == false)
                    MessageBox.Show("This Book is Already Issued");

                listBox1.Items.Clear();
                listBox2.Items.Clear();

                string[] cust = l.GetCustomerList();
                for (int i = 0; i < cust.Length; i++)
                    if (cust[i] != null)
                        listBox1.Items.Add(cust[i]);

                string[] books = l.GetBooksList();
                for (int i = 0; i < books.Length; i++)
                    if (books[i] != null)
                        listBox2.Items.Add(books[i]);
            }
            else MessageBox.Show("Please Select both a Customer and a Book");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool back = false;

            if (listBox2.SelectedIndex > -1)
            {
                string getcat = listBox2.GetItemText(listBox2.SelectedItem).Substring(0, 3);
                int cat = Int32.Parse(getcat);

                back = l.ReturnBook(cat);
                if (back == false)
                    MessageBox.Show("This Book is Already Available"); 

                listBox2.Items.Clear();

                string[] books = l.GetBooksList();
                for (int i = 0; i < books.Length; i++)
                    if (books[i] != null)
                        listBox2.Items.Add(books[i]);
            }
            else MessageBox.Show("Please Select a Book");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            bool renew = false;

            if (listBox2.SelectedIndex > -1)
            {
                string getcat = listBox2.GetItemText(listBox2.SelectedItem).Substring(0, 3);
                int cat = Int32.Parse(getcat);

                renew = l.RenewBook(cat);
                if (renew ==false)
                     MessageBox.Show("This Book cannot be Renewed");

                listBox2.Items.Clear();

                string[] books = l.GetBooksList();
                for (int i = 0; i < books.Length; i++)
                    if (books[i] != null)
                        listBox2.Items.Add(books[i]);
            }
            else MessageBox.Show("Please Select a Book");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Customer Name";
            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }

    }
}
