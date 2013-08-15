using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application
{
    public class Massege
    {
        private int idreceiver;
        private int idsender;
        private int type;
        private string note;
        private int approve;
        private string date;
        private int read;
        private string lastName;
        private string firstName; 

        public Massege(int idreceiver, int idsender, int type, string note, int approve, string date, int read, string firstname=null, string lastname=null)
        {
            this.idreceiver = idreceiver;
            this.idsender = idsender;
            this.type = type;
            this.note = note;
            this.approve = approve;
            this.date = date;
            this.read = read;
            this.firstName = firstname;
            this.lastName = lastname;
        }



        public int Idreceiver
        {
            set
            {
                this.idreceiver = value;
            }
            get
            {
                return this.idreceiver;
            }
        }


        public int Idsender
        {
            set
            {
                this.idsender = value;
            }
            get
            {
                return this.idsender;
            }
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


        public int Approve
        {
            set
            {
                this.approve = value;
            }
            get
            {
                return this.approve;
            }
        }



        public string Date
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


        public int Read
        {
            set
            {
                this.read = value;
            }
            get
            {
                return this.read;
            }
        }



        public string LastName
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

    }
}