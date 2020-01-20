using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMart
{
 
        class BuyerBO
        {

            static List<Buyer> blist = new List<Buyer>();
            public void Bsignup(string name, string password, string emailid, int mobileno)
            {
                blist.Add(new Buyer(name, password, emailid, mobileno));
            }
            public bool login(string name1, string password1)
            {

                Buyer b = blist.Find(e => e.name == name1 && e.password == password1);
                if (b != null)
                {
                    Console.WriteLine("Hi");
                    return true;
                }
                else
                    return false;


            }
        }
    }

