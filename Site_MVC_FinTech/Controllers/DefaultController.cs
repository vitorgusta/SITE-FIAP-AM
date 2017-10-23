using Site_MVC_FinTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Site_MVC_FinTech.Controllers
{
    public class DefaultController : Controller
    {
        public int UserId {
            get {
                return int.Parse(FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name);
            }
        }
    }
}