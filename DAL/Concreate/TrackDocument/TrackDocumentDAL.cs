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
            ObjectParameter outDevMssg = new ObjectParameter("OutDevMssg", typeof(string));
            ObjectParameter outUserMssg = new ObjectParameter("OutUserMssg", typeof(string));
            ObjectParameter outIsSuccess = new ObjectParameter("OutIsSuccess", typeof(bool));

            entities.TrackDoc_CU(model.TrackDocId, model.SenderOrgName, model.DocType, model.OtherDocType, model.Subject, model.DocSummary
                                , model.ToMailIds, model.DetailedDescription, model.DocumentStatus, model.RequiredAction, model.ActionDate
                                , model.ReceivedDate, model.RequiredAttention, model.CCMailIds, model.UploadDoc, model.ChangedBy
                                , outId, outUserMssg, outDevMssg, outIsSuccess);

            return new ResponseInfo() 
            {
                ID = (int)outId.Value,
                Msg = outUserMssg.Value.ToString(),
                Status = outDevMssg.Value.ToString(),
                IsSuccess = (bool)outIsSuccess.Value
            };
        }

        public List<TrackingDocModel> TrackingDocListDAL()
        {
            var result = entities.TrackDocList_G().ToList();
            return Mapping<List<TrackingDocModel>>(result);
        }
        public List<TrackDocStatusModel> TrackingDocHistoryListByIdDAL(int trackDocId)
        {
            var result = entities.EnterpriseRole_G().ToList();
            return Mapping<List<TrackDocStatusModel>>(result);
        }

    }
}
