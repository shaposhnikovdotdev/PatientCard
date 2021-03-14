using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CardPatient.Mediator.WorkWithPatient;
using CardPatient.Models;

namespace CardPatient.Controllers
{
    public class PatientController : Controller
    {
        // GET: Patient
        [HttpGet]
        public ActionResult AddPatient(int id = 0)
        {
            PatientMediator patientMediator = new PatientMediator();
            return View(patientMediator.AddNewPatientForm());
        }
        [HttpPost]
        public ActionResult AddPatient(patients patient)
        {
            PatientMediator patientMediator = new PatientMediator();
            if (!patientMediator.AddNewPatient(patient))
            {
                ViewBag.DuplicateMessage = "Данный ИИН уже зарегистрирован";
                return RedirectToAction("AddPatient");
            }
            else {
            ModelState.Clear();
            ViewBag.SuccesMessage = "Registration succefusl";
            return View("AddPatient", patientMediator.AddNewPatientForm());
            }
        }
    }
}