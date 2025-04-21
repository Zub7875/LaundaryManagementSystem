using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace LaundaryManagementSystem.Controllers
{
    public class StaffMemberController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        
    }
}