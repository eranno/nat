using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.SqlServerCe;

namespace Application
{
    public class EmployeeDAL
    {
        private SqlCeConnection connection;
        private const int Timeinday = 8;
        private const string DB_SOURCE = @"G:\Application\Application\App_Data\Database.sdf";
        //public const string DB_SOURCE = @"C:\Users\natali moshe\Desktop\pro\Application\Application\App_Data\Database.sdf";

        public void connect()
        {
            connection = new SqlCeConnection("Data Source=" + DB_SOURCE);
            connection.Open();
        }

        public void disconnect()
        {
            connection.Close();
        }


        //מכניס שעת כניסה או שעת יציאה
        public bool LogInorOut(int user, string pas, int inorout)
        {
            bool ok = false;    //user not found
            string command;
            SqlCeCommand com;
            DateTime date = DateTime.Now;
            string format = "MM/dd/yyyy HH:mm:ss";    // Use this format

            connect();
            command = " SELECT  ed.password, ee.id"
                    + " FROM     EmployeeData AS ed LEFT OUTER JOIN"
                    + " EntryAndExit AS ee ON ed.id = ee.id AND ee.inorout = "+inorout+" AND DATEDIFF(dd, ee.dateandtime, '" + date.ToString(format) + "') = 0"
                    + " WHERE  (ed.id = '"+user+"')";

            com = new SqlCeCommand(command, connection);

            SqlCeDataReader data = com.ExecuteReader();

            while (data.Read())
            {
                //password ok, let him in
                if (pas.Equals(data[0]))
                {
                    ok = true;
                  

                    //if not entered today than mark enter time
                    if (!user.Equals(data[1]))
                    {
                        String sqlString = "INSERT INTO EntryAndExit VALUES('" + user + "','" + date.ToString(format) + "','" + inorout + "');";
                        SqlCeCommand com2 = new SqlCeCommand(sqlString, connection);
                        com2.ExecuteNonQuery();
                    }
                }
            }

            disconnect();

            return ok;
        }

        //בודק אם זה מנהל או עובד
        public bool IsManger(int user)
        {
            string command;
            SqlCeCommand com;
            bool man =false;
            connect();

            command = "SELECT * FROM EmployeeData WHERE id = '" + user + "';";

            com = new SqlCeCommand(command, connection);

            SqlCeDataReader data = com.ExecuteReader();

            while (data.Read())
            {
                if (int.Parse("" + data[4]) == 1)
                {
                        man=true;;
                }
            }

            disconnect();

            return man;
        }

        //מקבל את כל הפרטים של העובד חוץ מסיסמא
        public Employee GetEmployeeId(int user)
        {
             Employee employee = null;

              string command;
              SqlCeCommand com;

              connect();

              command = "SELECT * FROM EmployeeData WHERE id = '" + user + "';";

              
              com = new SqlCeCommand(command, connection);

              SqlCeDataReader data = com.ExecuteReader();

              while (data.Read())
              {
                  employee = new Employee(int.Parse("" + data[0]), "" + data[1], "" + "" + data[2], int.Parse("" + data[4]), int.Parse("" + data[5]), int.Parse("" + data[6]), int.Parse("" + data[7]), int.Parse("" + data[8]), int.Parse("" + data[9]), int.Parse("" + data[10]), int.Parse("" + data[11]), int.Parse("" + data[12]), int.Parse("" + data[13]));
              }
             
              disconnect();

              return employee;

        }


        //מקבל את כל הפרטים של העובד חוץ מסיסמא
        public Employee GetEmployeeName(string first, string last)
        {
            Employee employee = null;

            string command;
            SqlCeCommand com;

            connect();

            command = "SELECT * FROM EmployeeData WHERE firstname = '" + first + "' AND lastname='"+last+"';";

            com = new SqlCeCommand(command, connection);

            SqlCeDataReader data = com.ExecuteReader();

            while (data.Read())
            {
                employee = new Employee(int.Parse("" + data[0]), "" + data[1], "" + "" + data[2], int.Parse("" + data[4]), int.Parse("" + data[5]), int.Parse("" + data[6]), int.Parse("" + data[7]), int.Parse("" + data[8]), int.Parse("" + data[9]), int.Parse("" + data[10]), int.Parse("" + data[11]), int.Parse("" + data[12]), int.Parse("" + data[13]));
            }

            disconnect();

            return employee;

        }
        

