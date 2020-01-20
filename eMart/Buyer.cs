using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMart
{
    class Buyer
    {
        //int id;
        public string name, password, emailid;
        int mobileno;
        public Buyer(string name, string password, string emailid, int mobileno)
        {
            this.name = name;
            this.password = password;
            this.emailid = emailid;
            this.mobileno = mobileno;
        }

    }
}
