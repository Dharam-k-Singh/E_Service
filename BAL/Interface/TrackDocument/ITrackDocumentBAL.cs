using Model.Models;
using Model.Models.TrackingDocument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface.TrackDocument
{
    public interface ITrackDocumentBAL
    {
        ResponseInfo SaveOrUpdateBAL(TrackingDocModel model);
        List<TrackingDocModel> TrackingDocListBAL();
        List<TrackDocStatusModel> TrackingDocHistoryListByIdBAL(int trackDocId);

    }
}
