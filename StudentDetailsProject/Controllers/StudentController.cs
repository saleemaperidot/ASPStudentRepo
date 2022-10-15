using StudentDetailsProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using StudentDetailsProject.Models;
using StudentDetailsProject.DAL;

namespace StudentDetailsProject.Controllers
{
    public class StudentController : Controller
    {
        StudentDataAccess _studentObject =new StudentDataAccess();
        // GET: Student
        public ActionResult Index()
        {
            var StudentDetails = _studentObject.GetStudentDetail();
            if (StudentDetails.Count == 0)
            {
                TempData["InfoMessage"] = "No Students enrolled";
            }

            return View(StudentDetails);
           // return View();
        }

        //GET:Login
        public ActionResult Login()
        {
            return View();
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        
       [HttpPost]
       public ActionResult Login(Login login)
        {
            int IsLogin= _studentObject.getReferenceIdFromLogin(login);
              var loginCredential = _studentObject.GetStudentProfileDetail(login);
            if (IsLogin!=0)
            {
                return RedirectToAction("StudentPofile", new { id = IsLogin });
            }
            else
                return View();  
        }
        //var loginCredential = _studentObject.GetStudentProfileDetail(login);
        //return RedirectToAction("profile");
        // return View(loginCredential);
        //GET:Profile
        public ActionResult StudentPofile(int id)
        {
            var StudentDetails = _studentObject.GetLoggedInStudentDetail(id);
            if (StudentDetails.Count == 0)
            {
                TempData["InfoMessage"] = "No Students enrolled";
            }

            return View(StudentDetails);
            // return View();
           
        }

    
       
        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }
       
        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(studentModel student)
        {
            bool IsInserted=false;  

            try
            {
                if (ModelState.IsValid)
                {
                    IsInserted= _studentObject.insertStudentRegistrationDetails(student);
                    if (IsInserted)
                    {
                        TempData["SuccessMessage"] = "Student Details added";
                    }
                    else
                        TempData["ErrorMessage"] = "Student Details adding failed";
                }
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
