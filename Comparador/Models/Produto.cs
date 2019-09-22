using System.ComponentModel.DataAnnotations;

namespace Comparador.Models
{
    public class Produto
    {
        public int ID { get; set; }
        [Display (Name = "Nome")]
        public string Nome { get; set; }
        [Display(Name = "Valor")]
        public int Valor { get; set; }
        [Display(Name = "Garantia")]
        public int Garantia { get; set; }
        [Display(Name = "Gasto Energia Hora")]
        public int GastoEnergiaHora { get; set; }

        public Produto() { }
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