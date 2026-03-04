using System;
using Projeto_Livraria.Menus;
using Projeto_Livraria.Services;
using Projeto_Livraria.Commands;
using System.Text;

namespace Projeto_Livraria
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            LoginService loginService = new LoginService();
            string opcao = "";

            while (opcao != "0")
            {
                DesenharBannerPrincipal();
                Console.WriteLine("  [1] ACESSAR O SISTEMA");
                Console.WriteLine("  [2] CADASTRAR NOVO ADMINISTRADOR");
                Console.WriteLine("  [9] LIMPEZA TOTAL DO BANCO DE DADOS");
                Console.WriteLine("  [0] SAIR");
                Console.WriteLine("\n  " + new string('-', 45));
                Console.Write("  DIGITE A OPCAO DESEJADA: ");

                opcao = Console.ReadLine() ?? "";

                if (opcao == "1") { if (loginService.FazerLogin()) RodarSistemaPrincipal(); }
                else if (opcao == "2") RegistrarAdmin();
                else if (opcao == "9") ExecutarResetGeral();
            }
        }

        static void RodarSistemaPrincipal()
        {
            var menu = Menu_Singleton.Instance;
            string escolha = "";

            while (escolha != "0")
            {
                Console.Clear();
                DesenharSubHeader("PAINEL DE CONTROLE PRINCIPAL");

                escolha = menu.DesenharMenu("O QUE DESEJA GERENCIAR AGORA?",
                    new[] {
                        "1. AREA DO ALUNO (CADASTROS E REGISTROS)",
                        "2. ACERVO DA BIBLIOTECA (LIVROS E PESQUISA)",
                        "3. MOVIMENTACOES (EMPRESTIMOS E DEVOLUCOES)",
                        "0. SAIR / LOGOUT"
                    });

                if (escolha == "1")
                    menu.DesenharMenu("GERENCIAMENTO DE ALUNOS",
                        new[] { "1 - Cadastrar Novo Aluno", "2 - Listar Todos os Alunos", "3 - Desfazer Inclusao", "4 - Remover por ID", "0 - Voltar" }, new Secretaria());

                else if (escolha == "2")
                    menu.DesenharMenu("GESTAO DE ACERVO DE LIVROS",
                        new[] { "1 - Adicionar Manual", "2 - Listar Tudo", "3 - Disponiveis", "4 - Emprestados", "5 - Desfazer", "6 - Buscar Google API", "7 - Remover por ID", "0 - Voltar" }, new Biblioteca());

                else if (escolha == "3")
                    menu.DesenharMenu("SISTEMA DE EMPRESTIMOS",
                        new[] { "1 - Registrar Emprestimo", "2 - Listar e Verificar Atrasos", "3 - Registrar Devolucao", "0 - Voltar" }, new EmprestimoService());
            }
        }

        static void DesenharBannerPrincipal()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  +-----------------------------------------------------+");
            Console.WriteLine("  |        SISTEMA DE GESTAO DE BIBLIOTECA V.4.0        |");
            Console.WriteLine("  +-----------------------------------------------------+");
            Console.ResetColor();
        }

        static void DesenharSubHeader(string titulo)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("  == " + titulo + " ==");
            Console.ResetColor();
        }

        static void RegistrarAdmin()
        {
            Console.Write("\n  Usuario: "); string u = Console.ReadLine() ?? "";
            Console.Write("  Senha: "); string p = Console.ReadLine() ?? "";
            new RegistrarUsuarioCommand(u, p).Execute();
            Console.ReadKey();
        }

        static void ExecutarResetGeral()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\n  CONFIRMAR RESET TOTAL? (S/N): ");
            Console.ResetColor();
            if (Console.ReadLine()?.ToUpper() == "S") new ResetarBancoCommand().Execute();
            Console.ReadKey();
        }
    }
}