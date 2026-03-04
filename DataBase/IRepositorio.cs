using MySql.Data.MySqlClient;

namespace Projeto_Livraria.DataBase
{
    public interface IRepositorio
    {
        void ExecutarComando(string sql, MySqlParameter[] parametros);
        MySqlDataReader Consultar(string sql);
    }
}