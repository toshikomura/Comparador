namespace Comparador.Models
{
    public class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public int Valor { get; set; }
        public int Garantia { get; set; }
        public int GastoEnergiaHora { get; set; }

        public Produto(int id, string nome, int valor, int garantia, int gastoEnergiaHora)
        {
            ID = id;
            Nome = nome;
            Valor = valor;
            Garantia = garantia;
            GastoEnergiaHora = gastoEnergiaHora;
        }

        public Produto(string nome, int valor, int garantia, int gastoEnergiaHora)
        {
            Nome = nome;
            Valor = valor;
            Garantia = garantia;
            GastoEnergiaHora = gastoEnergiaHora;
        }
    }
}