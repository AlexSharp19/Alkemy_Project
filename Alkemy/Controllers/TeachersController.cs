using Alkemy.Models.ViewModels;
using Alkemy.Models;
using Alkemy.Models.TableViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Alkemy.Filters;

namespace Alkemy.Controllers
{
    public class TeachersController : Controller
    {
        // GET: Teachers
        [AuthorizeUser(Type_user:1)]
        public ActionResult Index()
        {
            List<TeacherTableViewModel> lst = null;
            using (SubjectsEntities db = new SubjectsEntities())
            {

                lst = (from d in db.Teachers
                       where d.Teacher_State == true
                       orderby d.Teacher_Name
                       select new TeacherTableViewModel
                       {
                         Teacher_Id=d.Id_Teacher,
                         Teacher_Dni=d.Dni,
                         Teacher_Name=d.Teacher_Name,
                         Teacher_LastName=d.Teacher_LastName
                       }).ToList();
            }

            return View(lst);
        }


        [AuthorizeUser(Type_user: 1)]
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(TeacherViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db= new SubjectsEntities())
            {
                Teachers oTeachers = new Teachers();
                oTeachers.Teacher_Name = model.Name;
                oTeachers.Teacher_LastName = model.LastName;
                oTeachers.Dni = model.Dni;
                oTeachers.Teacher_State = true;

                db.Teachers.Add(oTeachers);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Teachers/"));

        }

        [AuthorizeUser(Type_user: 1)]
        public ActionResult Edit(int Id)
        {
            EditTeacherViewModel model = new EditTeacherViewModel();

            using(var db=new SubjectsEntities())
            {
                var oTeacher = db.Teachers.Find(Id);
                model.Name = oTeacher.Teacher_Name;
                model.LastName = oTeacher.Teacher_LastName;
                model.Teacher_Id = oTeacher.Id_Teacher;
                model.Dni = oTeacher.Dni;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditTeacherViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new SubjectsEntities())
            {
                var oTeacher = db.Teachers.Find(model.Teacher_Id);
                oTeacher.Teacher_Name = model.Name;
                oTeacher.Teacher_LastName = model.LastName;
                oTeacher.Dni = model.Dni;

                db.Entry(oTeacher).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Redirect(Url.Content("~/Teachers/"));
        }

        
        [HttpPost]
        public ActionResult Delete(int Id)
        {

            using (var db = new SubjectsEntities())
            {
                var oTeacher = db.Teachers.Find(Id);
                oTeacher.Teacher_State = false;

                db.Entry(oTeacher).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }

            return Content("1");
        }

    }
}