using System;
using Projeto_Livraria.DataBase;

namespace Projeto_Livraria.Commands
{
    public class ListarEmprestimosCommand : ICommand
    {
        private readonly Repositorio _repo = new Repositorio();

        public void Execute()
        {
            Console.WriteLine("\n------------------------------------------------------------");
            Console.WriteLine("        RELATÓRIO DE LIVROS EM POSSE DE ALUNOS              ");
            Console.WriteLine("------------------------------------------------------------");

            string sql = @"SELECT e.id, a.nome as aluno, l.titulo as livro, 
                           TIMESTAMPDIFF(SECOND, e.data_emprestimo, NOW()) as tempo
                           FROM emprestimos e 
                           INNER JOIN alunos a ON e.id_aluno = a.id 
                           INNER JOIN livros l ON e.id_livro = l.id";

            using var reader = _repo.ConsultarComParametros(sql, null);
            if (reader == null) return;

            bool registros = false;
            while (reader.Read())
            {
                registros = true;
                int segundos = Convert.ToInt32(reader["tempo"]);
                string linha = $"[ID {reader["id"]}] Aluno: {reader["aluno"]} | Livro: {reader["livro"]}";

                if (segundos > 10)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{linha} -> [!] ATRASADO (COBRAR TAXA)");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine($"{linha} -> [DENTRO DO PRAZO]");
                    Console.ResetColor();
                }
            }

            if (!registros) Console.WriteLine("   Nenhum empréstimo ativo no momento.");
            Console.WriteLine("------------------------------------------------------------");
        }

        public void Desfazer() { }
    }
}