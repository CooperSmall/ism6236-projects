using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A5_smallCooper
{
    public class Customer
    {
        private int id;
        private string name = null;

        public int Id
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public Customer(string name, int id)
        {
            this.id = id; this.name = name;
        }

        public override string ToString()
        {
            return String.Format("{0,-5}{1,-10}", id, name);
        }
    }
}
