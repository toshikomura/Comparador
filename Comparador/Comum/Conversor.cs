using Comparador.Dados.Tabela;
using Comparador.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Comparador.Comum
{
    public class Conversor
    {
        public static ProdutoTabela Converter(Produto produto)
        {
            return new ProdutoTabela(produto.ID, produto.Nome, produto.Valor, produto.Valor, produto.GastoEnergiaHora);
        }

        public static Produto Converter(ProdutoTabela produto)
        {
            return new Produto(produto.ID, produto.Nome, produto.Valor, produto.Valor, produto.GastoEnergiaHora);
        }

        public static List<Produto> Converter(List<ProdutoTabela> produtos)
        {
            var listProdutos = new List<Produto>();
            foreach (var produto in produtos)
                listProdutos.Add(new Produto(produto.ID, produto.Nome, produto.Valor, produto.Garantia, produto.GastoEnergiaHora));

            return listProdutos;
        }

        public static IEnumerable<SelectListItem> ConverterDropDownList(List<ProdutoTabela> produtos)
        {
            List<SelectListItem> list = produtos.
                OrderBy(x => x.ID).
                Select(x => new SelectListItem
                {
                    Value = x.ID.ToString(),
                    Text = x.Nome
                }).ToList();

            list.Insert(0, new SelectListItem()
            {
                Value = null,
                Text = "--- selecione um produto ---"
            });

            return new SelectList(list, "Value", "Text");
        }
    }
}