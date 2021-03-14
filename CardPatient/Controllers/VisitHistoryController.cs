using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CardPatient.Mediator.WorkWithVisitHistory;
using CardPatient.Models;

namespace CardPatient.Controllers
{
    public class VisitHistoryController : Controller
    {
        // GET: VisitHistory
        [HttpGet]   
        public ActionResult FillVisit(int id=0)
        {
            FillVisitMediator fillVisit = new FillVisitMediator();
            return View(fillVisit.VisitForm());
        }
        [HttpPost]
        public ActionResult FillVisit(visitHistory visit)
        {
            FillVisitMediator fillVisit = new FillVisitMediator();
            if (fillVisit.AddVisitToVisitHistory(visit))
            {
                ModelState.Clear();
                ViewBag.SuccesMessage = "succeful";
                return View("FillVisit", fillVisit.VisitForm());
            }
            else
            {
                return RedirectToAction("FillVisit");
            }
        }
    }
}