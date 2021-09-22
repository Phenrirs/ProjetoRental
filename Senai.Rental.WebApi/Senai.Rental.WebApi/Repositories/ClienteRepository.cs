using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;

namespace Senai.Rental.WebApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetro!
        /// </summary>
        private string stringConexao = "Data source=DESKTOP-K4LS7DJ\\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=Senai@132";

        /// <summary>
        /// Repositório responsável pela atualização através do id do corpo!
        /// </summary>
        /// <param name="clienteAtualizado">Cliente Atualizado</param>
        public void AtualizarIdCorpo(ClienteDomain clienteAtualizado)
        {
            //O que é "!=" = Diferença
            //Método para atualizar mais de um campo especifico, porém, como esse método foi estipulado não poderemos atualizar apenas um campo, isso é possivel de ser 
            //feito porém precisa de um estudo mais profundo!
            //Como nenhum desses campos podem ser null utilizamos &&!
            if (clienteAtualizado.nomeCliente != null && clienteAtualizado.sobreNome != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE Cliente SET nomeCliente = @nomeCliente, sobreNome = @sobreNome WHERE idCliente =@idCliente";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@sobreNome", clienteAtualizado.sobreNome);

                        cmd.Parameters.AddWithValue("@nomeCliente", clienteAtualizado.nomeCliente);

                        cmd.Parameters.AddWithValue("@idCliente", clienteAtualizado.idCliente);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Repositório responsável pela atualização através do id da url!
        /// </summary>
        /// <param name="idCliente"></param>
        /// <param name="clienteAtualizado">Cliente Atualizado</param>
        public void AtualizarIdUrl(int idCliente, ClienteDomain clienteAtualizado)
        {
            using(SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE Cliente SET nomeCliente = @nomeCliente, sobreNome = @sobreNome WHERE idCliente =@idCliente";
                
                using(SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@sobreNome", clienteAtualizado.sobreNome);

                    cmd.Parameters.AddWithValue("@nomeCliente", clienteAtualizado.nomeCliente);

                    cmd.Parameters.AddWithValue(@"idCliente", idCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Repositório responsável pela busca por id!
        /// </summary>
        /// <param name="idCliente">Cliente Buscado</param>
        /// <returns></returns>
        public ClienteDomain BuscarPorId(int idCliente)
        {
            //
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idCliente, nomeCliente, sobreNome FROM Cliente WHERE idCliente = @idCliente";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ClienteDomain clienteBuscado = new ClienteDomain
                        {
                            idCliente = Convert.ToInt32(reader["idCliente"]),

                            nomeCliente = reader["nomeCliente"].ToString(),

                            sobreNome = reader["sobreNome"].ToString(),
                        };

                        return clienteBuscado;
                    }

                    return null;
                }

            }


        }

        /// <summary>
        /// Repositório responsável por Cadastrar!
        /// </summary>
        /// <param name="novoCliente">Cliente Cadastrado</param>
        public void Cadastrar(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Cliente (nomeCliente,sobreNome) VALUES (@nomeCliente,@sobreNome)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobreNome", novoCliente.sobreNome);
            
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Repositório responsável por Deletar
        /// </summary>
        /// <param name="idCliente">Cliente Deletado</param>
        public void Deletar(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Cliente WHERE idCliente = @idCliente";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista de todos os Clientes!
        /// </summary>
        /// <returns></returns>
        public List<ClienteDomain> ListarTodos()
        {
            //
            List<ClienteDomain> ListaCliente = new List<ClienteDomain>();

            //
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //
                string querySelectAll = "SELECT idCliente, nomeCliente, sobreNome FROM Cliente;";

                //
                con.Open();

                //
                SqlDataReader rdr;

                //
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //
                    rdr = cmd.ExecuteReader();

                    //
                    while (rdr.Read())
                    {
                        //
                        ClienteDomain Cliente = new ClienteDomain()
                        {
                            //
                            idCliente = Convert.ToInt32(rdr[0]),

                            //
                            nomeCliente = rdr[1].ToString(),

                            //
                            sobreNome = rdr[2].ToString()

                        };
                        //Sem isso o retono não vai funcionar pois esse ListaCliente.Add se refere ao comando que adiciona os dados do banco na tela do usuário
                        //Através da api!
                        ListaCliente.Add(Cliente);
                    }
                }
            }
            //Retorna a lista de Clientes para a tela do usuário!
            return ListaCliente;
        }



       

       
    }
}
