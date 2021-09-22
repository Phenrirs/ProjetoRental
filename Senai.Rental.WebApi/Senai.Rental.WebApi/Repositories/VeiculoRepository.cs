using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;

namespace Senai.Rental.WebApi.Repositories
{
    public class VeiculoRepository : IVeiculoRepository
    {
        private string stringConexao = "Data source=DESKTOP-K4LS7DJ\\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=Senai@132";

        public void AtualizarIdCorpo(VeiculoDomain veiculoAtualizado)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Repositório responsável pela atualização do Veiculo através do id!
        /// </summary>
        /// <param name="idVeiculo"></param>
        /// <param name="veiculoAtualizado"></param>
        public void AtualizarIdUrl(int idVeiculo, VeiculoDomain veiculoAtualizado)
        {
            if (veiculoAtualizado.Placa != null)
            {
                using (SqlConnection con = new SqlConnection(stringConexao))
                {
                    string queryUpdateBody = "UPDATE Usuario SET idModelo = @idModelo, idEmpresa = @idEmpresa, Placa = @Placa WHERE idVeiculo = @idVeiculo";

                    using (SqlCommand cmd = new SqlCommand(queryUpdateBody, con))
                    {
                        cmd.Parameters.AddWithValue("@idModelo", veiculoAtualizado.idModelo);
                        cmd.Parameters.AddWithValue("@idEmpresa", veiculoAtualizado.idEmpresa);
                        cmd.Parameters.AddWithValue("@Placa", veiculoAtualizado.Placa);

                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Repositório responsável pela busca de veiculos através do id!
        /// </summary>
        /// <param name="idVeiculo">Veiculo buscado</param>
        /// <returns></returns>
        public VeiculoDomain BuscarId(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idVeiuclo, M.idModelo, E.idEmpresa, Placa FROM Veiculo " +
                    "                     INNER JOIN Modelo M ON Veiculo.idModelo = M.idModelo " +
                                         "INNER JOIN Empresa E ON Veiculo.idEmpresa = E.idEmpresa " +
                                         "WHERE idVeiculo = @idVeiculo";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        VeiculoDomain veiculoBuscado = new VeiculoDomain
                        {
                            idVeiculo = Convert.ToInt32(reader["idVeiculo"]),

                            idModelo = Convert.ToInt32(reader["idModelo"]),

                            idEmpresa = Convert.ToInt32(reader["idEmpresa"]),

                            Placa = reader["Placa"].ToString(),

                            Modelo = new ModeloDomain()
                            {
                                idModelo = Convert.ToInt32(reader["idModelo"]),
                            },

                            Empresa = new EmpresaDomain()
                            {
                                idEmpresa = Convert.ToInt32(reader["idEmpresa"]),
                            }
                        };
                        return veiculoBuscado;
                    }
                    return null;
                }
            }
        }

        /// <summary>
        /// Repositório responsável cadastro de novos veiculos!
        /// </summary>
        /// <param name="novoVeiculo">Novo veiculo</param>
        public void Cadastrar(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Veiculo (idModelo,idEmpresa,Placa) VALUES (@idModelo,@idEmpresa,@Placa)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idModelo", novoVeiculo.idModelo);
                    cmd.Parameters.AddWithValue("@idEMpresa", novoVeiculo.idEmpresa);
                    cmd.Parameters.AddWithValue("@Placa", novoVeiculo.Placa);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Repositório responsável por deletar veiculos cadastrados!
        /// </summary>
        /// <param name="idVeiculo">Veiculos deletados</param>
        public void Deletar(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Veiculo WHERE idVeiculo = @idVeiculo";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista de todos os Veiculos!
        /// </summary>
        /// <returns>Veiculos atualizados</returns>
        public List<VeiculoDomain> ListarTodos()
        {
            //
            List<VeiculoDomain> ListaVeiculo = new List<VeiculoDomain>();

            //
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Anotação: No caso dos Joins e inner joins precio aplicar o select inteiro, porém, não precisa ser em uma linha só, ao dar enter na linha 
                // o sistema do VSCommunity aplica uma junção "+" para aquela linha! 
                string querySelectAll = "SELECT idVeiculo, Mo.idModelo, Em.idEmpresa, Placa, nomeModelo, nomeEmpresa, Endereco FROM Veiculo V " +
                                        "RIGHT JOIN Modelo Mo ON V.idModelo = Mo.idModelo " +
                                        "RIGHT JOIN Empresa Em ON V.idEmpresa = Em.idEmpresa; ";

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
                        VeiculoDomain Veiculo = new VeiculoDomain()
                        {
                            //
                            idVeiculo = Convert.ToInt32(rdr[0]),

                            //
                            idModelo = Convert.ToInt32(rdr[1]),

                            //
                            idEmpresa = Convert.ToInt32(rdr[2]),

                            //
                            Placa = rdr[3].ToString(),

                            Modelo = new ModeloDomain()
                            {
                                //
                                nomeModelo = rdr[4].ToString(),
                            },

                            Empresa = new EmpresaDomain()
                            {
                                //
                                nomeEmpresa = rdr[5].ToString(),

                                //
                                Endereco = rdr[6].ToString(),
                            },
                        };
                        //
                        ListaVeiculo.Add(Veiculo);
                    }
                }          
            }
            //Retorna a lista de Veiculos para a tela do usuário!
            return ListaVeiculo;
        }
    }
}
