using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMart
{
    class Program
    {
        
       
            public static void Main(string[] args)
            {
                //int id;
                int id;
                int price;
                string item_name;
                string description;
                int stock_number;
                string remarks;
                string category_id;
                string subcategory_id;
                string subcategory_name;
                string category_name;
                string brief_details;
                string name, password, emailid, repassword, companyname, briefabtcmpy, address, website;
                int mobileno, GST;
                DateTime dt = DateTime.Now;
                SellerBo so = new SellerBo();
                BuyerBO bo = new BuyerBO();
                ItemBO io = new ItemBO();
                Console.WriteLine("Welcome to E-Mart Console App\n");
                Console.WriteLine("Menu\n");
                while (true)
                {
                    Console.WriteLine("Please  Enter b for Buyer and s for Seller");
                    char a = char.Parse(Console.ReadLine());
                    Console.WriteLine("New User.Choose 1\n");
                    Console.WriteLine("1.SignUp\t2.Sign In\n");
                    Console.WriteLine("Enter Your Choice:");
                    int ch = int.Parse(Console.ReadLine());
                    if (a == 'b')
                    {
                        switch (ch)
                        {
                            case 1:

                                Console.WriteLine("Enter UserName");
                                name = Console.ReadLine();
                                while (true)
                                {
                                    Console.WriteLine("Enter password");
                                    password = Console.ReadLine();
                                    Console.WriteLine("ReEnter password");
                                    repassword = Console.ReadLine();
                                    if (password == repassword)
                                    {
                                        break;

                                    }
                                    else
                                    {
                                        Console.WriteLine("password doesnot match");

                                    }
                                }
                                Console.WriteLine("Enter Email id");
                                emailid = Console.ReadLine();
                                Console.WriteLine("Enter Mobile Number");
                                mobileno = int.Parse(Console.ReadLine());
                                Console.WriteLine(dt);
                                bo.Bsignup(name, password, emailid, mobileno);
                                Console.WriteLine("Now Sign in");
                                break;
                            case 2:
                                while (true)
                                {
                                    Console.WriteLine("Enter UserName");
                                    string name1 = Console.ReadLine();
                                    Console.WriteLine("Enter Password");
                                    string password1 = Console.ReadLine();
                                    bool status = bo.login(name1, password1);
                                    if (status == true)
                                    {
                                        Console.WriteLine("valid");
                                        break;
                                    }
                                    else
                                        Console.WriteLine("Invalid");
                                }
                                Console.WriteLine("List Of Items:\n1.Electronics\t2.Beauty,Health\t3.Grocery\t4.Men's Fashion \t5.Women's Fashion\t6.Kids Toys");
                                Console.WriteLine("Enter Your choice");
                                int ch1 = int.Parse(Console.ReadLine());
                                if (ch1 == 1||ch==2||ch==3||ch==4||ch==5||ch==6 )
                                {
                                    Console.WriteLine("enter item that you want to search");
                                string ItemName = Console.ReadLine();
                                Item sitem = io.Search(ItemName);
                                if (sitem != null)
                                {
                                    Console.WriteLine(sitem.ToString());
                                }
                                else
                                {
                                    Console.WriteLine("not found");
                                }
                                    

                                }
                                break;

                        }

                    }
                    else if (a == 's')
                    {

                        switch (ch)
                        {
                            case 1:
                                Console.WriteLine("Enter UserName");
                                name = Console.ReadLine();
                                while (true)
                                {
                                    Console.WriteLine("Enter password");
                                    password = Console.ReadLine();
                                if(password.Length<8)
                                {
                                    Console.WriteLine("passwors should have greater than 8 characters");
                                }
                                    Console.WriteLine("ReEnter password");
                                    repassword = Console.ReadLine();
                                    if (password == repassword)
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("password doesnot match");

                                    }
                                }
                                Console.WriteLine("Enter Email id");
                                emailid = Console.ReadLine();
                                Console.WriteLine("Enter Mobile Number");
                                mobileno = int.Parse(Console.ReadLine());
                                Console.WriteLine("Enter Company Name");
                                companyname = Console.ReadLine();
                                Console.WriteLine("Enter about Company");
                                briefabtcmpy = Console.ReadLine();
                                Console.WriteLine("Enter Address");
                                address = Console.ReadLine();
                                Console.WriteLine("Enter WebSite");
                                website = Console.ReadLine();
                                Console.WriteLine("Enter GSTIN");
                                GST = int.Parse(Console.ReadLine());
                                Console.WriteLine(dt);
                                so.Ssignup(name, password, emailid, mobileno, companyname, briefabtcmpy, address, website, GST);
                                Console.WriteLine("Now Sign in");
                                break;
                            case 2:
                                while (true)
                                {
                                    Console.WriteLine("Enter UserName");
                                    string name1 = Console.ReadLine();
                                    Console.WriteLine("Enter Password");
                                    string password1 = Console.ReadLine();
                                    bool status = so.login(name1, password1);
                                    if (status == true)
                                    {
                                        Console.WriteLine("valid");
                                        break;
                                    }
                                    else
                                        Console.WriteLine("Invalid");
                                }
                                Console.WriteLine("List Of Items:\n1.Electronics\t2.Grocery\t3.Fashion");
                                Console.WriteLine("Enter Your choice");
                                int ch1 = int.Parse(Console.ReadLine());
                                if (ch1 == 1)
                                {
                                    Console.WriteLine("List Of Items:\n1.Mobiles\t2.Laptops\t3.Home appliances");
                                    Console.WriteLine("Enter Your choice");
                                    int ch2 = int.Parse(Console.ReadLine());
                                    if (ch2 == 1 || ch2 == 2 || ch2 == 3)
                                    {
                                        Console.WriteLine("Enter Id");
                                        id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter Itemname");
                                        item_name = Console.ReadLine();
                                        Console.WriteLine("Enter Price");
                                        price = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter description about product");
                                        description = Console.ReadLine();
                                        Console.WriteLine("Enter stock number");
                                        stock_number = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter Remarks");
                                        remarks = Console.ReadLine();
                                        Console.WriteLine("Enter CategoryId");
                                        category_id = Console.ReadLine();
                                        Console.WriteLine("Enter Category Name");
                                        category_name = Console.ReadLine();
                                        Console.WriteLine("Enter SubCategoryId");
                                        subcategory_id = Console.ReadLine();
                                        Console.WriteLine("Enter SubCategory Name");
                                        subcategory_name = Console.ReadLine();
                                        Console.WriteLine("Enter GST");
                                        GST = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter BriefDetails");
                                        brief_details = Console.ReadLine();
                                        io.additems(id, price, item_name, description, stock_number, remarks, subcategory_id, subcategory_name, brief_details, GST, category_id, category_name);
                                        io.displayItems();
                                    }
                                }
                                else if (ch1 == 2)
                                {
                                    Console.WriteLine("List Of Items:\n1.Vegetables\t2.Cerals");
                                    Console.WriteLine("Enter Your choice");
                                    int ch2 = int.Parse(Console.ReadLine());
                                    if (ch2 == 1 || ch2 == 2)
                                    {
                                        Console.WriteLine("Enter Id");
                                        id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter Itemname");
                                        item_name = Console.ReadLine();
                                        Console.WriteLine("Enter Price");
                                        price = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter description about product");
                                        description = Console.ReadLine();
                                        Console.WriteLine("Enter stock number");
                                        stock_number = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter Remarks");
                                        remarks = Console.ReadLine();
                                        Console.WriteLine("Enter CategoryId");
                                        category_id = Console.ReadLine();
                                        Console.WriteLine("Enter Category Name");
                                        category_name = Console.ReadLine();
                                        Console.WriteLine("Enter SubCategoryId");
                                        subcategory_id = Console.ReadLine();
                                        Console.WriteLine("Enter SubCategory Name");
                                        subcategory_name = Console.ReadLine();
                                        Console.WriteLine("Enter GST");
                                        GST = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter BriefDetails");
                                        brief_details = Console.ReadLine();
                                        io.additems(id, price, item_name, description, stock_number, remarks, subcategory_id, subcategory_name, brief_details, GST, category_id, category_name);
                                        io.displayItems();
                                    }
                                }
                                if (ch1 == 3)
                                {
                                    Console.WriteLine("List Of Items:\n1.Mens\t2.Womens\t3.Kids");
                                    Console.WriteLine("Enter Your choice");
                                    int ch2 = int.Parse(Console.ReadLine());
                                    if (ch2 == 1 || ch2 == 2 || ch2 == 3)
                                    {
                                        Console.WriteLine("Enter Id");
                                        id = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter Itemname");
                                        item_name = Console.ReadLine();
                                        Console.WriteLine("Enter Price");
                                        price = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter description about product");
                                        description = Console.ReadLine();
                                        Console.WriteLine("Enter stock number");
                                        stock_number = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter Remarks");
                                        remarks = Console.ReadLine();
                                        Console.WriteLine("Enter CategoryId");
                                        category_id = Console.ReadLine();
                                        Console.WriteLine("Enter Category Name");
                                        category_name = Console.ReadLine();
                                        Console.WriteLine("Enter SubCategoryId");
                                        subcategory_id = Console.ReadLine();
                                        Console.WriteLine("Enter SubCategory Name");
                                        subcategory_name = Console.ReadLine();
                                        Console.WriteLine("Enter GST");
                                        GST = int.Parse(Console.ReadLine());
                                        Console.WriteLine("Enter BriefDetails");
                                        brief_details = Console.ReadLine();
                                        io.additems(id, price, item_name, description, stock_number, remarks, subcategory_id, subcategory_name, brief_details, GST, category_id, category_name);
                                        io.displayItems();
                                    }
                                }
                                break;
                            default: break;
                        }

                    }
                }
            }


        }


    }




