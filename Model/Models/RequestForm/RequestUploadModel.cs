using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.RequestForm
{
     public class RequestUploadModel
    {
        public int UploadTypeId { get; set; }
        public string UploadFilename { get; set; }
        public string UploadFilePath { get; set; }
    }
}
