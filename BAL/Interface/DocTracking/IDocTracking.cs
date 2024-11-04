using Model.Models;
using Model.Models.TrackingDocument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.Interface.DocTracking
{
    public interface IDocTracking
    {
        ResponseInfo Save(TrackingDocModel model);

    }
}
