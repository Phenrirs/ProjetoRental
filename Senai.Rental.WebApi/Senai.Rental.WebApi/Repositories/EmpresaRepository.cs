using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;

namespace Senai.Rental.WebApi.Repositories
{
    public class EmpresaRepository
    {
        public class EmpresaReository : IEmpresaRepository
        {

            private string stringConexao = "Data source=DESKTOP-K4LS7DJ\\SQLEXPRESS; initial catalog=M_Rental; user id=sa; pwd=Senai@132";

            public string Stringconexao { get; private set; }

            public void AtualizarIdCorpo(EmpresaDomain empresaAtualizada)
            {
                throw new NotImplementedException();
            }

            public void AtualizarIdUrl(int idEmpresa, EmpresaDomain empresaAtualizada)
            {
                throw new NotImplementedException();
            }

            public EmpresaDomain BuscarPorId(int idEmpresa)
            {
                throw new NotImplementedException();
            }

            public void Cadastrar(EmpresaDomain novaEmpresa)
            {
                throw new NotImplementedException();
            }

            public void Deletar(int idEmpresa)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Método referente a listagem de empresas cadastradas!
            /// </summary>
            /// <returns>Lista de empresas</returns>
            public List<EmpresaDomain> ListarTodos()
            {
                //Classe instanciad que se torna um objeto onde serão armazenados os dados!
                List<EmpresaDomain> listaEmpresa = new List<EmpresaDomain>();

                //Comando sql resonsável pela conexão com o banco!
                using (SqlConnection con = new SqlConnection(Stringconexao))
                {
                    //Caminho de conexão/seleção com o banco!
                    string querySelectALL = "SELECT idEmpresa,nomeEmpresa,Endeco FROM Empresa;";
                    
                    //Declamos que a conexão está aberta!
                    con.Open();
                    
                    //Comando Sql responsável pelo armazenamento dos dados que serão lidos!
                    SqlDataReader rdr;


                    //OUTRA FORMA DE EXECUTAR  LEITURA;
                    //rdr = new SqlCommand(querySelectALL, con).ExecuteReader();

                    //while (rdr.Read())
                    //{

                    //}

                    //ESSE RDR FARIA O PAPEL DO USING PARA ENCERRA O COMANDO QUANDO ACABASSE A CONEXÃO!
                    //rdr.Close();                 

                    

                    //O comando CMD é responsável por receber o comando de caminho de seleção e a conexão com o banco em forma de parâmetro!
                    using (SqlCommand cmd = new SqlCommand(querySelectALL, con)) 
                    {
                        //O RDR é responsável por armazenar a execução de leitura do código CMD!
                        rdr = cmd.ExecuteReader();
                        
                        //Enquanto o RDR estiver lendo 
                        while (rdr.Read()) 
                        {
                            //Instancia um objeto do tipo EmpresaDomain
                            EmpresaDomain Empresa = new EmpresaDomain()
                            {
                                //Atribui a propriedade idEmpresa a primeira posição, ou seja, primeiro campo na nossa tabela!
                                idEmpresa = Convert.ToInt32(rdr[0]),

                                //Atribui a propriedade nomeEmpresa a segundaa posição, ou seja, segundo campo na nossa tabela!
                                nomeEmpresa = rdr[1].ToString(),

                                //Atribui a propriedade Endereco a terceira posição, ou seja, terceiro campo na nossa tabela!
                                Endereco = rdr[2].ToString()
                            };
                            //Adiciona o objeto Empresa criando a listaEmpresa
                            listaEmpresa.Add(Empresa);
                        }
                    }
                }
                //Retorna a lista empresa para a tela do usuário!
                return listaEmpresa;
            }
        }
    }
}
