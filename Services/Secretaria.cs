using System;
using Projeto_Livraria.Commands;

namespace Projeto_Livraria.Services
{
    public class Secretaria : TemplateMethod
    {
        private static readonly Invoker _invoker = new Invoker();

        public override void Executar(string opcao)
        {
            switch (opcao)
            {
                case "1":
                    Console.Write("\n  Nome do Aluno: ");
                    string nome = Console.ReadLine() ?? "";
                    Console.Write("  RA do Aluno: ");
                    string ra = Console.ReadLine() ?? "";
                    if (!string.IsNullOrEmpty(nome) && !string.IsNullOrEmpty(ra))
                        _invoker.Executar(new AdicionarAlunoCommand(nome, ra));
                    break;

                case "2":
                    new ListarAlunosCommand().Execute();
                    break;

                case "3":
                    _invoker.DesfazerUltimo();
                    break;

                case "4":
                    new ListarAlunosCommand().Execute();
                    Console.Write("\n  ID do Aluno para EXCLUIR: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                        new ExcluirRegistroCommand("alunos", id).Execute();
                    break;
            }
            Console.WriteLine("\n  Pressione qualquer tecla...");
            Console.ReadKey();
        }
    }
}