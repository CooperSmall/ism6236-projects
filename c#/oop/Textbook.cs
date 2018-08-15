using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4_smallCooper
{
    public class Textbook : Book, IRenewable
    {
        private int edition;

        public Textbook(string title, string authors, int catalogNo, int edition): base(title,authors,catalogNo)
        {
            this.edition = edition; 
        }

        public override DateTime findDueDate()
        {
            DateTime now = DateTime.Today;
            DateTime date = now.AddDays(30);

            return date;
        }

        public bool renew()
        {
            bool re = false;
            if (this.c != null)
            {
                this.dueDate = this.dueDate.AddDays(15);
                re = true;
            }

            return re;
        }

		public override string ToString()
		{
            String print = base.ToString() + "\tEdition: " + edition;
            return print;
		}
	}
}
