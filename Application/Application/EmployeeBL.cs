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
          // bool ok=  dal.NewManger();
          
           Employee employee = new Employee(302898739, "natali", "grinberg", 1, 1000000, 90, 120, 4, 12, 25, 25, 0, 0);
          bool ok= AddEmployee(employee);
           return ok;
        }



        public bool IsEmployeeExist(int user)
        {
            Employee emp = dal.GetEmployee(user);
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
        public Employee GetEmployee(int user)
        {
            return dal.GetEmployee(user);

        }




        //הוספת עובד חדש לDB
        public bool AddEmployee(Employee m)
        {
           /* dal.AddEmployee(m);
            return;*/

            bool exist;
            exist = IsEmployeeExist(m.Id);
            if (exist == true)
                return false;


            dal.AddEmployee(m);
            return true;
        }



        //if ok=true the password change
        public void ChangePassword(int user, string newpas)
        {
            dal.ChangePassword(user,newpas);
            return;
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



    }
}