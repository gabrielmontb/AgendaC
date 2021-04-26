using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using AgendaVirtual.db_access;
using AgendaVirtual.Models;

namespace AgendaVirtual.Controllers
{
   
    public class HomeController : Controller

    {        
        String ConnectionString = ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString;
        db_access.db dblayer = new db_access.db();    

        
        public JsonResult InsertValues(string nome, string telefone)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into dados(Nome,Telefone) values('" + nome + "','" + telefone + "' )", con);
                cmd.ExecuteNonQuery();
                con.Close();
                return Json("Inserido com sucesso!", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Erro ao inserir!", JsonRequestBehavior.AllowGet);
            }

        }
        [HttpGet]
        public JsonResult GetData()
        {
            List<object> listas = new List<object>();
            SqlConnection con = new SqlConnection(ConnectionString);
            {
                string query = "SELECT * FROM dados;";
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listas.Add(new {ID = reader.GetInt32(0), Nome = reader.GetString(1), Telefone = reader.GetString(2) });
                    }
                }
            }
            return Json(listas, JsonRequestBehavior.AllowGet);
        }
        public JsonResult updateValues(int delete_id, string nome_d, string telefone_d)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE dados SET Nome = '"+ nome_d + "',Telefone = '" + telefone_d + "' WHERE ID='" + delete_id + "' ", con);
                cmd.ExecuteNonQuery();
                con.Close();
                return Json("Alterado com sucesso!", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Erro ao alterar!", JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult DeleteValues(int id_delete)
        {
            try
            {
                SqlConnection con = new SqlConnection(ConnectionString);

                Console.WriteLine("ok");
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from dados where ID = "+ id_delete + "", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Console.WriteLine("ok");
                return Json("Excluido com sucesso!", JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json("Erro ao exlcuir!", JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult ListaDados()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }


    }

}



