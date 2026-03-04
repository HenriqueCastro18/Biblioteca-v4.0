using Projeto_Livraria.DataBase;
using MySql.Data.MySqlClient;
using System;

namespace Projeto_Livraria.Commands
{
    public class DevolverLivroCommand : ICommand
    {
        private readonly int _idEmprestimo;
        private readonly Repositorio _repo = new Repositorio();

        public DevolverLivroCommand(int idEmprestimo)
        {
            _idEmprestimo = idEmprestimo;
        }

        public void Execute()
        {
            var sql = "DELETE FROM emprestimos WHERE id = @id";
            var parametros = new[] {
                new MySqlParameter("@id", _idEmprestimo)
            };

            _repo.ExecutarComando(sql, parametros);
            Console.WriteLine("\n[SUCESSO] Livro devolvido e registro baixado!");
        }

        public void Desfazer()
        {

        }
    }
}