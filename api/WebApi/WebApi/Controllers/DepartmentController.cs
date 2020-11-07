using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class DepartmentController : ApiController
    {
        public HttpResponseMessage Get()
        {
            DataTable dt = new DataTable();
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            con.Open();
            string query = @"SELECT 
                            DepartmentId,DepartmentName 
                            FROM 
                            dbo.Department";
                
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            return Request.CreateResponse(HttpStatusCode.OK,dt);
        }

        public string Post(Department Dept)
        {
            try
            {
                DataTable dt = new DataTable();
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                con.Open();
                string query = @"INSERT INTO dbo.Department
                                 VALUES ('" + Dept.DepartmentName + "')";

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

        public string Put(Department Dept)
        {
            try
            {
                DataTable dt = new DataTable();
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                con.Open();
                string query = @"UPDATE dbo.Department 
                                 SET DepartmentName='" + Dept.DepartmentName + "' WHERE DepartmentId='" + Dept.DepartmentId + "'";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();

                return "Updated Successfully!!!";
            }
            catch (Exception)
            {
                return "Update failed!!!";
            }
        }

        public string Delete(int id)
        {
            try
            {
                DataTable dt = new DataTable();
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
                con.Open();
                string query = @"DELETE FROM dbo.Department 
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


    }
}
