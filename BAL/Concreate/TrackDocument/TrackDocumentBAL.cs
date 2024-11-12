using BAL.Interface.TrackDocument;
using DAL.Interface.TrackDocument;
using Model.Models;
using Model.Models.TrackingDocument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Concreate.TrackDocument
{
    public class TrackDocumentBAL : ITrackDocumentBAL
    {
        private ITrackDocumentDAL _iTrackDocDAL;
        public TrackDocumentBAL()
        {
            _iTrackDocDAL = BALFactory.GetTrackDocDALInstance();
        }
        public ResponseInfo SaveOrUpdateBAL(TrackingDocModel model)
        {
            return _iTrackDocDAL.SaveOrUpdateDAL(model);
        }
        public List<TrackingDocModel> TrackingDocListBAL()
        {
            return _iTrackDocDAL.TrackingDocListDAL();
        }
    }
}
