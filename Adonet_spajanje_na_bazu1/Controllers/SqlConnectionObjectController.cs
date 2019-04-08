using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adonet_spajanje_na_bazu1.Controllers
{
    public class SqlConnectionObjectController : Controller
    {
        // GET: SqlConnectionObject
        public ActionResult Index()
        {
            // Prvo kreiramo conn string
            string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbAlgebra;Integrated Security=True";

            // Nakon toga instanca SQL connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    Response.Write("Konekcija je uspjela");
                }
            }

            catch (SqlException sqlEx)
            {
                Response.Write(sqlEx.Message);
            }
            finally
            {
                conn.Close();
            }

            return View();
        }
        // GET: SqlConnectionObject
        public ActionResult SpojPrekoWebConfig()
        {
            // Prvo kreiramo conn string
            //string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbAlgebra;Integrated Security=True";
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnString"].ConnectionString;
            // Nakon toga instanca SQL connection
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                conn.Open();
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    Response.Write("Konekcija je uspjela");
                }
            }

            catch (SqlException sqlEx)
            {
                Response.Write(sqlEx.Message);
            }
            finally
            {
                conn.Close();
            }

            return View();
        }
    }
}