        //הוספת עובד חדש לDB
        public void AddEmployee(Employee m)
        {
            connect();

            String sqlString = "INSERT INTO EmployeeData VALUES('" + m.Id + "','" + m.FirstName + "','" + m.LastName + "','" + m.Password + "','" + m.Rank + "','" + m.Wage + "','" + m.Minhours + "','" + m.Maxhours + "','" + m.Overtimeinday + "','" + m.Overtimeinmonth + "','" + m.Sick + "','" + m.Vacation + "','" + m.Timeheworkonday + "','" + m.Timeheworkonmonth + "');";
                SqlCeCommand com = new SqlCeCommand(sqlString, connection);
                com.ExecuteNonQuery();
              disconnect();
        }



        //change password. return true if success
        public bool ChangePassword(int user, string oldpass, string newpass1, string newpass2)
        {
            if (newpass1.Equals(newpass2))
            {
                connect();
                String sqlString = "UPDATE EmployeeData SET password= '" + newpass1 + "' WHERE id= '" + user + "' AND BINARY password= '" + oldpass + "';";
                SqlCeCommand com = new SqlCeCommand(sqlString, connection);
                int numberOfRecords = com.ExecuteNonQuery();
                disconnect();

                //is password changed?
                if (numberOfRecords > 0)
                    return true;
            }
            return false;
        }

        //מחזיר את כל העובדים עם כל הנתונים שלהם שנמצאים עכשיו בעבודה
        public LinkedList<Employee> GetAllEmployeeInWork()
        {
            LinkedList<Employee> employee = new LinkedList<Employee>();
            DateTime time = DateTime.Now;
            string dateoftime= time.ToString("MM/dd/yyyy");
            string command;
            connect();
 
            //select all users that logged in but didn't logged out yet
            command = " SELECT  ee.id, ed.firstname, ed.lastname, ed.rank, ed.wage, ed.minhours, ed.maxhours, ed.overtimeinday, ed.overtimeinmonth, ed.sick, ed.vacation, ed.timeheworkonmonth, ee.dateandtime"
                + " FROM     EntryAndExit AS ee" 
                + " INNER JOIN EmployeeData AS ed ON ee.id = ed.id"
                + " WHERE  (DATEDIFF(dd, ee.dateandtime, '" + dateoftime + "') = 0) AND (ee.inorout = 1) AND (ee.id NOT IN"
                + " (SELECT  id"
                + " FROM     EntryAndExit"
                + " WHERE  (DATEDIFF(dd, dateandtime, '" + dateoftime + "') = 0) AND (inorout = 0)))";

        /*
SELECT  ee.id, ed.firstname, ed.lastname, ed.rank, ed.wage, ed.minhours, ed.maxhours, ed.overtimeinday, ed.overtimeinmonth, ed.sick, ed.vacation, 
               ed.timeheworkonmonth, ee.dateandtime
FROM     EntryAndExit AS ee INNER JOIN
               EmployeeData AS ed ON ee.id = ed.id
WHERE  (DATEDIFF(dd, ee.dateandtime, '08/14/13') = 0) AND (ee.inorout = 1) AND (ee.id NOT IN
                   (SELECT  id
                    FROM     EntryAndExit
                    WHERE  (DATEDIFF(dd, dateandtime, '08/14/13') = 0) AND (inorout = 0)))
         */

            SqlCeCommand com = new SqlCeCommand(command, connection);
            SqlCeDataReader data = com.ExecuteReader();

            while (data.Read())
            {
               // int count = 0;
               // count = time.Subtract(DateTime.Parse("" + data[12])).Hours;
                //ma ze???
                int count = 0;
                count = time.Subtract(DateTime.Parse("" + data[12])).Minutes;
                //String sqlString = "UPDATE EmployeeData SET timeheworkonday= '" + count + "' WHERE id= '" + int.Parse("" + data[0]) + "';";
                //SqlCeCommand com2 = new SqlCeCommand(sqlString, connection);
                //com2.ExecuteNonQuery();

                //add the user to list
                employee.AddLast(
                    new Employee(int.Parse("" + data[0]), "" + data[1], "" + "" + data[2], int.Parse("" + data[3]), int.Parse("" + data[4]), int.Parse("" + data[5]), int.Parse("" + data[6]), int.Parse("" + data[7]), int.Parse("" + data[8]), int.Parse("" + data[9]), int.Parse("" + data[10]), count, int.Parse("" + data[11]))
                );

            }
            disconnect();

            return employee;
        }


