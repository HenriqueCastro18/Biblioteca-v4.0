using Projeto_Livraria.DataBase;
using MySql.Data.MySqlClient;

namespace Projeto_Livraria.Commands
{
    public class AdicionarLivroCommand : ICommand
    {
        private readonly string _titulo;
        private readonly string _autor;
        private readonly Repositorio _repo = new Repositorio();

        public AdicionarLivroCommand(string titulo, string autor)
        {
            _titulo = titulo;
            _autor = autor;
        }

        public void Execute()
        {
            string sql = "INSERT INTO livros (titulo, autor) VALUES (@t, @a)";
            var p = new[] {
                new MySqlParameter("@t", _titulo),
                new MySqlParameter("@a", _autor)
            };
            _repo.ExecutarComando(sql, p);
        }

        public void Desfazer()
        {
            string sql = "DELETE FROM livros WHERE titulo = @t ORDER BY id DESC LIMIT 1";
            var p = new[] { new MySqlParameter("@t", _titulo) };
            _repo.ExecutarComando(sql, p);
        }
    }
}