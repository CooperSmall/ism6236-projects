using System;
using System.Collections.Generic;
using C = System.Console;
using smalldblib;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            Reservation db = new Reservation();

            List<String> cust = db.listCustomers();
            for (int i = 0; i < cust.Count; i++)
            C.WriteLine(cust[i]);
        
            C.WriteLine("Enter 'L' to list customer's reservations, 'B' to book a reservation,  or 'Q to quit");
            String input = C.ReadLine();

            bool quit = false;
            while (!quit)
            {
                int r = input[0];
                if (r == 'l' || r == 'L')
                {
                    C.Write("Enter Customer ID: ");
                    String id = C.ReadLine();
                    int cid = Int32.Parse(id);
                    List<String> temp = db.ListReservations(cid);
                    for (int i = 0; i < temp.Count; i++)
                    {
                        String row = temp[i];
                        String print = String.Format(" Reservation: {0}", row);
                        C.WriteLine(print);
                    }
                }

                else if (r == 'b' || r == 'B')
                {
                    C.WriteLine("Date-In (mm/dd/yy): ");
                    String din0 = null;
                    String din = null;
                    while (din == null)
                    {
                        din0 = C.ReadLine();
                        int counter = 0;
                        String[] format = din0.Split('/');
                        for (int i = 0; i < format.Length; i++)
                        {
                            if (format[i].Length == 2 || format[i].Length == 1)
                            {
                                counter++;
                            }
                            else break;
                        }
                        if (counter == 3)
                        {
                            int m = Int32.Parse(format[0]);
                            int d = Int32.Parse(format[1]);
                            int y = Int32.Parse(format[2]);
                            y += 2000;
                            din = (y + "-" + m + "-" + d); break;
                        }
                        else C.WriteLine("Please Re-Enter Date (mm/dd/yy): ");
                    }
                    C.WriteLine("Date-Out (mm/dd/yy): ");
                    String dout0 = null;
                    String dout = null;
                    while (dout == null)
                    {
                        dout0 = C.ReadLine();
                        int counter = 0;
                        String[] format = dout0.Split('/');
                        for (int i = 0; i < format.Length; i++)
                        {
                            if (format[i].Length == 2 || format[i].Length == 1)
                            {
                                counter++;
                            }
                            else break;
                        }
                        if (counter == 3)
                        {
                            int m = Int32.Parse(format[0]);
                            int d = Int32.Parse(format[1]);
                            int y = Int32.Parse(format[2]);
                            y += 2000;
                            dout = (y + "-" + m + "-" + d); break;
                        }
                        else C.WriteLine("Please Re-Enter Date (mm/dd/yy): ");
                    }
                    List<String> temp1 = db.listAvailable(din, dout);
                    if (temp1.Count > 1)
                    {
                        for (int i = 0; i < temp1.Count; i++)
                        {
                            String row = temp1[i];
                            String print = String.Format(" Available: {0}", row);
                        C.WriteLine(print);
                        }
                    C.WriteLine("Enter 'b' to book or 'c' to cancel");
                        String next = C.ReadLine();
                        char e = Char.Parse(next);
                        switch (e)
                        {
                            case 'b':
                            case 'B':
                                C.WriteLine("Enter Customer ID: ");
                                String id1 = C.ReadLine();
                                int cid1 = Int32.Parse(id1);
                                C.WriteLine("Enter Room Number: ");
                                int rid = 0;
                                String test = null;
                                while (true)
                                {
                                    String id2 = C.ReadLine();
                                    int id = Int32.Parse(id2);
                                    for (int i = 0; i < temp1.Count; i++)
                                    {
                                        test = temp1[i];
                                        String[] temp = (test.Split(','));
                                        int check = Int32.Parse(temp[0]);
                                        if (id == check) { rid = id; break; }
                                    }
                                    if (rid == 0) {C.WriteLine("Please Enter an Available Room's Number: "); }
                                    else
                                    {
                                        double price = db.book(cid1, rid, din, dout);
                                        String print = String.Format("The Total Cost of Your Reservation is: {0}", price);
                                    C.WriteLine(print);
                                        break;
                                    }
                                }
                                break;
                            case 'c':
                            case 'C':
                                break;
                            default: break;
                        }
                    }

                    else C.WriteLine(temp1[0]);
                }

                else quit = true;

                if (!quit)
                {
                    C.WriteLine("Enter 'L' to list customer's reservations, 'B' to book a reservation,  or 'Q to quit");
                    input = C.ReadLine();
                }
            }
        }
    }
}

