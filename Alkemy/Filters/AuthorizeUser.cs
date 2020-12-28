using Alkemy.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Alkemy.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeUser: AuthorizeAttribute
    {
        private Users oUser;
        private SubjectsEntities db = new SubjectsEntities();
        private int Type_User;

        public AuthorizeUser(int Type_user)
        {
            this.Type_User = Type_user;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            
                oUser = (Users)HttpContext.Current.Session["User"];


                if (oUser.Id_Type_User_U != Type_User)
                {
                    filterContext.Result = new RedirectResult("~/Error/UnauthorizedOperation");
                }
            
            
        }

    }
}