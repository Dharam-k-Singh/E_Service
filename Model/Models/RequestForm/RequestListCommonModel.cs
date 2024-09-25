using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models.RequestForm
{
    public class RequestListCommonModel
    {

        public List<RequestFormListModel> RequestEnterpriseList { get; set; }

        public RequestRatingModel SaveFeedbackRating { get; set; }

        public ReOpenTicketChangeStatus ReOpenTicketStatus { get; set; }
    }
}
