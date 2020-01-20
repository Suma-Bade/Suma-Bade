using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eMart
{
  
        public abstract class Category
        {
            public string category_id { get; set; }
            public string category_name { get; set; }
            public string brief_details { get; set; }

            public Category(string category_id, string category_name, string brief_details)
            {
                this.category_id = category_id;
                this.category_name = category_name;
                this.brief_details = brief_details;

            }
         }
}
