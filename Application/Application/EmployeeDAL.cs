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

        //public const string DB_SOURCE = @"G:\Application\Application\App_Data\Database.sdf";
        public const string DB_SOURCE = @"C:\Users\natali moshe\Desktop\pro\Application\Application\App_Data\Database.sdf";

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
        public bool LogInorOut2(int user, string pass, int inorout)
        {
            DateTime date = DateTime.Now;
            String sqlString;
            SqlCeCommand com;
            int numberOfRecords = 0;

            connect();

            sqlString = "INSERT INTO `EntryAndExit` (`id`, `dateandtime`, `inorout`)"
	                    + "SELECT e.`id`, ("+date+") AS dt, ("+inorout+") AS io"
	                    + "FROM `EmployeeData` e "
	                    + "WHERE e.`id` = '"+user+"' AND BINARY u.`password`='"+pass+"';";

            //sqlString = "INSERT INTO EntryAndExit VALUES('" + user + "','" + date + "','" + inorout + "');";
            com = new SqlCeCommand(sqlString, connection);
            numberOfRecords = com.ExecuteNonQuery();

            disconnect();

            //if user and password ok
            if (numberOfRecords > 0)
                return true;
            else
                return false;
        }

        //מכניס שעת כניסה או שעת יציאה
        public bool LogInorOut(int user, string pas, int inorout)
        {
            bool ok = false;    //user not found
            string command;
            SqlCeCommand com;

            connect();
            command = "SELECT * FROM EmployeeData WHERE id = '" + user + "';";

            com = new SqlCeCommand(command, connection);

            SqlCeDataReader data = com.ExecuteReader();

            while (data.Read())
            {
                if (pas.Equals(data[3]))
                {
                    ok = true;//ps ok
                   
            
                    //כניסת משתמש 
                    DateTime date = DateTime.Now;
                   // Console.WriteLine(currentTime.ToString());
                   // Console.WriteLine(currentTime.ToString("dd/MM/yyyy"));
                   // Console.WriteLine(currentTime.ToString("yyyy-MM-dd HH:mm"));

                    String sqlString = "INSERT INTO EntryAndExit VALUES('" + user + "','" + date + "','" + inorout + "');";
                    SqlCeCommand com2 = new SqlCeCommand(sqlString, connection);
                    com2.ExecuteNonQuery();

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
        public Employee GetEmployee(int user)
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

       /* public string arg()
        {
            Employee m = new Employee(302898739, "natali", "grinberg", 1, 1000000, 90, 120, 4, 12, 25, 25, 0, 0);
            connect();
            //INSERT INTO EmployeeData VALUES('302898739','natali','grinberg','0000','1','1000000','90','120','4','12','25','25','0','0');
            String sqlString = "INSERT INTO EmployeeData VALUES('" +1230 + "','" + m.FirstName + "','" + m.LastName + "','" + m.Password + "','" + m.Rank + "','" + m.Wage + "','" + m.Minhours + "','" + m.Maxhours + "','" + m.Overtimeinday + "','" + m.Overtimeinmonth + "','" + m.Sick + "','" + m.Vacation + "','" + m.Timeheworkonday + "','" + m.Timeheworkonmonth + "');";
            String sqlString2 = "INSERT INTO EmployeeData VALUES('" + m.Id + "','" + m.FirstName + "','" + m.LastName + "','" + m.Password + "','" + m.Rank + "','" + m.Wage + "','" + m.Minhours + "','" + m.Maxhours + "','" + m.Overtimeinday + "','" + m.Overtimeinmonth + "','" + m.Sick + "','" + m.Vacation + "','" + m.Timeheworkonday + "','" + m.Timeheworkonmonth + "');";
            return sqlString;
            SqlCeCommand com = new SqlCeCommand(sqlString, connection);
            com.ExecuteNonQuery();
           
            disconnect();

        }*/
        

        //הוספת עובד חדש לDB
        public void AddEmployee(Employee m)
        {
            connect();

            //String sqlString = "INSERT INTO EmployeeData VALUES('" + m.Id + "','" + m.FirstName + "','" + m.LastName + "','" + m.Password + "','" + m.Rank + "','" + m.Wage + "','" + m.Minhours + "','" + m.Maxhours + "','" + m.Overtimeinday + "','" + m.Overtimeinmonth + "','" + m.Sick + "','" + m.Vacation + "','" + m.Timeheworkonday + "','" + m.Timeheworkonmonth + "');";
            String sqlString = "INSERT INTO EmployeeData VALUES('" + m.Id + "','" + m.FirstName + "','" + m.LastName + "','" + m.Password + "','" + m.Rank + "','" + m.Wage + "','" + m.Minhours + "','" + m.Maxhours + "','" + m.Overtimeinday + "','" + m.Overtimeinmonth + "','" + m.Sick + "','" + m.Vacation + "','" + m.Timeheworkonday + "','" + m.Timeheworkonmonth + "');";
                SqlCeCommand com = new SqlCeCommand(sqlString, connection);
               // com.ExecuteNonQuery();
                com.ExecuteNonQuery();
              disconnect();
          


        }



        //if ok=true the password change
        public void ChangePassword(int user,string newpas)
        {
            connect();

            String sqlString = "UPDATE EmployeeData SET password= '" + newpas + "' WHERE id= '" + user + "';";
            SqlCeCommand com = new SqlCeCommand(sqlString, connection);
            com.ExecuteNonQuery();

            disconnect();

            return;
        }

        //מחזיר את כל העובדים עם כל הנתונים שלהם שנמצאים עכשיו בעבודה
    public LinkedList<Employee> GetAllEmployeeInWork()
    {
        LinkedList<Employee> employee = new LinkedList<Employee>();
        DateTime time = DateTime.Now;
        string dateoftime= time.ToString("dd/MM/yyyy");
         string command;
        connect();
       // command = "SELECT * FROM EmployeeData WHERE inorout = '" + 1 + "';";
      /*  command = "SELECT * FROM EntryAndExit WHERE inorout = '" + 1 + "' AND "
            + "DateDiff(dd, dateandtime, '"+dateoftime+"') = 0  ;";*/


        command = "SELECT e2.* e1.dateandtime FROM EntryAndExit e1 WHERE DateDiff(dd, e1.dateandtime, '" + dateoftime + "') = 0"
            + "INNER JOIN EmployeeData e2 ON e1.id=e2.id"
            +" GROUP BY id HAVING COUNT(e1.id)=1;";

        SqlCeCommand com = new SqlCeCommand(command, connection);

        SqlCeDataReader data = com.ExecuteReader();

        while (data.Read())
        {

            int count = 0;
            count = time.Subtract(DateTime.Parse(""+data[14])).Minutes;
            employee.AddLast(new Employee(int.Parse("" + data[0]), "" + data[1], "" + "" + data[2], int.Parse("" + data[4]), int.Parse("" + data[5]), int.Parse("" + data[6]), int.Parse("" + data[7]), int.Parse("" + data[8]), int.Parse("" + data[9]), int.Parse("" + data[10]), int.Parse("" + data[11]), count, int.Parse("" + data[13])));
        }

        disconnect();

      
        return employee;
    }



    public int Vacation(int user)
    {
        string command;
        SqlCeCommand com;
        int vac=0;
        connect();

        command = "SELECT * FROM EmployeeData WHERE id = '" + user + "';";

        com = new SqlCeCommand(command, connection);

        SqlCeDataReader data = com.ExecuteReader();

        while (data.Read())
        {
            vac = int.Parse(""+data[11]);
        }

        disconnect();

        return vac ;
    }





    public int Sick(int user)
    {
        string command;
        SqlCeCommand com;
        int sic = 0;
        connect();

        command = "SELECT * FROM EmployeeData WHERE id = '" + user + "';";

        com = new SqlCeCommand(command, connection);

        SqlCeDataReader data = com.ExecuteReader();

        while (data.Read())
        {
            sic = int.Parse("" + data[10]);
        }

        disconnect();

        return sic;
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



       public LinkedList<Employee> GetAllEmployee()
        {
            LinkedList<Employee> employee = new LinkedList<Employee>();
            

            connect();
            string command = "SELECT * FROM EmployeeData ";

            SqlCeCommand com = new SqlCeCommand(command, connection);

            SqlCeDataReader data = com.ExecuteReader();

            while (data.Read())
            {
                employee.AddLast(new Employee(int.Parse("" + data[0]), "" + data[1], "" + "" + data[2], int.Parse("" + data[4]), int.Parse("" + data[5]), int.Parse("" + data[6]), int.Parse("" + data[7]), int.Parse("" + data[8]), int.Parse("" + data[9]), int.Parse("" + data[10]), int.Parse("" + data[11]), int.Parse("" + data[12]), int.Parse("" + data[13])));
            }

            disconnect();



            return employee;
        }



//כמות שעות שהעובד עבד באותו יום
       public int HoursWorkInDay(int user, DateTime date)
       {
        
           connect();
           
          string command = "SELECT * FROM EntryAndExit e1 WHERE  id = '" + user + "' AND  DateDiff(dd, e1.dateandtime, '" + date + "') = 0";

           SqlCeCommand com = new SqlCeCommand(command, connection);
           SqlCeDataReader data = com.ExecuteReader();

           int count = 0;
           while (data.Read())
           {
               count = date.Subtract(DateTime.Parse("" + data[14])).Minutes;
               return count;
           }

           disconnect();


           return count;

       }
        //כמות שעות שהוא עבד בחודש
       public int HoursWorkInMonth(int user)
       {
           connect();
           string command = "SELECT * FROM EmployeeData WHERE id = '" + user + "';";

           SqlCeCommand com = new SqlCeCommand(command, connection);

           SqlCeDataReader data = com.ExecuteReader();

           while (data.Read())
           {
               return int.Parse(""+data[13]);
           }

           disconnect();

           return 0;
       }
    /*   public void NewManger()
       {
           Employee employee = new Employee(302898739, "natali","grinberg",1,1000000, 90, 120, 4, 12, 25, 25,0,0);
           AddEmployee(employee);
           return;

       }*/



    }
}