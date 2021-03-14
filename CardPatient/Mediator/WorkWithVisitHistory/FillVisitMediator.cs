using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CardPatient.Models;

namespace CardPatient.Mediator.WorkWithVisitHistory
{
    public class FillVisitMediator
    {
        public visitHistory VisitForm()
        {
            visitHistory visit = new visitHistory();
            return visit;
        }
        public bool AddVisitToVisitHistory(visitHistory visit)
        {
            using (DbModels model = new DbModels())
            {
                try
                {
                    model.visitHistory.Add(visit);
                    model.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }

            }
        }
    }
}