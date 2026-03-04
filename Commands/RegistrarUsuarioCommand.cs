using Projeto_Livraria.DataBase;
using MySql.Data.MySqlClient;

namespace Projeto_Livraria.Commands
{
    public class RegistrarUsuarioCommand : ICommand
    {
        private readonly string _user;
        private readonly string _pass;
        private readonly Repositorio _repo = new Repositorio();

        public RegistrarUsuarioCommand(string user, string pass)
        {
            _user = user;
            _pass = pass;
        }

        public void Execute()
        {
            var sql = "INSERT INTO usuarios (username, password) VALUES (@u, @p)";
            var parametros = new[] {
                new MySqlParameter("@u", _user),
                new MySqlParameter("@p", _pass)
            };
            _repo.ExecutarComando(sql, parametros);
        }

        public void Desfazer() { }
    }
}