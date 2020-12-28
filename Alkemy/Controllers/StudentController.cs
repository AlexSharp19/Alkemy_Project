using Alkemy.Models;
using Alkemy.Models.TableViewModels;
using Alkemy.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alkemy.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Subjects()
        {
            List<SubjectTableViewModel> lst = null;
            using (SubjectsEntities db = new SubjectsEntities())
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
        

        [HttpPost]
        public ActionResult Enroll(int Id)
        {
            var oUser = (Users)System.Web.HttpContext.Current.Session["User"];
            int Id_Student = oUser.File_Number;

            SubjectViewModel model = new SubjectViewModel();

            try
            {
                using (var db = new SubjectsEntities())
                {
                    var oSubject = db.Subjects.Find(Id);
                    model.Quota = oSubject.Subject_Quota;

                    if (model.Quota > 0)
                    {
                        db.SP_StudentxSubject(Id_Student, Id);
                        db.SaveChanges();
                        return Content("1");
                    }
                    else if (model.Quota == 0)
                    {
                        return Content("2");
                    }
                }
                return Content("3");
            }
            catch(Exception ex)
            {
                return Content("Puede que ya este inscripto en esta materia //" + ex.Message);
            }
        }


    }
}