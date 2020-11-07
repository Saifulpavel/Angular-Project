using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            con.Open();
            string query = @"SELECT 
                                [EmployeeId],[EmployeeName],[Department],CONVERT(VARCHAR(10),[JoiningDate],120) AS JoiningDate,[PhotoFileName]
                             FROM dbo.Employee";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            return Request.CreateResponse(HttpStatusCode.OK, dt);
        }

        public string Post(Employee Emp)
        {
            try
            {
                DataTable dt = new DataTable();
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                con.Open();
                string query = @"INSERT INTO dbo.Employee
                                 VALUES ('" + Emp.EmployeeName + "','"+Emp.Department+"','"+Emp.JoiningDate+"','"+Emp.PhotoFileName+"')";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();

                return "Saved Successfully!!!";
            }
            catch (Exception)
            {
                return "Save failed!!!";
            }
        }

        public string Put(Employee Emp)
        {
            //try
            //{
                DataTable dt = new DataTable();
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                con.Open();
                string query = @"UPDATE dbo.Employee 
                                 SET EmployeeName='" + Emp.EmployeeName + "',Department='"+Emp.Department+"',JoiningDate='"+Emp.JoiningDate+"',PhotoFileName='"+Emp.PhotoFileName+"' WHERE EmployeeId='" + Emp.EmployeeId + "'";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();

                return "Updated Successfully!!!";
            //}
            //catch (Exception)
            //{
            //    return "Update failed!!!";
            //}
        }

        public string Delete(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                con.Open();
                string query = @"DELETE FROM dbo.Employee 
                                 WHERE DepartmentId='" + id + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();
                return "Deleted Successfully!!!";
            }
            catch (Exception)
            {
                return "Delete failed!!!";
            }
        }

        [Route ("api/Employee/GetAllDepartmentName")]
        [HttpGet]
        public HttpResponseMessage GetAllDepartmentName()
        {
            DataTable dt = new DataTable();
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            con.Open();
            string query = @"SELECT DepartmentName FROM dbo.Department";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            return Request.CreateResponse(HttpStatusCode.OK, dt);           
        }

        [Route("api/Employee/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string fileName = postedFile.FileName;
                var physicalPath = HttpContext.Current.Server.MapPath("~/Photos/"+fileName);
                postedFile.SaveAs(physicalPath);
                return fileName;
            }
            catch (Exception)
            {
                return "me.png";
            }
        }

    }
}
