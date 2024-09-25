using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.Warehouse
{
    public class WarehouseModel
    {
        public int BookingId { get; set; }
        public int CategoryId { get; set; }
        public int EnterpriseId { get; set; }
        [Required(ErrorMessage = "Please select warehouse for booking.")]
        public string WarehouseId { get; set; }
        [Required(ErrorMessage = "Please enter required size.")]

        public string RequiredSize { get; set; }
        [Required(ErrorMessage = "Please enter required from date.")]

        public DateTime RequiredFrom { get; set; }
        [Required(ErrorMessage = "Please enter required till date.")]

        public DateTime ReqioredTill { get; set; }
        [Required(ErrorMessage = "Please enter warehouse description.")]
        public string WarehouseDescription { get; set; }

        public int Createdby { get; set; }

        public DataTable Map_Warehousebooking_TT { get; set; }

        public int StorageTypeId { get; set; }
        public string StorageArea { get; set; }

        public string ApproverDescription { get; set; }

    }
}
