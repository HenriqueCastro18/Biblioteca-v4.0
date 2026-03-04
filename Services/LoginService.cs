using System;
using Projeto_Livraria.DataBase;
using MySql.Data.MySqlClient;

namespace Projeto_Livraria.Services
{
    public class LoginService
    {
        private readonly Repositorio _repo = new Repositorio();

        public bool FazerLogin()
        {
            Console.Clear();
            Console.WriteLine("=== LOGIN DO SISTEMA ===");
            Console.Write("Usuário: ");
            string user = Console.ReadLine() ?? "";
            Console.Write("Senha: ");
            string pass = Console.ReadLine() ?? "";

            string sql = "SELECT COUNT(*) FROM usuarios WHERE username = @u AND password = @p";
            var parametros = new[] {
                new MySqlParameter("@u", user),
                new MySqlParameter("@p", pass)
            };

            using var reader = _repo.ConsultarComParametros(sql, parametros);
            if (reader != null && reader.Read() && Convert.ToInt32(reader[0]) > 0)
            {
                return true;
            }
            return false;
        }
    }
}