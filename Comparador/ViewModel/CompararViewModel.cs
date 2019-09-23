using System.Collections.Generic;
using System.Web.Mvc;

namespace Comparador.ViewModel
{
    public class CompararViewModel
    {
        public int SelectedProduto1 { get; set; }
        public int SelectedProduto2 { get; set; }
        public IEnumerable<SelectListItem> Produtos { get; set; }

        public CompararViewModel()
        {

        }

        public CompararViewModel(IEnumerable<SelectListItem> produtos)
        {
            Produtos = produtos;
        }
    }
}