        //return all employees
        public LinkedList<Employee> GetAllEmployee()
        {
            LinkedList<Employee> employee = new LinkedList<Employee>();

            connect();
            string command = "SELECT * FROM EmployeeData ORDER BY firstname ASC";
            SqlCeCommand com = new SqlCeCommand(command, connection);
            SqlCeDataReader data = com.ExecuteReader();
            while (data.Read())
            {
                employee.AddLast(new Employee(int.Parse("" + data[0]), "" + data[1], "" + "" + data[2], int.Parse("" + data[4]), int.Parse("" + data[5]), int.Parse("" + data[6]), int.Parse("" + data[7]), int.Parse("" + data[8]), int.Parse("" + data[9]), int.Parse("" + data[10]), int.Parse("" + data[11]), int.Parse("" + data[12]), int.Parse("" + data[13])));
            }
            disconnect();

            return employee;
        }


        //return user vacations days left
        public int Vacation(int user)
        {
            string command;
            SqlCeCommand com;
            int vac=0;
            connect();

            command = "SELECT vacation FROM EmployeeData WHERE id = '" + user + "';";
            com = new SqlCeCommand(command, connection);
            SqlCeDataReader data = com.ExecuteReader();
            while (data.Read())
            {
                vac = int.Parse(""+data[0]);
            }
            disconnect();

            return vac ;
        }


        //return user sick days left
        public int Sick(int user)
        {
            string command;
            SqlCeCommand com;
            int sic = 0;
            connect();

            command = "SELECT sick FROM EmployeeData WHERE id = '" + user + "';";
            com = new SqlCeCommand(command, connection);
            SqlCeDataReader data = com.ExecuteReader();
            while (data.Read())
            {
                sic = int.Parse("" + data[0]);
            }
            disconnect();

            return sic;
        }


        //כמות שעות שהוא עבד בחודש
        public int HoursWorkInMonth(int user)
        {
            connect();
            string command = "SELECT timeheworkonmonth FROM EmployeeData WHERE id = '" + user + "';";
            SqlCeCommand com = new SqlCeCommand(command, connection);
            SqlCeDataReader data = com.ExecuteReader();
            while (data.Read())
            {
                return int.Parse("" + data[0]);
            }
            disconnect();

            return 0;
        }


        //מחזירה את כמות השעות שכל העובדים עובדים כרגע
        public int CountWorker(LinkedList<Employee> emp)
        {
            int sum = 0;
            foreach (Employee i in emp)
            {
                sum = i.Timeheworkonday;
            }
            return sum;
        }


        //כמות שעות שהעובד עבד באותו יום
        public int HoursWorkInDay(int user, DateTime date)
        {
            connect();
            string command = "SELECT dateandtime FROM EntryAndExit WHERE id = '" + user + "' AND DateDiff(dd, dateandtime, '" + date + "') = 0";
            SqlCeCommand com = new SqlCeCommand(command, connection);
            SqlCeDataReader data = com.ExecuteReader();
            int count = 0;
            while (data.Read())
            {
                count = date.Subtract(DateTime.Parse("" + data[0])).Minutes;
                return count;
            }
            disconnect();

            return count;
        }


