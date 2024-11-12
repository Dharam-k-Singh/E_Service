using DAL.Interface.TrackDocument;
using Model.Models;
using Model.Models.TrackingDocument;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concreate.TrackDocument
{
    public class TrackDocumentDAL : BaseClassDAL, ITrackDocumentDAL
    {
        LFTZ_InvestorPortalEntities entities = new LFTZ_InvestorPortalEntities();

        public ResponseInfo SaveOrUpdateDAL(TrackingDocModel model)
        {
            ObjectParameter outId = new ObjectParameter("OutId", typeof(int));
            ObjectParameter outDevMssg = new ObjectParameter("OutId", typeof(string));
            ObjectParameter outUserMssg = new ObjectParameter("OutId", typeof(string));
            ObjectParameter outIsSuccess = new ObjectParameter("OutId", typeof(bool));

            return new ResponseInfo();
        }

        public List<TrackingDocModel> TrackingDocListDAL()
        {
            var result = entities.EnterpriseRole_G().ToList();
            return Mapping<List<TrackingDocModel>>(result);
        }

    }
}
