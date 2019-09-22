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
            var produtos = BuscarProdutos();
            return View(produtos);
        }

        [HttpGet]
        public ActionResult Edicao()
        {
            return View();
        }

        public ActionResult Edicao(Produto produto)
        {
            try
            {
                ValidarProduto(produto);
                SalvarProduto(produto);
                return RedirectToAction("Index", "Produto");
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        #region Private
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

        private void ValidarProduto(Produto produto)
        {
            if (produto == null)
                throw new Exception("Produto não foi informado.");
            if (string.IsNullOrWhiteSpace(produto.Nome))
                throw new Exception("Produto precisa ter um nome.");
            if (produto.Valor <= 0)
                throw new Exception("Produto precisa ter um valor.");
            if (produto.Garantia < 0)
                throw new Exception("Produto precisa ter uma garantia.");
            if (produto.GastoEnergiaHora <= 0)
                throw new Exception("Produto precisa ter um gasto de energia por hora.");
        }

        private void SalvarProduto(Produto produto)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ComparadorBD"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            using (var command = new SqlCommand("InserirProduto", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                command.Parameters.Add("@Nome", SqlDbType.VarChar, 255).Value = produto.Nome;
                command.Parameters.Add("@Valor", SqlDbType.Int).Value = produto.Valor;
                command.Parameters.Add("@Garantia", SqlDbType.Int).Value = produto.Garantia;
                command.Parameters.Add("@GastoEnergiaHora", SqlDbType.Int).Value = produto.GastoEnergiaHora;

                conn.Open();
                command.ExecuteNonQuery();
            }
        }
        #endregion
    }
}