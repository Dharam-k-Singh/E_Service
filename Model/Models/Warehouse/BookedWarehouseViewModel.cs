using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Warehouse
{
    public class BookedWarehouseViewModel
    {
        public int BookingId { get; set; }
        public string EnterpriseId { get; set; }
        public string OrganizationName { get; set; }
        public string SizeRequired { get; set; }
       
        public DateTime RequiredFrom { get; set; }
        public DateTime RequiredTo { get; set; }
        public string WarehouseDescription { get; set; }
        public string StorageArea { get; set; }
        public string ApproverDescription { get; set; }
        public string CheckerName { get; set; }
        public string Category { get; set; }
        public int StorageTypeId { get; set; }

        public string StorageType { get; set; }
        public string WarehouseIds { get; set; }
        public int CategoryId { get; set; }
    }
}
