using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMart
{
    class Seller
    {
        public string name, password, emailid, companyname, briefabtcmpy, address, website;
        int mobileno, GST;
        public Seller(string name, string password, string emailid, int mobileno, string companyname, string briefabtcmpy, string address, string website, int GST)
        {
            this.name = name;
            this.password = password;
            this.emailid = emailid;
            this.mobileno = mobileno;
            this.companyname = companyname;
            this.briefabtcmpy = briefabtcmpy;
            this.address = address;
            this.website = website;
            this.GST = GST;
        }
    }
}
