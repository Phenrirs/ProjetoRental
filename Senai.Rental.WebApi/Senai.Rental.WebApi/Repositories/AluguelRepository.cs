using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;

namespace Senai.Rental.WebApi.Repositories
{
    public class AluguelRepository : IAluguelRepository
    {
        private string stringConexao = "Data source=DESKTOP-K4LS7DJ\\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=Senai@132";

        public void AtualizaridCorpo(AluguelDomain aluguelAtualizado)
        {
            if(aluguelAtualizado.Preco != null && aluguelAtualizado.Inicio !=null && aluguelAtualizado.Fim !=null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE Aluguel SET idVeiculo = @Veiculo,idCliente = @Cliente, Preco = @Preco, Inicio = @Inicio, Fim = @Fim WHERE idAluguel = @Aluguel";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@Fim", aluguelAtualizado.Fim);

                        cmd.Parameters.AddWithValue("@Inicio", aluguelAtualizado.Inicio);

                        cmd.Parameters.AddWithValue("@Cliente", aluguelAtualizado.idCliente);

                        cmd.Parameters.AddWithValue("@Veiculo", aluguelAtualizado.idVeiculo);
                    }
                }

            }
        }

        /// <summary>
        /// Repositório responsável por atualizar os aluueis através do id da url!
        /// </summary>
        /// <param name="idAluguel"></param>
        /// <param name="aluguelAtualizado"></param>
        public void AtualizarIdUrl(int idAluguel, AluguelDomain aluguelAtualizado)
        {
            if (aluguelAtualizado.Preco != null && aluguelAtualizado.Inicio != null && aluguelAtualizado.Fim !=null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE Aluguel SET idVeiculo = @idVeiculo, idCliente = @idCliente, Preco = @Preco, Inicio = @Inicio, Fim = @Fim WHERE idALuguel = @idALuguel";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@idVeiculo", aluguelAtualizado.idVeiculo);
                        cmd.Parameters.AddWithValue("@idCliente", aluguelAtualizado.idCliente);
                        cmd.Parameters.AddWithValue("@Preco", aluguelAtualizado.Preco);
                        cmd.Parameters.AddWithValue("@Inicio", aluguelAtualizado.Inicio);
                        cmd.Parameters.AddWithValue("@Fim", aluguelAtualizado.Fim);
                        cmd.Parameters.AddWithValue("@idAluguel", aluguelAtualizado.idAluguel);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// Repositório responsável pela busca de aluguéis através dos ids dos mesmos!
        /// </summary>
        /// <param name="idAluguel">Aluguel buscado</param>
        /// <returns></returns>
        public AluguelDomain BuscarId(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idAluguel, V.idVeiculo, C.idCliente, Preco, Inicio, Fim, V.Placa, C.nomeCliente,C.sobreNome FROM Aluguel" +
                    " INNER JOIN Veiculo V ON Aluguel.idVeiculo = V.idVeiculo" +
                    " INNER JOIN Cliente C ON Aluguel.idCliente = C.idCliente" +
                    " WHERE idAluguel = @idAluguel";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        AluguelDomain aluguelBuscado = new AluguelDomain
                        {
                            idAluguel = Convert.ToInt32(reader["idAluguel"]),

                            idVeiculo = Convert.ToInt32(reader["idVeiculo"]),
                            
                            idCliente = Convert.ToInt32(reader["idCliente"]),

                            Preco = reader["Preco"].ToString(),

                            Inicio = reader["Inicio"].ToString(),

                            Fim = reader["Fim"].ToString(),

                            Veiculo = new VeiculoDomain()
                            {
                                idVeiculo = Convert.ToInt32(reader["idVeiculo"]),
                            },

                            Cliente = new ClienteDomain()
                            {
                                idCliente = Convert.ToInt32(reader["idCliente"]),
                            }
                        };
                        return aluguelBuscado;
                    }
                    return null;
                }
            }

            throw new NotImplementedException();
        }

        /// <summary>
        /// repositório responsável pelo cadastro de novos aluguéis!
        /// </summary>
        /// <param name="novoAluguel">Novo aluguel</param>
        public void Cadastrar(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Aluguel (idVeiculo,idCliente,Preco,Inicio,Fim) VALUES (@idVeiculo,@idCliente,@Preco,@Inicio,@Fim)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", novoAluguel.idVeiculo);
                    cmd.Parameters.AddWithValue("@idCliente", novoAluguel.idCliente);
                    cmd.Parameters.AddWithValue("@Preco", novoAluguel.Preco);
                    cmd.Parameters.AddWithValue("@Inicio", novoAluguel.Inicio);
                    cmd.Parameters.AddWithValue("@Fim", novoAluguel.Fim);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Repoítório responsável por deletar os aluguéis cadastrados! 
        /// </summary>
        /// <param name="idAluguel">Aluguel Deletado</param>
        public void Deletar(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Aluguel WHERE idAluguel = @idAluguel";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista de todos os Aluguéis!
        /// </summary>
        /// <returns>Alugueis Listados</returns>
        public List<AluguelDomain> ListarTodos()
        {
            //
            List<AluguelDomain> ListaAluguel = new List<AluguelDomain>();

            //
            using (SqlConnection con = new SqlConnection(stringConexao)) 
            {
                //
                string querySelectAll = "SELECT idAluguel, idVeiculo, idCliente, Preco, Inicio, Fim FROM Aluguel;";

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
                        AluguelDomain Aluguel = new AluguelDomain()
                        {
                            //
                            idAluguel = Convert.ToInt32(rdr[0]),
                            
                            //
                            idVeiculo = Convert.ToInt32(rdr[1]),
                            
                            //
                            idCliente = Convert.ToInt32(rdr[2]),

                            //
                            Preco = rdr[3].ToString(),
                            
                            //
                            Inicio = rdr[4].ToString(),
                            
                            //
                            Fim = rdr[5].ToString(),
                        };
                        //
                        ListaAluguel.Add(Aluguel);
                    }              
                }            
            }
            //Retorna a lista de Aluguéies para a tela do usuário!
            return ListaAluguel;
        }
    }
}
