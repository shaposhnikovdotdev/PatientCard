using CardPatient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CardPatient.Mediator.WorkWithPatient;

namespace CardPatient.Controllers
{
    public class CustomerPatientController : Controller
    {
        // GET: CustomerPatient
        public ActionResult CustomerPatients()
        {
            PatientMediator patientMediator = new PatientMediator();
                return View(patientMediator.GetListOfPatients());
        }
    
        public ActionResult Edit(int id)
        {
            PatientMediator patientMediator = new PatientMediator();
            return View(patientMediator.GetCurrentPatientById(id));
        }
        [HttpPost]
        public ActionResult Edit(int id, patients patient)
        {
            PatientMediator patientMediator = new PatientMediator();
            if (patientMediator.EditCurrentPatient(id, patient))
            {
                return RedirectToAction("CustomerPatients");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            PatientMediator patientMediator = new PatientMediator();
            return View(patientMediator.GetCurrentPatientById(id));
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            PatientMediator patientMediator = new PatientMediator();
            if (patientMediator.DeleteCurrentUser(id, collection))
            {
                return RedirectToAction("CustomerPatients");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Search(string searchingUin)
        {
            PatientMediator patientMediator = new PatientMediator();
            var patient = patientMediator.SearchCurrentPatient(searchingUin);
            if (patient == null)
            {
                return RedirectToAction("CustomerPatients");
            }
            else
            {
                return View("Search", patient);
            }
        }
    }
}