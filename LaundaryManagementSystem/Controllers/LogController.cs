using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LaundaryManagementSystem.Models;
using System.Drawing;

namespace LaundaryManagementSystem.Controllers
{
    public class LogController : Controller
    {
        // GET: Log
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginToForm(Login login)
        {

            string Connection = ConfigurationManager.ConnectionStrings["Conn"].ToString();
            SqlConnection con = new SqlConnection(Connection);
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_Login1", con);
            cmd.Parameters.AddWithValue("@Username", login.UserName);
            cmd.Parameters.AddWithValue("@Password", login.Password);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();

            if (dt.Rows.Count > 0)
            {
                return Json("Success", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("", JsonRequestBehavior.AllowGet);
            }
        }
    }
}

