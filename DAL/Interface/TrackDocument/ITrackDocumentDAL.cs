using Model.Models;
using Model.Models.TrackingDocument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.TrackDocument
{
    public interface ITrackDocumentDAL
    {
        ResponseInfo SaveOrUpdateDAL(TrackingDocModel model);
        List<TrackingDocModel> TrackingDocListDAL();
    }
}
