using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMart
{
    class ItemBO
    {
        static List<Item> ilist = new List<Item>();
        static List<SubCategory> clist = new List<SubCategory>();

        public void additems(int id, int price, string item_name, string description, int stock_number, string remarke, string subcategory_id, string subcategory_name, string brief_details, int GST, string category_id, string category_name)
        {
            SubCategory sb1 = new SubCategory(subcategory_name, subcategory_id, brief_details, GST, category_id, category_name);

            ilist.Add(new Item(id, price, item_name, description, stock_number, remarke, sb1));
        }
        public void displayItems()
        {
            foreach (var i in ilist)
            {
                Console.WriteLine(i.ToString());
            }
        }
        public Item Search(string ItemName)
        {
            Item item = ilist.Find(e => e.item_name == ItemName);
            return item;
        }
    }
}
