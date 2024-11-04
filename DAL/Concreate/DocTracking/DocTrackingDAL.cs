using DAL.Interface.DocTracking;
using Model.Models;
using Model.Models.TrackingDocument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concreate.DocTracking
{
    public class DocTrackingDAL : BaseClassDAL, IDocTrackingDAL
    {
        LFTZ_InvestorPortalEntities entities = new LFTZ_InvestorPortalEntities();


        public ResponseInfo Save(TrackingDocModel model)
        {
            return new ResponseInfo();
        }
    }
}
