using System;
using System.IO;
using Projeto_Livraria.DataBase;
using MySql.Data.MySqlClient;

namespace Projeto_Livraria.Services
{
    public static class LogService
    {
        private static readonly Repositorio _repo = new();

        public static void GravarLog(string mensagem)
        {

            var sql = "INSERT INTO logs (descricao) VALUES (@desc)";
            _repo.ExecutarComando(sql, new[] { new MySqlParameter("@desc", mensagem) });

            File.AppendAllText("log_sistema.txt", $"[{DateTime.Now}] {mensagem}{Environment.NewLine}");
        }
    }
}