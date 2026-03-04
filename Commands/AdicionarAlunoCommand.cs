using Projeto_Livraria.DataBase;
using MySql.Data.MySqlClient;

namespace Projeto_Livraria.Commands
{
    public class AdicionarAlunoCommand : ICommand
    {
        private readonly string _nome;
        private readonly string _ra;
        private readonly Repositorio _repo = new Repositorio();

        public AdicionarAlunoCommand(string nome, string ra)
        {
            _nome = nome;
            _ra = ra;
        }

        public void Execute()
        {
            string sql = "INSERT INTO alunos (nome, ra) VALUES (@nome, @ra)";
            var p = new[] {
                new MySqlParameter("@nome", _nome),
                new MySqlParameter("@ra", _ra)
            };
            _repo.ExecutarComando(sql, p);
        }

        public void Desfazer()
        {
            string sql = "DELETE FROM alunos WHERE ra = @ra";
            var p = new[] { new MySqlParameter("@ra", _ra) };
            _repo.ExecutarComando(sql, p);
        }
    }
}