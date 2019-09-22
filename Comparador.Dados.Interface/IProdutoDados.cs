using Comparador.Dados.Tabela;
using System.Collections.Generic;

namespace Comparador.Dados.Interface
{
    public interface IProdutoDados
    {
        List<ProdutoTabela> BuscarProdutos();
        ProdutoTabela BuscarProduto(int id);
        void SalvarProduto(ProdutoTabela produto);
    }
}