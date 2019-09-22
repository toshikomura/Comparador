using Comparador.Dados.Interface;
using Comparador.Dados.Tabela;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Comparador.Dados.SqlServer
{
    public class ProdutoDados : IProdutoDados
    {
        public List<ProdutoTabela> BuscarProdutos()
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
                var listaProduto = new List<ProdutoTabela>();
                while (result.Read())
                {
                    listaProduto.Add(new ProdutoTabela(
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

        public ProdutoTabela BuscarProduto(int id)
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
                ProdutoTabela produto = null;
                if (result.Read())
                {
                    produto = new ProdutoTabela(
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

        public void SalvarProduto(ProdutoTabela produto)
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
    }
}