using Projeto_Livraria.DataBase;
using System;

namespace Projeto_Livraria.Commands
{
    public class ResetarBancoCommand : ICommand
    {
        private readonly Repositorio _repo = new Repositorio();

        public void Execute()
        {

            string sql = @"
                DELETE FROM emprestimos;
                DELETE FROM alunos;
                DELETE FROM livros;
                ALTER TABLE emprestimos AUTO_INCREMENT = 1;
                ALTER TABLE alunos AUTO_INCREMENT = 1;
                ALTER TABLE livros AUTO_INCREMENT = 1;";

            _repo.ExecutarComando(sql, null);
            Console.WriteLine("\n[SUCESSO] Todos os alunos, livros e empréstimos foram removidos!");
            Console.WriteLine("[INFO] Os IDs foram resetados para 1.");
        }

        public void Desfazer()
        {

        }
    }
}