        //הודעה לא נקראה =0
        //הודעה מאושרת עי המנהל =1
        public LinkedList<Massege> GetMassege(int user)
        {
            LinkedList<Massege> mes = new LinkedList<Massege>();

            connect();
            string command = "SELECT r.idsender, r.idreceiver, r.type, r.note, r.approve, r.date, r.isread, e.firstname, e.lastname FROM RequestsAndComments AS r INNER JOIN EmployeeData AS e ON r.idsender=e.id WHERE r.idreceiver = '" + user + "' AND r.isread=0;";

            SqlCeCommand com = new SqlCeCommand(command, connection);
            SqlCeDataReader data = com.ExecuteReader();
            while (data.Read())
            {
                mes.AddLast(new Massege(int.Parse("" + data[0]), int.Parse("" + data[1]), int.Parse("" + data[2]), "" + data[3], int.Parse("" + data[4]),"" +data[5], int.Parse("" + data[6]), "" + data[7], "" + data[8]));
            }
            disconnect();

            return mes;
        }

        
        //add new message
        public void SetMassege(Massege mes)
        {
            connect();
            String sqlString = "INSERT INTO RequestsAndComments VALUES('" + mes.Idreceiver + "','" + mes.Idsender + "','" + mes.Type + "','" + mes.Note + "','" + mes.Approve + "','" + mes.Date + "','" + mes.Read + "');";
            SqlCeCommand com = new SqlCeCommand(sqlString, connection);
            com.ExecuteNonQuery();
            disconnect();
        }


        //mark message as been read
        public void SetIsRead(int id)
        {
            connect();

            String sqlString = "UPDATE RequestsAndComments SET isread= '" + 1 + "' WHERE id= '" + id + "';";
            SqlCeCommand com = new SqlCeCommand(sqlString, connection);
            com.ExecuteNonQuery();

            disconnect();
        }
        

        private LinkedList<Report> ReportEntryAndExit(int user, DateTime date)
        {
            LinkedList<Report> rep = new LinkedList<Report>();

            connect();
            string command = "SELECT * FROM EntryAndExit WHERE id = '" + user + "' ORDER BY dateandtime ASC;";
            SqlCeCommand com = new SqlCeCommand(command, connection);
            SqlCeDataReader data = com.ExecuteReader();

            while (data.Read())
            {
                if (date.ToString("MM").Equals(DateTime.Parse("" + data[1]).ToString("MM")))
                {
                    if (int.Parse("" + data[2]) == 1)
                    {
                        Report reports = new Report();
                        reports.Date = DateTime.Parse("" + data[1]);
                        if (int.Parse("" + data[2]) == 1)
                            reports.Entry = DateTime.Parse("" + data[1]);
                        if (int.Parse("" + data[2]) == 0)
                            reports.Exit = DateTime.Parse("" + data[1]);
                        rep.AddLast(reports);
                    }
                    else
                    {
                        foreach (Report i in rep)
                        {
                            if (i.Date.ToString("dd").Equals(DateTime.Parse("" + data[1]).ToString("dd")))
                            {
                                i.Date = DateTime.Parse("" + data[1]);
                                if (int.Parse("" + data[2]) == 1)
                                    i.Entry = DateTime.Parse("" + data[1]);
                                if (int.Parse("" + data[2]) == 0)
                                    i.Exit = DateTime.Parse("" + data[1]);

                                break;
                            }
                        }

                    }
                }
            }
            disconnect();

            return rep;
        }


        //ma kore kan???
        private LinkedList<Report> ReportNote(LinkedList<Report> rep, int user)
        {
            return null;
            /*
            connect();
            string command = "SELECT idsender, idreceiver, type, note, approve, CONVERT(datetime, date, 100) AS date, isread FROM RequestsAndComments WHERE idsender = '" + user + "' And approve = 1 ;";
            SqlCeCommand com = new SqlCeCommand(command, connection);

            SqlCeDataReader data = com.ExecuteReader();

            while (data.Read())
            {
                if (int.Parse("" + data[2]) != 2)
                {
                    int x = 0;
                    foreach (Report i in rep)
                    {
                        if (i.Date.ToString("MMMM").Equals(DateTime.Parse("" + data[5]).ToString("MMMM")))
                        {
                            if (i.Date.ToString("dd").Equals(DateTime.Parse("" + data[5]).ToString("dd")))
                            {
                                x = 1;
                                i.Type = int.Parse("" + data[2]);
                                i.Note = "" + data[3];
                                break;
                            }
                            else
                            {
                                if (x == 0)
                                {

                                    Report reports = new Report();
                                    reports.Date = DateTime.Parse("" + data[1]);
                                    rep.AddLast(reports);

                                }
                                x = 0;
                            }
                        }
                    }

                }
            }
            disconnect();
            return rep;
            */
        }

