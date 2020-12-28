using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alkemy.Models;
using Alkemy.Models.TableViewModels;
using Alkemy.Models.ViewModels;

namespace Alkemy.Controllers
{
    public class SubjectsController : Controller
    {
        // GET: Subjects
        public ActionResult Index()
        {

            List<SubjectTableViewModel> lst = null;
            using(SubjectsEntities db=new SubjectsEntities())
            {

                lst = (from d in db.Subjects
                       join s in db.Teachers on d.Subject_Id_Teacher equals s.Id_Teacher
                       where d.Subject_State == true
                       orderby d.Subject_Name
                       select new SubjectTableViewModel
                       {
                           Id_Subject = d.Subject_Id,
                           Name = d.Subject_Name,
                           Day = d.Subject_Day,
                           Start_Time = d.Subject_StartTime,
                           Ending_Time = d.Subject_EndingTime,
                           Name_Teacher = s.Teacher_Name,
                           LastName_Teacher = s.Teacher_LastName,
                           Quota = d.Subject_Quota
                       }).ToList();
            }

            return View(lst);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(SubjectViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new SubjectsEntities())
            {
                Subjects oSubjects = new Subjects();
                oSubjects.Subject_Name = model.Subject_Name;
                oSubjects.Subject_Day = model.Day;
                oSubjects.Subject_StartTime = model.StartTime;
                oSubjects.Subject_EndingTime = model.EndingTime;
                oSubjects.Subject_Id_Teacher = model.Teacher_Id;
                oSubjects.Subject_Quota = model.Quota;
                oSubjects.Subject_State = true;
                

                db.Subjects.Add(oSubjects);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Subjects/"));

        }

        public ActionResult Edit(int Id)
        {
            EditSubjectViewModel model = new EditSubjectViewModel();

            using(var db=new SubjectsEntities())
            {
                var oSubject = db.Subjects.Find(Id);
                model.Subject_Name = oSubject.Subject_Name;
                model.Day = oSubject.Subject_Day;
                model.StartTime = oSubject.Subject_StartTime;
                model.EndingTime = oSubject.Subject_EndingTime;
                model.Teacher_Id = oSubject.Subject_Id_Teacher;
                model.Quota = oSubject.Subject_Quota;
                model.Subject_Id = oSubject.Subject_Id;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditSubjectViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new SubjectsEntities())
            {
                var oSubjects = db.Subjects.Find(model.Subject_Id);
                oSubjects.Subject_Name = model.Subject_Name;
                oSubjects.Subject_Day = model.Day;
                oSubjects.Subject_StartTime = model.StartTime;
                oSubjects.Subject_EndingTime = model.EndingTime;
                oSubjects.Subject_Id_Teacher = model.Teacher_Id;
                oSubjects.Subject_Quota = model.Quota;


                db.Entry(oSubjects).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Subjects/"));

        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {

            using (var db = new SubjectsEntities())
            {
                var oSubject = db.Subjects.Find(Id);
                oSubject.Subject_State = false;

                db.Entry(oSubject).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Content("1");
        }

    }
}