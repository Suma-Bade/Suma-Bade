using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMart
{
    class Item
    {
        public int id { get; set; }
        //int GST;
        public int price { get; set; }
        public string item_name { get; set; }
        public string description { get; set; }
        public int stock_number { get; set; }
        public string remarks { get; set; }


        SubCategory subcategory;
        public Item(int id, int price, string item_name, string description, int stock_number, string remarke, SubCategory sb)
        {
            this.id = id;
            this.price = price;
            this.item_name = item_name;
            this.description = description;
            this.stock_number = stock_number;
            this.remarks = remarke;
            this.subcategory = sb;
        }

       

        public override string ToString()
        {
            return "Item Id: " + this.id + "\nItem Name: " + this.item_name + "\nItem Price: " + this.price + "\nItem Description: " + this.description + "\nItem Stock Number: " + this.stock_number + "\nItem Remarks: " + this.remarks + "\n" + this.subcategory;
        }
        //subcategory_id + "\n" + this.subcategory_name + "\n" + this.brief_details + "\n" + this.GST + "\n" + this.category_id + "\n" + this.category_name;
    }
}

