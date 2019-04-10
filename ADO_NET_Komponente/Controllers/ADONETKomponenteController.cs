using ADO_NET_Komponente.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ADO_NET_Komponente.Controllers
{
    public class ADONETKomponenteController : Controller
    {

        public static string connStr = ConfigurationManager.ConnectionStrings["dbAlgebraConnStr"].ConnectionString;

        // GET: ADO Komponente
        public ActionResult List()
        {
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cm = new SqlCommand();
            cm.Connection = conn;
            cm.CommandText = "SELECT * FROM tblPolaznici";

            SqlDataReader dr = null;
            List<PolaznikModel> lstPolaznici = new List<PolaznikModel>();

            try
            {
                conn.Open();
                // Ovdje smo jos mogli provjeriti jeli veza otvorena
                dr = cm.ExecuteReader();

                //Provjerimo da li DataReader uopce postoji
                if (dr != null)
                {
                    // Ako postoji provjeri da li postoje redovi koji bi se mogli procitati
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            // Kreiramo novi PolaznikModel objekt, inicijaliziramo i dodajemo na listu lstPolaznici
                            PolaznikModel polaznik = new PolaznikModel();
                            polaznik.IdPolaznik = int.Parse(dr["IdPolaznik"].ToString());
                            polaznik.Ime = dr["Ime"].ToString();
                            polaznik.Email = dr["Email"].ToString();
                            polaznik.DatumRodjenja = DateTime.Parse(dr["DatumRodjenja"].ToString());
                            lstPolaznici.Add(polaznik);
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja popisa polaznika! Opis:" + ex.Message;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                cm.Dispose();
            }
        }

            [HttpGet]
        public ActionResult Details(int idPolaznik)
        {
            SqlConnection conn = new SqlConnection(connStr);

            //Kreiramo SQL naredbu
            string cmdText = "SELECT * FROM tblPolaznici WHERE IdPolaznik = @IdPolaznik";

            //Kreiramo SQLCommand objekt
            SqlCommand cmd = new SqlCommand(cmdText, conn);

            //Kreiramo SQLParameter objekt
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@IdPolaznik";
            param.DbType = System.Data.DbType.Int32;
            param.Direction = System.Data.ParameterDirection.Input;
            param.Value = idPolaznik;
            cmd.Parameters.Add(param);

            SqlDataReader dr = null;
            PolaznikModel polaznik = new PolaznikModel();

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            polaznik.IdPolaznik = int.Parse(dr["IdPolaznik"].ToString());
                            polaznik.Ime = dr["Ime"].ToString();
                            polaznik.Prezime = dr["Prezime"].ToString();
                            polaznik.Email = dr["Email"].ToString();
                            polaznik.DatumRodjenja = DateTime.Parse(dr["DatumRodjenja"].ToString());
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja polaznika! Opis:" + ex.Message;
            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                cmd.Dispose();
            }
            return View(polaznik);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new PolaznikModel());
        }

        [HttpPost]
        public ActionResult Create(PolaznikModel model)
        {
            string connStr = ConfigurationManager.ConnectionStrings["dbAlgebraConnStr"].ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Kreiramo SQL naredbu za upis u bazu
                    string cmdText = "";
                    cmdText += "Insert into tblPolazici";
                    cmdText += "Ime, Prezime, Email, DatumRodjenja";
                    cmdText += "VALUES";
                    cmdText += "('" + model.Ime + "','" + model.Prezime + "','" + model.Email + "',"+model.DatumRodjenja.ToString("yyyy-MM-dd") + ")";

                    //Kreiramo Command objekt i otvaramo vezu s bazom
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Connection.Open();

                    int brojDodanihRedaka = cmd.ExecuteNonQuery();
                    ViewBag.Message = "Broj dodanih redaka:" + brojDodanihRedaka;
                }
            }

            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod upisa polaznika! Opis: " + ex.Message;
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int idPolaznik)
        {
            SqlConnection conn = new SqlConnection(connStr);

            //Kreiramo SQL naredbu
            string cmdText = "SELECT * FROM tblPolaznici WHERE IdPolaznik = @IdPolaznik";

            //Kreiramo SQLCommand objekt
            SqlCommand cmd = new SqlCommand(cmdText, conn);

            //Kreiramo SQLParameter objekt
            SqlParameter param = new SqlParameter();
            param.ParameterName = "@IdPolaznik";
            param.DbType = System.Data.DbType.Int32;
            param.Direction = System.Data.ParameterDirection.Input;
            param.Value = idPolaznik;
            cmd.Parameters.Add(param);

            SqlDataReader dr = null;
            PolaznikModel polaznik = new PolaznikModel();

            try
            {
                conn.Open();
                dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            polaznik.IdPolaznik = int.Parse(dr["IdPolaznik"].ToString());
                            polaznik.Ime = dr["Ime"].ToString();
                            polaznik.Prezime = dr["Prezime"].ToString();
                            polaznik.Email = dr["Email"].ToString();
                            polaznik.DatumRodjenja = DateTime.Parse(dr["DatumRodjenja"].ToString());
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod dohvaćanja polaznika! Opis:" + ex.Message;

            }
            finally
            {
                if (dr != null)
                {
                    dr.Close();
                }
                if (conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                cmd.Dispose();
            }
            return View(polaznik);
        }
        [HttpPost]
        public ActionResult Edit(PolaznikModel model)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    // Kreirajmo SQL naredbu za upis u bazu
                    string cmdText = "";
                    cmdText += "UPDATE tblPolaznici";
                    cmdText += "SET Ime='" + model.Ime + "', Prezime ='" + model.Prezime + "',Email='" + model.Email + "',Datum rodjenja" +
                        model.DatumRodjenja.ToString("yyyy-MM-dd") + "";
                    cmdText += "WHERE IdPolaznik=" + model.IdPolaznik;

                    //Kreiramo Command objekt i otvaramo vezu s bazom
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Connection.Open();

                    //Komandu izvrsavamo metodom ExecuteNonQuery
                    //Ako je zapis upisan u bazu, baza vraca 1 (jer je upisan jedan redak)

                    int brojDodanihRedaka = cmd.ExecuteNonQuery();
                    if (brojDodanihRedaka > 0)
                    {
                        ViewBag.Message = "Zapis je upisan u bazu!";
                    }
                    else
                    {
                        ViewBag.Message = "Dogodila se greška!";
                    }
                }
            }

            catch (Exception ex)

            {
                ViewBag.Message = "Greška kod dohvaćanja polaznika! Opis:" + ex.Message;
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult Delete(int idPolaznik)
        {
            SqlConnection conn = new SqlConnection(connStr);

            //Kreiramo SQL naredbu
            string cmdText = "DELETE FROM tblPolaznici WHERE IdPolaznik=" + idPolaznik;

            //Kreiramo SQLCommnad objekt
            SqlCommand cmd = new SqlCommand(cmdText, conn);

            try
            {
                cmd.Connection.Open();
                int.brojBrisanihRedaka = cmd.ExecuteNonQuery();
                TempData["Message"] = "Broj izbrisanih redaka:" + brojBrisanihRedaka;
            }

            catch (Exception ex)
            {
                ViewBag.Message = "Greška kod brisanja polaznika! Opis:" + ex.Message;
            }
        
            finally
            {
                if(conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Dispose();
                cmd.Dispose();
            }
            return RedirectToAction("List");
        }
    }
}
