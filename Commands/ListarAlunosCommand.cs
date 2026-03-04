using System;
using Projeto_Livraria.DataBase;

namespace Projeto_Livraria.Commands
{
    public class ListarAlunosCommand : ICommand
    {
        private readonly Repositorio _repo = new Repositorio();

        public void Execute()
        {
            Console.Clear();
            Console.WriteLine("--- LISTA DE ALUNOS CADASTRADOS ---");
            string sql = "SELECT id, nome, ra FROM alunos";

            using var reader = _repo.ConsultarComParametros(sql, null);
            if (reader == null) return;

            bool temDados = false;
            while (reader.Read())
            {
                temDados = true;
                Console.WriteLine($"ID: {reader["id"]} | RA: {reader["ra"]} | Nome: {reader["nome"]}");
            }

            if (!temDados) Console.WriteLine("Nenhum aluno encontrado.");
        }

        public void Desfazer() { } 
    }
}