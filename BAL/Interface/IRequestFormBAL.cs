using Model.Models;
using Model.Models.RequestForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface.
{
    public interface IRequestFormBAL
    {
        ResponseInfo SaveRequestBAL(RequestFormModel model);

        List<RequestFormListModel> GetLFZReqListBAL(int userId);
    }
}
