using System;
namespace A4_smallCooper
{
    public class GeneralBook : Book
    {
        public GeneralBook(string title, string authors, int catalogNo) : base(title,authors,catalogNo)
        {
        }

        public override DateTime findDueDate()
        {
            DateTime now = DateTime.Today;
            DateTime date = now.AddDays(7);

            return date;
        }
    }
}
