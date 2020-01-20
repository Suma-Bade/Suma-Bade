using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMart
{
    class SellerBo
    {
        static List<Seller> slist = new List<Seller>();
        public void Ssignup(string name, string password, string emailid, int mobileno, string companyname, string briefabtcmpy, string address, string website, int GST)
        {
            slist.Add(new Seller(name, password, emailid, mobileno, companyname, briefabtcmpy, address, website, GST));
        }
        public bool login(string name1, string password1)
        {
            Seller s = slist.Find(e => e.name == name1 && e.password == password1);
            if (s != null)
            {
                Console.WriteLine("Welcome");
                return true;
            }
            else
                return false;
        }
    }
}
