﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.FacilityRTD
{
    public class EditMeterReadingModel
    {

        public int MId { get; set; }

        public int YearId { get; set; }

        public string YearName { get; set; }

        public int MonthId { get; set; }

        public string MonthName { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int SubcategoryId { get; set; }

        public string SubcategoryName { get; set; }

        [Range(0, 99999999999.99)]
        public decimal MeterReading { get; set; }

        public int Createdby { get; set; }

        public System.DateTime Createddate { get; set; }

        public Nullable<int> Modifiedby { get; set; }

        public Nullable<System.DateTime> Modifieddate { get; set; }

        public bool IsActive { get; set; }
    }
}
