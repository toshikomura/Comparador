using Comparador.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Comparador.Controllers
{
    public class ProdutoController : Controller
    {
        public ActionResult Index()
        {
            BuscarProdutos();
            return View();
        }

        private List<Produto> BuscarProdutos()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ComparadorBD"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            using (var command = new SqlCommand("SelecionarProdutos", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                var result = command.ExecuteReader();
                var listaProduto = new List<Produto>();
                while (result.Read())
                {
                    listaProduto.Add(new Produto(
                        Convert.ToInt32(result[0]),
                        Convert.ToString(result[1]),
                        Convert.ToInt32(result[2]),
                        Convert.ToInt32(result[3]),
                        Convert.ToInt32(result[4])
                    ));
                }
                return listaProduto;
            }
        }
    }
}