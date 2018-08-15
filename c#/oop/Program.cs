using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4_smallCooper
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            Console.WriteLine("Add Customer Fred: " + library.AddNewCustomer("Fred"));
            Console.WriteLine("Add Customer Bob: " + library.AddNewCustomer("Bob"));
            Console.WriteLine("Add Customer Kyle: " + library.AddNewCustomer("Kyle"));
            Console.WriteLine();

            Console.WriteLine("Add Book Learning C#: " + library.AddNewBook("Learning C#", "Liberty", 2));
            Console.WriteLine("Add Book Introduction to C#: " + library.AddNewBook("Introduction to C#", "Deitel", 1));
            Console.WriteLine("Add Book Harry Potter: " + library.AddNewBook("Harry Potter", "Rowling"));
            Console.WriteLine("Add Book Advanced C#: " + library.AddNewBook("Advanced C#", "Murach", 4));
            Console.WriteLine();

            Console.WriteLine(library.ToString());

            Console.WriteLine("Issuing Books...");
            Console.WriteLine("library.IssueBook(2, 101): " + library.IssueBook(2, 101));
            Console.WriteLine("library.IssueBook(1, 103): " + library.IssueBook(1, 103));
            Console.WriteLine("library.IssueBook(3, 101): " + library.IssueBook(3, 101));
            Console.WriteLine("library.IssueBook(1, 104): " + library.IssueBook(1, 104));
            Console.WriteLine("library.IssueBook(4, 102): " + library.IssueBook(4, 102));
            Console.WriteLine("library.IssueBook(2, 105): " + library.IssueBook(2, 105));

            Console.WriteLine();
            Console.WriteLine(library.ToString());

            Console.WriteLine("Renewing Books...");
            Console.WriteLine("library.RenewBook(101): " + library.RenewBook(101));
            Console.WriteLine("library.RenewBook(102): " + library.RenewBook(102));
            Console.WriteLine("library.RenewBook(103): " + library.RenewBook(103));
            Console.WriteLine("library.ReturnBook(106): " + library.ReturnBook(106));
            Console.WriteLine();
            Console.WriteLine(library.ToString());

            Console.WriteLine("Returning Books...");
            Console.WriteLine("library.ReturnBook(103): " + library.ReturnBook(103));
            Console.WriteLine("library.ReturnBook(103): " + library.ReturnBook(103));
            Console.WriteLine("library.ReturnBook(102): " + library.ReturnBook(102));
            Console.WriteLine("library.ReturnBook(105): " + library.ReturnBook(105));
            Console.WriteLine();


            Console.WriteLine(library.ToString());


            Console.ReadLine();

        }

        

    }
}
