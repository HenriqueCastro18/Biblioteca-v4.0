using System;
using Projeto_Livraria.Commands;
using Projeto_Livraria.DataBase;

namespace Projeto_Livraria.Services
{
    public class EmprestimoService : TemplateMethod
    {
        private readonly Invoker _invoker = new Invoker();
        private readonly Repositorio _repo = new Repositorio();

        public override void Executar(string opcao)
        {
            switch (opcao)
            {
                case "1":
                    Console.Write("\n  ID do Aluno: ");
                    if (!int.TryParse(Console.ReadLine(), out int idA)) break;

                    if (_repo.AlunoJaPossuiEmprestimo(idA))
                    {
                        Console.WriteLine("  [!] Aluno já possui empréstimo ativo.");
                        break;
                    }

                    Console.Write("  ID do Livro: ");
                    if (!int.TryParse(Console.ReadLine(), out int idL)) break;

                    if (_repo.LivroJaEstaEmprestado(idL))
                    {
                        Console.WriteLine("  [!] Livro indisponível.");
                        break;
                    }

                    _invoker.Executar(new EmprestimoCommand(idA, idL));
                    break;

                case "2":
                    new ListarEmprestimosCommand().Execute();
                    break;

                case "3":
                    new ListarEmprestimosCommand().Execute();
                    Console.Write("\n  ID do Empréstimo para DEVOLVER: ");
                    if (int.TryParse(Console.ReadLine(), out int idEmp))
                        _invoker.Executar(new DevolverLivroCommand(idEmp));
                    break;
            }
            Console.WriteLine("\n  Pressione qualquer tecla...");
            Console.ReadKey();
        }
    }
}