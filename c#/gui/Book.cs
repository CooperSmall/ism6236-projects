using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5_smallCooper
{
    public abstract class Book
    {
        private int catalogNumber = 0;
        private string title;
        private string authors;
        protected Customer c;
        protected DateTime dueDate;


        public Book(string title, string authors, int catalogNo) {
            this.title = title;
            this.authors = authors;
            this.catalogNumber = catalogNo;
        }

        public int CatalogNumber {
            get { return catalogNumber; }

        }

        public override string ToString () {
            string s = catalogNumber + "\t" + title + "\t" + authors;
            if (this.c != null) { s = s + "\t" + "Checked-out to Customer " + c.Name + "\tDue " + dueDate; }
            else { s = s + "\t" + "Available"; }
            return s;
        }

        public bool CheckOut (Customer cust){
            bool checkout = false;
            if (this.c == null) 
            {
                this.c = cust;
                this.dueDate = findDueDate();
                return checkout = true;
            }
            else { return checkout; }
        }

        public bool CheckIn (){
            bool checkin = false;
            if (this.c != null)
            {
                this.c = null;
                return checkin = true;
            }
            else { return checkin; }
            
        }

        public abstract DateTime findDueDate(); 

    }
}
