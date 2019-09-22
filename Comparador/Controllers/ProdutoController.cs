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
        public ActionResult Insercao()
        {
            return View("Edicao");
        }

        public ActionResult Insercao(Produto produto)
        {
            try
            {
                ValidarProduto(produto);
                SalvarProduto(produto);
                return RedirectToAction("Index", "Produto");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View("Edicao");
            }
        }

        [HttpGet]
        public ActionResult Edicao(int id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception("Informar identificador do produto.");

                var produto = BuscarProduto(id);

                return View(produto);
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
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
        #region Operações no banco
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

        private Produto BuscarProduto(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ComparadorBD"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            using (var command = new SqlCommand("SelecionarProduto", conn)
            {
                CommandType = CommandType.StoredProcedure
            })
            {
                conn.Open();
                command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                var result = command.ExecuteReader();
                Produto produto = null;
                if (result.Read())
                {
                    produto = new Produto(
                        Convert.ToInt32(result[0]),
                        Convert.ToString(result[1]),
                        Convert.ToInt32(result[2]),
                        Convert.ToInt32(result[3]),
                        Convert.ToInt32(result[4])
                    );
                }
                return produto;
            }
        }

        private void SalvarProduto(Produto produto)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ComparadorBD"].ConnectionString;
            using (var conn = new SqlConnection(connectionString))
            {
                string procedure = string.Empty;
                if (produto.ID <= 0)
                {
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
                else
                {
                    using (var command = new SqlCommand("EditarProduto", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    })
                    {
                        command.Parameters.Add("@ID", SqlDbType.Int).Value = produto.ID;
                        command.Parameters.Add("@Nome", SqlDbType.VarChar, 255).Value = produto.Nome;
                        command.Parameters.Add("@Valor", SqlDbType.Int).Value = produto.Valor;
                        command.Parameters.Add("@Garantia", SqlDbType.Int).Value = produto.Garantia;
                        command.Parameters.Add("@GastoEnergiaHora", SqlDbType.Int).Value = produto.GastoEnergiaHora;

                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
        }
        #endregion

        #region Validar
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
        #endregion
        #endregion
    }
}