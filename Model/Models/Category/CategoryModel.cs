using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Category
{
    public class CategoryModel
    {

        public int CategoryID { get; set; }

        public int RequestTypeId { get; set; }

        public string CategoryName { get; set; }
   
        public int ParentCategoryID { get; set; }

        public int Createdby { get; set; }

        public System.DateTime Createddate { get; set; }

        public Nullable<int> Modifiedby { get; set; }

        public Nullable<System.DateTime> Modifieddate { get; set; }

        public bool IsActive { get; set; }
    }
}
