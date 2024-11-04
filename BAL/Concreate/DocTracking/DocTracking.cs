using DAL.Interface.DocTracking;
using BAL.Interface.DocTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Concreate.DocTracking;
using Model.Models;
using Model.Models.TrackingDocument;

namespace BAL.Concreate.DocTracking
{
    public class DocTracking : IDocTracking
    {
        private IDocTrackingDAL _iDocTrackDAL;

        public DocTracking()
        {
            _iDocTrackDAL = BALFactory.GetDocTrackingDALInstance();
        }

        public ResponseInfo Save(TrackingDocModel model)
        {
            return _iDocTrackDAL.Save(model);
        }

    }
}
