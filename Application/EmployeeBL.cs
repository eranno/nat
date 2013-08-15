using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application
{
    public class EmployeeBL
    {
        private EmployeeDAL dal = new EmployeeDAL();

        //מכניס שעת כניסה או שעת יציאה
        /**
         * @in = 1
         * @out = 0
         */
        public bool LogInorOut(int user, string pas, int inorout)
        {
            return dal.LogInorOut(user,pas,inorout); 
        }

        public bool NewManger()
        {
           Employee employee = new Employee(302898739, "natali", "grinberg", 1, 1000000, 90, 120, 4, 12, 25, 25, 0, 0);
          bool ok = AddEmployee(employee);
          return ok;
        }

        public bool IsEmployeeExist(int user)
        {
            Employee emp = dal.GetEmployeeId(user);
            if (emp != null)
                return true;

            return false;
        }

        //בודק אם זה מנהל או עובד
        public bool IsManger(int user)
        {
          return dal.IsManger(user);
        }

        //מקבל את כל הפרטים של העובד חוץ מסיסמא
        public Employee GetEmployeeId(int user)
        {
            return dal.GetEmployeeId(user);
        }

        public Employee GetEmployeeName(string first, string last)
        {
            return dal.GetEmployeeName(first,last);
        }

        //הוספת עובד חדש לDB
        public bool AddEmployee(Employee m)
        {
            bool exist;
            exist = IsEmployeeExist(m.Id);
            if (exist == true)
                return false;

            dal.AddEmployee(m);
            return true;
        }

        //if work=true the password change
        public bool ChangePassword(int user, string oldpass, string newpass1, string newpass2)
        {
            bool work= dal.ChangePassword(user, oldpass, newpass1, newpass2);
            return work;
        }

        //מחזיר את כל העובדים עם כל הנתונים שלהם שנמצאים עכשיו בעבודה
        public LinkedList<Employee> GetAllEmployeeInWork()
        {
            return dal.GetAllEmployeeInWork();
        }

        public int Vacation(int user)
        {
            return dal.Vacation(user);
        }


        public int Sick(int user)
        {
            return dal.Sick(user);
        }


        //מחזירה את כמות השעות שכל העובדים עובדים כרגע
        public int CountWorker(LinkedList<Employee> emp)
        {
            return dal.CountWorker(emp);
        }

        public LinkedList<Employee> GetAllEmployee()
        {
            return dal.GetAllEmployee();
        }

        //parse string to int. on fail return -1;
        public int toInt(string Str)
        {
            Str = Str.Trim();
            int Num;
            bool isNum = int.TryParse(Str, out Num);
            if (isNum)
                return Num;
            else
                return -1;
        }


        public LinkedList<Massege> GetMassege(int user)
        {
            return dal.GetMassege(user);
        }

        /*
         * types:
         * 1=sick
         * 2=vacation
         * 3=fast
         * 4=job
         * 5=vacation request
         */
        public void SetMassege(int idreceiver, int idsender, int type, string note)
        {
            DateTime date = DateTime.Now;
            string dateoftime = date.ToString("MM/dd/yyyy");
            Massege mes = new Massege(idreceiver, idsender, type, note, 0, dateoftime, 0);
           dal.SetMassege(mes);
           return;
        }



        
          public void SetIsRead(int id)
           {
              dal.SetIsRead(id);
           }
          
          public LinkedList<Report> Reports(int user, DateTime date)
           {
               return dal.Reports(user, date);
           }


          public string Type(int x)
          {
              return dal.Type(x);
          }


          public bool ChangeWorker(Employee empnew)
          {
              return dal.ChangeWorker(empnew);
          }

    }
}