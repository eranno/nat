using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application
{
    public class Report
    {
     private int type;
        private string note;
        private DateTime date;
        private DateTime entry;
        private DateTime exit;
        private int excesshours;
        private int lackhours;
        private int hours;



        public Report()//(DateTime date, int type, string note, DateTime entry, DateTime exit,int hours, int lackhours, int excesshours)
        {

            this.entry = DateTime.MinValue;
            this.exit = DateTime.MinValue;
            this.type = -1;
            this.note = "";

            this.date = DateTime.MinValue;
            this.lackhours = 0;
            this.excesshours = 0;
            this.hours = 0;
        }



        public int Type
        {
            set
            {
                this.type = value;
            }
            get
            {
                return this.type;
            }
        }



        public string Note
        {
            set
            {
                this.note = value;
            }
            get
            {
                return this.note;
            }
        }

        public int Excesshours
        {
            set
            {
                this.excesshours = value;
            }
            get
            {
                return this.excesshours;
            }
        }


        public int Lackhours
        {
            set
            {
                this.lackhours = value;
            }
            get
            {
                return this.lackhours;
            }
        }



        public int Hours
        {
            set
            {
                this.hours = value;
            }
            get
            {
                return this.hours;
            }
        }




        public DateTime Entry
        {
            set
            {
                this.entry = value;
            }
            get
            {
                return this.entry;
            }
        }


           public DateTime Date
        {
            set
            {
                this.date = value;
            }
            get
            {
                return this.date;
            }
        }


           public DateTime Exit
        {
            set
            {
                this.exit = value;
            }
            get
            {
                return this.exit;
            }
        }


    }
}
