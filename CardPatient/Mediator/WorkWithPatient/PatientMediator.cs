using CardPatient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CardPatient.Mediator.WorkWithPatient
{
    public class PatientMediator
    {
        public patients AddNewPatientForm()
        {
            patients patient = new patients();
            return patient;
        }
        public bool AddNewPatient(patients patient)
        {
            using (DbModels model = new DbModels())
            {
                if (model.patients.Any(p => p.uin == patient.uin))
                {
                    return false;
                }
                else
                {
                    model.patients.Add(patient);
                    model.SaveChanges();
                    return true;
                }
            }
        }
        public List<patients> GetListOfPatients()
        {
            using (DbModels model = new DbModels())
            {
                return model.patients.ToList();
            }
        }
        public patients GetCurrentPatientById(int id)
        {
            using (DbModels model = new DbModels())
            {
                return model.patients.Where(x => x.id == id).FirstOrDefault();
            }
        }
        public bool EditCurrentPatient(int id, patients patient)
        {
            try
            {
                using (DbModels model = new DbModels())
                {
                    model.Entry(patient).State = System.Data.Entity.EntityState.Modified;
                    model.SaveChanges();
                }
                return true;
                
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteCurrentUser(int id, FormCollection collection)
        {
            try
            {
                using (DbModels model = new DbModels())
                {
                    patients patientToDelete = model.patients.Where(x => x.id == id).FirstOrDefault();
                    model.patients.Remove(patientToDelete);
                    model.SaveChanges();
                }
                return true;
                
            }
            catch
            {
                return false;
            }
        }
        public patients SearchCurrentPatient(string searchingUin)
        {
            using (DbModels model = new DbModels())
            {

                if (!string.IsNullOrEmpty(searchingUin))
                {
                    try
                    {
                        var patient = model.patients.Where(p => p.uin == searchingUin).FirstOrDefault();
                        if (patient == null)
                        {
                            return null;
                            
                        }
                        return patient;
                    }
                    catch
                    {
                        return null;
                    }
                }

                return null;
            }
        }
    }
}