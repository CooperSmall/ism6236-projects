using System;
namespace A5_smallCooper
{
    public class Library
    {
        private Customer[] customerArray = new Customer[5];
        private Book[] bookArray = new Book[5];

        public bool AddNewBook(string bTitle, string bAuthor, int edition)
        {
            bool addbook = false;
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] == null)
                {
                    int no = i + 101;
                    bookArray[i] = new Textbook(bTitle, bAuthor, no, edition);
                    addbook = true;
                    break;
                }
            }
            return addbook;
        }

        public bool AddNewCustomer(string name) {
            bool addcust = false;
            for (int i = 0; i < customerArray.Length; i++){
                if (customerArray[i] == null){
                    int id = i + 1;
                    customerArray[i] = new Customer (name, id);
                    addcust = true;
                    break;
                }
            }
            return addcust;
        }

        public bool AddNewBook(string bookTitle, string bookAuthor){
            bool addbook = false;
            for (int i = 0; i < bookArray.Length; i++){
                if (bookArray[i] == null){
                    int no = i + 101;
                    bookArray[i] = new GeneralBook(bookTitle, bookAuthor, no);
                    addbook = true;
                    break;
                }
            }
            return addbook;
        }

        public bool IssueBook(int custId, int bookCatalogNum){
            bool issue = false;
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] != null)
                if (bookArray[i].CatalogNumber == bookCatalogNum)
                    {
                        Customer cust = null;
                        for (int o = 0; o < customerArray.Length; o++)
                        if (customerArray[o] != null)
                            if (customerArray[o].Id == custId)
                                cust = customerArray[o];
                        if (cust == null) break;
                        issue = bookArray[i].CheckOut(cust);
                        break;
                    }
            }
            return issue;
        }

        public bool ReturnBook(int bookCatalogNum){
            bool book = false;
            for (int i = 0; i < bookArray.Length; i++)
                if (bookArray[i] != null)
                if (bookArray[i].CatalogNumber == bookCatalogNum)
                    {
                        book = bookArray[i].CheckIn();
                        break;
                    } 
            
            return book;

        }

        public bool RenewBook(int bookCatalogNum){
            bool renew = false;
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] != null && bookArray[i] is IRenewable)
                        if (bookArray[i].CatalogNumber == bookCatalogNum)
                            {
                                IRenewable text = (IRenewable)bookArray[i];
                                renew = text.renew();
                                break;
                            }
            }

            return renew;
        }

        public string[] GetCustomerList() {

            String[] cust = new String[customerArray.Length];
            for (int i=0; i <customerArray.Length; i++)
            {
                if (customerArray[i] != null)
                    cust[i] = customerArray[i].ToString();
            }
            return cust;
        }

        public string[] GetBooksList()
        {
            String[] book = new String[bookArray.Length];
            for (int i = 0; i < bookArray.Length; i++)
            {
                if (bookArray[i] != null)
                    book[i] = bookArray[i].ToString();
            }
            return book;
        }

        public override string ToString(){

            string s = "";
            for (int i = 0; i < customerArray.Length; i++){
                if (customerArray[i] != null)
                s = s + customerArray[i].ToString() + "\n";
            }
            s = s + "\n";
            for (int i = 0; i < bookArray.Length; i++){
                if (bookArray[i] != null)
                s = s + bookArray[i].ToString() + "\n";
            }
            return s;
        }
    }
}
