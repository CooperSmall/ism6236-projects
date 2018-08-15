using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace smalldblib {

    public class Reservation
    {

        public SqlConnection c;
        private const String dbname = "reservations";


        public Reservation()
        {
            connect();
        }

        public void connect()
        {

            c = new SqlConnection();
            c.ConnectionString = String.Format("Data Source=(local); Initial Catalog={0}; Integrated Security = True;", dbname);
            c.Open();
        }

        public void commit(String sql)
        {

                SqlCommand cmd = new SqlCommand(sql, c);
                SqlTransaction trans = c.BeginTransaction();

                try
                {
                    cmd.Transaction = trans;
                    cmd.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (InvalidOperationException ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
        }

        public List<String> listCustomers()
        {

            List<String> custList = new List<String>();
            try
            {
                String sql = ("SELECT * FROM Customer");
                SqlCommand s = new SqlCommand(sql, c);
                SqlDataReader r = s.ExecuteReader();
                String row = null;
                if (r.HasRows)
                {
                    while (r.Read())
                    {
                        var id = r.GetValue(0);
                        var name = r.GetValue(1);
                        var cc = r.GetValue(2);
                        row = String.Format("{0}, {1}, {2}", id, name, cc);
                        custList.Add(row);
                    }
                }
                r.Close();
            }
            catch (Exception sqle)
            {
                Console.WriteLine(sqle.StackTrace);
            }
            return custList;
        }

        public List<String> ListReservations(int cid)
        {

            List<String> resList = new List<String>();
            try
            {
                String sql = String.Format("SELECT RoomNo, DateIn, DateOut, TotalPrice FROM Reservation WHERE CustomerId = {0}", cid);
                SqlCommand s = new SqlCommand(sql, c);
                SqlDataReader r = s.ExecuteReader();
                if (r.HasRows) {
                    while (r.Read())
                    {
                        var no = r.GetValue(0);
                        var datein = r.GetValue(1);
                        var dateout = r.GetValue(2);
                        var total = r.GetValue(3);
                        String row = String.Format("{0}, {1}, {2}, {3}", no, datein, dateout, total);
                        resList.Add(row);
                    }
                }
                r.Close();
            }
            catch (Exception sqle)
            {
                Console.WriteLine(sqle.StackTrace);
            }
            finally { }

            return resList;

        }

        public List<String> listAvailable(String datein, String dateout)
        {

            List<String> available = new List<String>();
            try
            {
                while (true)
                {

                    String sql = String.Format("SELECT DISTINCT DATEDIFF"
                            + "(day, '{0}', (SELECT MAX(date) FROM Pricing)) "
                            + "FROM Pricing ", dateout);
                    SqlCommand s0 = new SqlCommand(sql, c);
                    SqlDataReader r0 = s0.ExecuteReader();

                    dynamic oo = 0;
                    if (r0.HasRows) { while (r0.Read()) { oo = r0.GetValue(0); } }
                    float o = (float)oo;

                    if (o < 0)
                    {
                        r0.Close();
                        String sql0 = ("SELECT MAX(date) FROM Pricing");
                        SqlCommand max = new SqlCommand(sql0, c);
                        SqlDataReader fail = max.ExecuteReader();
                        if (fail.HasRows)
                        {
                            while (fail.Read())
                            {
                                var date = fail.GetValue(0);
                                String error = ("Please Enter a Date Before " + date);
                                available.Add(error);
                            }
                        }
                        fail.Close();
                        break;
                    }
                    else r0.Close();

                    sql = String.Format("SELECT DISTINCT DATEDIFF"
                            + "(day,(SELECT MIN(date) FROM Pricing), '{0}') "
                            + "FROM Pricing ", datein);
                    SqlCommand s1 = new SqlCommand(sql, c);
                    SqlDataReader r1 = s1.ExecuteReader();

                    dynamic ii = 0;
                    if (r1.HasRows) { while (r1.Read()) { ii = r1.GetValue(0); } }
                    float i = (float)ii;

                    if (i < 0)
                    {
                        r1.Close();
                        String sql1 = ("SELECT MIN(date) FROM Pricing");
                        SqlCommand min = new SqlCommand(sql1, c);
                        SqlDataReader fail1 = min.ExecuteReader();
                        if (fail1.HasRows)
                        {
                            while (fail1.Read())
                            {
                                var date = fail1.GetValue(0);
                                String error = ("Please Enter a Date After " + date);
                                available.Add(error);
                            }
                        }
                        fail1.Close();
                        break;
                    }
                    else r1.Close();

                    sql = String.Format("SELECT i.RoomNo, i.RoomType, d.NumBeds, (SUM(p.Price)) AS Sum  " +
                        "FROM RoomInventory AS i INNER JOIN RoomDetails AS d ON i.RoomType = d.RoomType " +
                        "INNER JOIN Pricing AS p ON d.RoomType = p.RoomType " +
                        "WHERE (p.Date) BETWEEN '{0}' AND '{1}' " +
                        "AND i.RoomNo NOT IN (SELECT RoomNo FROM Reservation AS r WHERE r.DateIn BETWEEN '{2}' AND '{3}' " +
                            "OR r.DateOut BETWEEN '{4}' AND '{5}' ) " +
                        "GROUP BY i.RoomNo, i.RoomType, d.NumBeds; ", datein, dateout, datein, dateout, datein, dateout);
                    SqlCommand s2 = new SqlCommand(sql, c);
                    SqlDataReader r2 = s2.ExecuteReader();

                    if (r2.HasRows)
                    {
                        while (r2.Read())
                        {
                            int no = Int16.Parse(Convert.ToString(r2.GetValue(0)));
                            var type = r2.GetValue(1);
                            var bed = r2.GetValue(2);
                            double sum = float.Parse(Convert.ToString(r2.GetValue(3)));
                            String row = String.Format("{0}, {1}, {2}, {3}", no, type, bed, sum);
                            available.Add(row);
                        }
                    }
                    r2.Close(); break;
                }
            }
            catch (Exception sqle)
            {
                Console.WriteLine(sqle.StackTrace);
            }

            return available;
        }

        public double book(int cid, int rid, String datein, String dateout)
        {
            double price = 0;

            try
            {
                String p = "";
                String sql = String.Format("SELECT SUM(p.Price) AS Sum " +
                        "FROM Pricing AS p " +
                        "INNER JOIN RoomInventory AS i ON p.RoomType = i.RoomType " +
                        "WHERE (p.Date) BETWEEN '{0}' AND '{1}' " +
                        "AND i.RoomNo = {2} ", datein, dateout, rid);
                SqlCommand s = new SqlCommand(sql,c);
                SqlDataReader r = s.ExecuteReader();
                if (r.HasRows) { while (r.Read()) { p = Convert.ToString(r.GetValue(0)); } }
                r.Close();

                price += float.Parse(p);

                sql = String.Format("SELECT p.Price FROM Pricing AS p " +
                        "INNER JOIN RoomInventory AS i ON p.RoomType = i.RoomType " +
                        "WHERE p.Date = '{0}' AND i.RoomNo = {1} ", dateout, rid);
                SqlCommand s1 = new SqlCommand(sql, c);
                SqlDataReader r1 = s1.ExecuteReader();
                if (r1.HasRows) { while (r1.Read()) { p = Convert.ToString(r1.GetValue(0)); } }
                r1.Close();

                price -= float.Parse(p);

                if (price > 0)
                {
                    sql = String.Format("INSERT INTO Reservation "
                            + "(CustomerId, RoomNo, DateIn, DateOut, TotalPrice) "
                            + "VALUES ({0}, {1}, '{2}', '{3}', {4})", cid, rid, datein, dateout, price);
                    commit(sql);
                }
            }
            catch (Exception sqle)
            {
                 Console.WriteLine(sqle.StackTrace);
            }

            return price;
        }

        public static void Main(String[] args)
        {

        }

    }
}


