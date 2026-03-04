using System;
using Projeto_Livraria.Services;

namespace Projeto_Livraria.Menus
{
    public class Menu_Singleton
    {
        private static Menu_Singleton _instance;
        private static readonly object _lock = new object();

        private Menu_Singleton() { }

        public static Menu_Singleton Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Menu_Singleton();
                    }
                    return _instance;
                }
            }
        }

        public string DesenharMenu(string titulo, string[] opcoes, TemplateMethod servico = null)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            string bordaSuperior = "  ╔" + new string('═', 45) + "╗";
            string bordaInferior = "  ╚" + new string('═', 45) + "╝";

            Console.WriteLine(bordaSuperior);
            string tituloCentralizado = titulo.Length > 41 ? titulo.Substring(0, 41) : titulo;
            Console.WriteLine("  ║ " + tituloCentralizado.PadRight(43) + " ║");
            Console.WriteLine(bordaInferior);
            Console.ResetColor();

            Console.WriteLine("\n  Selecione uma operação:");
            Console.WriteLine("  " + new string('─', 40));

            foreach (var opt in opcoes)
            {
                Console.WriteLine("    " + opt);
            }

            Console.WriteLine("  " + new string('─', 40));
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("  ▶ OPÇÃO: ");
            Console.ResetColor();

            string escolha = Console.ReadLine() ?? "";

            if (servico != null && escolha != "0")
            {
                servico.Executar(escolha);
            }

            return escolha;
        }
    }
}