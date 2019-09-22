namespace Comparador.Dados.Tabela
{
    public class ProdutoTabela
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int Valor { get; set; }
        public int Garantia { get; set; }
        public int GastoEnergiaHora { get; set; }

        public ProdutoTabela() { }
        public ProdutoTabela(int id, string nome, int valor, int garantia, int gastoEnergiaHora)
        {
            ID = id;
            Nome = nome;
            Valor = valor;
            Garantia = garantia;
            GastoEnergiaHora = gastoEnergiaHora;
        }

        public ProdutoTabela(string nome, int valor, int garantia, int gastoEnergiaHora)
        {
            Nome = nome;
            Valor = valor;
            Garantia = garantia;
            GastoEnergiaHora = gastoEnergiaHora;
        }
    }
}