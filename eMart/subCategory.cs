using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMart
{
    public class SubCategory : Category
    {
        string subcategory_id;
        string subcategory_name;
        string brief_details;
        int GST;

        
        public SubCategory(string subcategory_id, string subcategory_name, string brief_details, int GST, string category_id, string category_name) :
            base(category_id, category_name, brief_details)
        {
            this.subcategory_id = subcategory_id;
            this.subcategory_name = subcategory_name;
            this.brief_details = brief_details;
            this.GST = GST;
        }

        public string Subcategory_id { get => subcategory_id; set => subcategory_id = value; }
        public string Subcategory_name { get => subcategory_name; set => subcategory_name = value; }
        public string Brief_details { get => brief_details; set => brief_details = value; }
        public int GST1 { get => GST; set => GST = value; }
        public override string ToString()
        {
            return "SubCategory Id: " + this.subcategory_id + "\nSubCategory Name: " + this.subcategory_name + "\nBrief Details: " + this.brief_details + "\nGST: " + this.GST + "\nCategory_id: " + this.category_id + "\nCategory_name: " + this.category_name;
        }
    }
}
