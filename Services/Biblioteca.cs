using System;
using Projeto_Livraria.Commands;

namespace Projeto_Livraria.Services
{
    public class Biblioteca : TemplateMethod
    {
        private static readonly Invoker _invoker = new Invoker();

        public override void Executar(string opcao)
        {
            switch (opcao)
            {
                case "1":
                    Console.Write("\n  Título: "); string t = Console.ReadLine() ?? "";
                    Console.Write("  Autor: "); string a = Console.ReadLine() ?? "";
                    _invoker.Executar(new AdicionarLivroCommand(t, a));
                    break;
                case "2": new ListarLivrosCommand("TODOS").Execute(); break;
                case "3": new ListarLivrosCommand("DISPONIVEIS").Execute(); break;
                case "4": new ListarLivrosCommand("EMPRESTADOS").Execute(); break;
                case "5": _invoker.DesfazerUltimo(); break;
                case "6":
                    Console.Write("\n  Tema para busca na API: ");
                    string tema = Console.ReadLine() ?? "";
                    new ImportarLivrosAPICommand(tema).Execute();
                    break;
                case "7":
                    new ListarLivrosCommand("TODOS").Execute();
                    Console.Write("\n  ID do Livro para EXCLUIR: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                        new ExcluirRegistroCommand("livros", id).Execute();
                    break;
            }
            Console.WriteLine("\n  Pressione qualquer tecla...");
            Console.ReadKey();
        }
    }
}