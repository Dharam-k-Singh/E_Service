using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.RequestForm
{
    public class RequestAdminListCommonModel
    {

        public List<RequestListAdminModel> RequestListAdmin { get; set; }

        public RequestActionAdminModel RequestSaveActionAdmin { get; set; }

        public List<RequestWorkingListModel> RequestWorkingList { get; set; }

        public List<RequestHistoryListModel> RequestHistoryList { get; set; }
    }
}
