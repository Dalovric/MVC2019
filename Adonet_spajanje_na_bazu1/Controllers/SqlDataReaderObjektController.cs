using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using System.

namespace Adonet_spajanje_na_bazu1.Controllers
{
    public class SqlDataReaderObjektController : Controller
    {
        // GET: SqlDataReaderObjekt
        public ActionResult Index()
        {
            // Prvo kreiramo conn string
            //string connString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dbAlgebra;Integrated Security=True";
            string connString = ConfigurationManager.ConnectionStrings["dbAlgebraConnString"].ConnectionString;

            // pripremi praznu listu tecajeva
            List<Tecaj> lstTecaj = new List<Tecaj>();

            // Nakon toga instanca SQL connection
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string cmdText = "SELECT * from tbltecajevi";
                
                //Kreiramo command objekt i otvaramo vezu s bazom

                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Connection.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader != null)
                {
                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            Tecaj t1 = new Tecaj();
                            t1.Id = reader["id"];
                            t1.Naziv = reader["naziv"];
                            t1.Opis = reader["opis"];

                            lstTecaj.Add(t1);
                        }
                    }
                }
                reader.Close();
                
            }
            return View("Index", lstTecaj);
        }
    }
}