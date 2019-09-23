using Comparador.Comum;
using Comparador.Dados.Interface;
using Comparador.Dados.SqlServer;
using Comparador.ViewModel;
using System.Web.Mvc;

namespace Comparador.Controllers
{
    public class CompararController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var cvm = BuscarDados();
            return View(cvm);
        }
        public ActionResult Index(CompararViewModel compararView)
        {
            var cvm = BuscarDados();
            cvm.SelectedProduto1 = compararView.SelectedProduto1;
            cvm.SelectedProduto2 = compararView.SelectedProduto2;
            return View(cvm);
        }

        private CompararViewModel BuscarDados()
        {
            IProdutoDados pd = new ProdutoDados();
            var produtos = Conversor.ConverterDropDownList(pd.BuscarProdutos());
            var cvm = new CompararViewModel(produtos);
            return cvm;
        }
    }
}