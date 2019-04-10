using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Adonet_spajanje_na_bazu1.Controllers
{
    public class SqlCommandObjectController : Controller
    {
        // GET: SqlCommandObject
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            // Prvo kreiramo conn string
            //string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbAlgebra;Integrated Security=True";
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnString"].ConnectionString;
            // Nakon toga instanca SQL connection
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string cmdText = "";
                cmdText += "INSERT INTO tbltecajevi";
                cmdText += "(naziv, opis)";
                cmdText += "VALUES";
                cmdText += "('Web design', 'Naucite dizajnirati web stranice')";

                //Kreiramo command objekt i otvaramo vezu s bazom

                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Connection.Open();

                // Komandu izvrsavamo metodom ExecuteNonQuery
                // Ako je zapis upisan u bazu, baza vraca 1 (jer je upisan jedan redak)

                int brojDodanihRedaka = cmd.ExecuteNonQuery();
                if (brojDodanihRedaka > 0)
                {
                    ViewBag.Message = "Zapis je upsian u bazu!";
                }
                else
                {
                    ViewBag.Message = "Dogodila se greška!";
                }
            }
            return View("Index");
        }
        public ActionResult Edit()
        {
            // Prvo kreiramo conn string
            //string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbAlgebra;Integrated Security=True";
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnString"].ConnectionString;
            // Nakon toga instanca SQL connection
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string cmdText = "UPDATE tbltecajevi";
                cmdText += "SET naziv='Web programiranje'";
                cmdText += "WHERE id = 1";


                //Kreiramo command objekt i otvaramo vezu s bazom

                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Connection.Open();

                // Komandu izvrsavamo metodom ExecuteNonQuery

                int brojIzmijenjenihRedaka = cmd.ExecuteNonQuery();

                ViewBag.Message = "Broj izmjenjenih redaka: " + brojIzmijenjenihRedaka.ToString();
            }
            return View("Index");
        }
    }

    public ActionResult Delete()
    {
        // Prvo kreiramo conn string
        //string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbAlgebra;Integrated Security=True";
        string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnString"].ConnectionString;
        // Nakon toga instanca SQL connection
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string cmdText = "DELETE FROM tbltecajevi";
            cmdText += "SET naziv='Web programiranje'";
            cmdText += "WHERE id = 1";


            //Kreiramo command objekt i otvaramo vezu s bazom

            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Connection.Open();

            // Komandu izvrsavamo metodom ExecuteNonQuery

            int brojObrisanihRedaka = cmd.ExecuteNonQuery();

            ViewBag.Message = "Broj obrisanih redaka: " + brojObrisanihRedaka.ToString();

            return View("Index");
        }
    }
    public ActionResult Count()
    {
        // Prvo kreiramo conn string
        //string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbAlgebra;Integrated Security=True";
        string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnString"].ConnectionString;
        // Nakon toga instanca SQL connection
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string cmdText = "SELECT COUNT(*) from tbltecajevi";



            //Kreiramo command objekt i otvaramo vezu s bazom

            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Connection.Open();

            // Komandu izvrsavamo metodom ExecuteNonQuery

            int brojZapisa = (int)cmd.ExecuteScalar();

            ViewBag.Message = "Broj tecajeva u bazi je: " + brojZapisa.ToString();
        }

        return View("Index");

    }
}