        private LinkedList<Report> ReportHours(LinkedList<Report> rep, int user)
        {
            foreach (Report i in rep)
            {
                int time2 = (int)i.Exit.Subtract(i.Entry).TotalMinutes;
                int consttime = Timeinday * 60;
                if (time2 > consttime)
                {
                    i.Excesshours = (time2 - consttime);
                    i.Lackhours = 0;
                    i.Hours = time2;
                }
                else
                {
                    i.Excesshours = 0;
                    i.Lackhours = (consttime - time2);
                    i.Hours = time2;
                }
            }

            return rep;
        }


        public LinkedList<Report> Reports(int user, DateTime date)
        {
            LinkedList<Report> rep = ReportEntryAndExit(user, date);
            rep = ReportNote(rep, user);
            rep = ReportHours(rep, user);
            return rep;
        }


        //Notes reason dictionery
        public string Type(int x)
        {
            switch (x)
            {
                case 1: return "sick";
                case 2: return "vacation";
                case 3: return "fast";
                case 4: return "job";
                case 5: return "vacation request";
                default: return ""; //-1
            }
        }


       //update employee info
       public void updateEmployee(Employee empnew)
       {
            bool exc = false;
            String sqlString = "";
            

            if (!empnew.FirstName.Equals(""))
            {
                if (exc) sqlString += " AND ";
                sqlString += "firstname= '" + empnew.FirstName;
                exc = true;
            }

            if (!empnew.LastName.Equals(""))
            {
                if (exc) sqlString += " AND ";
                sqlString += "lastname= '" + empnew.LastName;
                exc = true;
            }

            if (empnew.Rank != -1)
            {
                if (exc) sqlString += " AND ";
                sqlString += "rank= '" + empnew.Rank;
                exc = true;
            }

            if (empnew.Wage != -1)
            {
                if (exc) sqlString += " AND ";
                sqlString += "wage= '" + empnew.Wage;
                exc = true;
            }

            if (empnew.Minhours != -1)
            {
                if (exc) sqlString += " AND ";
                sqlString += "minhours= '" + empnew.Minhours;
                exc = true;
            }

            if (empnew.Maxhours != -1)
            {
                if (exc) sqlString += " AND ";
                sqlString += "maxhours= '" + empnew.Maxhours;
                exc = true;
            }

            if (empnew.Overtimeinday != -1)
            {
                if (exc) sqlString += " AND ";
                sqlString += "overtimeinday= '" + empnew.Overtimeinday;
                exc = true;
            }

            if (empnew.Overtimeinmonth != -1)
            {
                if (exc) sqlString += " AND ";
                sqlString += "overtimeinmonth= '" + empnew.Overtimeinmonth;
                exc = true;
            }

            if (empnew.Sick != -1)
            {
                if (exc) sqlString += " AND ";
                sqlString += "sick= '" + empnew.Sick;
                exc = true;
            }

            if (empnew.Vacation != -1)
            {
                if (exc) sqlString += " AND ";
                sqlString += "vacation= '" + empnew.Vacation;
                exc = true;
            }

            //execute
            if (exc)
            {
                sqlString = "UPDATE EmployeeData SET " + sqlString + " WHERE id= '" + empnew.Id + "';";
                connect();
                SqlCeCommand com2 = new SqlCeCommand(sqlString, connection);
                com2.ExecuteNonQuery();
                disconnect();
            }
       }
    }
}