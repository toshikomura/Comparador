using Comparador.Comum;
using Comparador.Dados.Interface;
using Comparador.Dados.SqlServer;
using Comparador.Models;
using System;
using System.Web.Mvc;

namespace Comparador.Controllers
{
    public class ProdutoController : Controller
    {
        public ActionResult Index()
        {
            IProdutoDados pd = new ProdutoDados();
            var produtos = Conversor.Converter(pd.BuscarProdutos());
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
                IProdutoDados pd = new ProdutoDados();
                pd.SalvarProduto(Conversor.Converter(produto));
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

                IProdutoDados pd = new ProdutoDados();
                var produto = Conversor.Converter(pd.BuscarProduto(id));

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
                IProdutoDados pd = new ProdutoDados();
                pd.SalvarProduto(Conversor.Converter(produto));
                return RedirectToAction("Index", "Produto");
            }
            catch(Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }

        public ActionResult Detalhe(int id)
        {
            IProdutoDados pd = new ProdutoDados();
            var produto = Conversor.Converter(pd.BuscarProduto(id));
            return PartialView(produto);
        }

        #region Private

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