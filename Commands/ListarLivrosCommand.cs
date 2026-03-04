using System;
using Projeto_Livraria.DataBase;

namespace Projeto_Livraria.Commands
{
    public class ListarLivrosCommand : ICommand
    {
        private readonly Repositorio _repo = new Repositorio();
        private readonly string _filtro;

        public ListarLivrosCommand(string filtro = "TODOS")
        {
            _filtro = filtro;
        }

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine($"--- LISTAGEM DE LIVROS ({_filtro}) ---");

            string sql = @"SELECT l.id, l.titulo, l.autor, e.id_livro as esta_emprestado 
                           FROM livros l 
                           LEFT JOIN emprestimos e ON l.id = e.id_livro";

            using var reader = _repo.ConsultarComParametros(sql, null);
            if (reader == null) return;

            while (reader.Read())
            {
                bool emprestado = reader["esta_emprestado"] != DBNull.Value;
                string info = $"ID: {reader["id"]} | Título: {reader["titulo"]} | Autor: {reader["autor"]}";

                if (_filtro == "DISPONIVEIS" && emprestado) continue;
                if (_filtro == "EMPRESTADOS" && !emprestado) continue;

                if (emprestado)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{info} [EMPRESTADO]");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{info} [DISPONÍVEL]");
                    Console.ResetColor();
                }
            }
        }

        public void Desfazer() { }
    }
}