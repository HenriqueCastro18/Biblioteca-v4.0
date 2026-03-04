using Projeto_Livraria.DataBase;
using MySql.Data.MySqlClient;
using System;

namespace Projeto_Livraria.Commands
{
    public class EmprestimoCommand : ICommand
    {
        private readonly int _idAluno;
        private readonly int _idLivro;
        private readonly Repositorio _repo = new Repositorio();

        public EmprestimoCommand(int idAluno, int idLivro)
        {
            _idAluno = idAluno;
            _idLivro = idLivro;
        }

        public void Execute()
        {
            var sql = "INSERT INTO emprestimos (id_aluno, id_livro) VALUES (@aluno, @livro)";
            var parametros = new[] {
                new MySqlParameter("@aluno", _idAluno),
                new MySqlParameter("@livro", _idLivro)
            };
            _repo.ExecutarComando(sql, parametros);
            Console.WriteLine("\n[SUCESSO] Empréstimo registrado!");
        }

        public void Desfazer() {  }
    }
}