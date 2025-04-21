using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using LaundaryManagementSystem.Models;
using Newtonsoft.Json;

namespace LaundaryManagementSystem.Controllers
{
    public class NMIMSController : Controller
    {
        // GET: NMIMS
        public ActionResult NMIMSPage()
        {
            return View();
        }
        public ActionResult InsertStudent(LaundaryCs model)
        {
            string Connectionstring = ConfigurationManager.ConnectionStrings["Conn"].ToString();
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("InsertStudent", con);
            cmd.Parameters.AddWithValue("@StudentName", model.StudentName);
            cmd.Parameters.AddWithValue("@RoomNo", model.RoomNo);
            cmd.Parameters.AddWithValue("@SubmissionDate", model.SubmissionDate);
            cmd.Parameters.AddWithValue("@NoOfClothes", model.NoOfClothes);
            cmd.Parameters.AddWithValue("@TypeOfClothes", model.TypeOfClothes);
            cmd.Parameters.AddWithValue("@Rate", model.Rate);
            cmd.Parameters.AddWithValue("@TotalAmount", model.TotalAmount);
            cmd.Parameters.AddWithValue("@Operation", model.Operation);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            return Json("Success", JsonRequestBehavior.AllowGet);

        }
        public ActionResult TblTypesOfClothes()
        {
            string Connectionstring = ConfigurationManager.ConnectionStrings["Conn"].ToString();
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_TypesOfClothes", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string value = JsonConvert.SerializeObject(dt);
            con.Close();
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public ActionResult TblOperation()
        {
            string Connectionstring = ConfigurationManager.ConnectionStrings["Conn"].ToString();
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_Operation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string value = JsonConvert.SerializeObject(dt);
            con.Close();
            return Json(value, JsonRequestBehavior.AllowGet);

        }
        public ActionResult GridView()
        {
            string Connectionstring = ConfigurationManager.ConnectionStrings["Conn"].ToString();
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_GridView", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string value = JsonConvert.SerializeObject(dt);
            con.Close();
            return Json(value, JsonRequestBehavior.AllowGet);

        }
        public ActionResult edit(int ID)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Conn"].ToString());
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_Edit", con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            ad.Fill(dt);
            con.Close();
            string editdata = JsonConvert.SerializeObject(dt, Formatting.Indented);
            return Json(editdata, JsonRequestBehavior.AllowGet);

        }

        public ActionResult UpdateStudent(LaundaryCs model)
        {
            string Connectionstring = ConfigurationManager.ConnectionStrings["Conn"].ToString();
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_Update", con);
            cmd.Parameters.AddWithValue("@StudentName", model.StudentName);
            cmd.Parameters.AddWithValue("@RoomNo", model.RoomNo);
            cmd.Parameters.AddWithValue("@SubmissionDate", model.SubmissionDate);
            cmd.Parameters.AddWithValue("@NoOfClothes", model.NoOfClothes);
            cmd.Parameters.AddWithValue("@TypeOfClothes", model.TypeOfClothes);
            cmd.Parameters.AddWithValue("@Rate", model.Rate);
            cmd.Parameters.AddWithValue("@TotalAmount", model.TotalAmount);
            cmd.Parameters.AddWithValue("@Operation", model.Operation);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
        public ActionResult DeleteStudent(int ID)
        {
            string Connectionstring = ConfigurationManager.ConnectionStrings["Conn"].ToString();
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("Sp_DeleteStudent", con);
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            return Json("Success", JsonRequestBehavior.AllowGet);
        }
    }
}