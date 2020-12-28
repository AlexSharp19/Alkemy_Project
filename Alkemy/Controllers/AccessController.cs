using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Alkemy.Models;

namespace Alkemy.Controllers
{
    public class AccessController : Controller
    {
        // GET: Access
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter(string file_number, string dni)
        {
            
            try
            {
                int file = Int32.Parse(file_number);
                int id = Int32.Parse(dni);
                using (SubjectsEntities db=new SubjectsEntities())
                {
                    var lst = from d in db.Users
                              where d.File_Number == file && d.Dni == id && d.Users_state==true
                              select d;
                    if (lst.Count() > 0)
                    {
                        Users oUser = lst.First();
                        Session["User"] = oUser;
                    }
                    else
                    {
                        return Content("Usuario invalido:(");
                    }
                }
                var Login = (Users)System.Web.HttpContext.Current.Session["User"];
                if (Login.Id_Type_User_U == 1)
                {
                    return Content("1");
                }
                else if (Login.Id_Type_User_U == 2)
                {
                    return Content("2");
                }
                return Content("3");
            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error :(" + ex.Message);
            }
        }
    }
}