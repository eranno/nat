using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application
{
    public class Employee
    {
        private string password;
        private string lastName;
        private string firstName; 
        private int id;

        private int sick;
        private int vacation;

        private int minhours;
        private int maxhours;
        private int overtimeinday;
        private int rank;//דרגה
        private int wage;
       // private int overtimeWages;
        private int overtimeinmonth;
        private int timeheworkonday;
        private int timeheworkonmonth;


        //מה שהמנהל יכול למלאות על עובד חדש טבלת עובדים
        public Employee(int id, string firstName, string lastName, int rank, int wage, int minhours, int maxhours, int overtimeinday, int overtimeinmonth, int sick, int vacation, int timeheworkonday, int timeheworkonmonth)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.id = id;
            this.password = "0000";
            this.rank = rank;
            this.wage = wage;
            this.maxhours = maxhours;
            this.minhours = minhours;
         //   this.overtimeWages = overtimeWages;
            this.overtimeinmonth = overtimeinmonth;
            this.overtimeinday = overtimeinday;
            this.sick = sick;
            this.vacation = vacation;

            this.timeheworkonday = timeheworkonday;

            this.timeheworkonmonth = timeheworkonmonth;
          
        }

        public int Id
        {
            set
            {
                this.id = value;
            }
            get
            {
                return this.id;
            }
        }


        public string  LastName
        {
            set
            {
                this.lastName = value;
            }
            get
            {
                return this.lastName;
            }
        }


        public string FirstName
        {
            set
            {
                this.firstName = value;
            }
            get
            {
                return this.firstName;
            }
        }




        public string Password
        {
            set
            {
                this.password = value;
            }
            get
            {
                return this.password;
            }
        }



        public int Minhours
        {
            set
            {
                this.minhours = value;
            }
            get
            {
                return this.minhours;
            }
        }


        public int Maxhours
        {
            set
            {
                this.maxhours = value;
            }
            get
            {
                return this.maxhours;
            }
        }

          public int Vacation
          {
              set
              {
                  this.vacation = value;
              }
              get
              {
                  return this.vacation;
              }
          }


          public int Sick
          {
              set
              {
                  this.sick = value;
              }
              get
              {
                  return this.sick;
              }
          }

        public int Wage
        {
            set
            {
                this.wage = value;
            }
            get
            {
                return this.wage;
            }
        }


        public int Rank
        {
            set
            {
                this.rank = value;
            }
            get
            {
                return this.rank;
            }
        }



        public int Overtimeinday
        {
            set
            {
                this.overtimeinday = value;
            }
            get
            {
                return this.overtimeinday;
            }
        }




        public int Overtimeinmonth
        {
            set
            {
                this.overtimeinmonth = value;
            }
            get
            {
                return this.overtimeinmonth;
            }
        }

     
        public int Timeheworkonday
        {
            set
            {
                this.timeheworkonday = value;
            }
            get
            {
                return this.timeheworkonday;
            }
        }

        public int Timeheworkonmonth
        {
            set
            {
                this.timeheworkonmonth = value;
            }
            get
            {
                return this.timeheworkonmonth;
            }
        }
    }
}