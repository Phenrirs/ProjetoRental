namespace Senai.Rental.WebApi.Repositories
{
    internal class SqlConnetion
    {
        private string stringConexao;

        public SqlConnetion(string stringConexao)
        {
            this.stringConexao = stringConexao;
        }
    }
}