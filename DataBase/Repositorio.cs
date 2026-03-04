using MySql.Data.MySqlClient;
using System;

namespace Projeto_Livraria.DataBase
{
    public class Repositorio
    {
        private readonly string _strConn = "Server=localhost;Database=livraria;Uid=root;Pwd=;CharSet=utf8;";

        public void ExecutarComando(string sql, MySqlParameter[] parametros)
        {
            try
            {
                using var conn = new MySqlConnection(_strConn);
                conn.Open();
                using var cmd = new MySqlCommand(sql, conn);
                if (parametros != null) cmd.Parameters.AddRange(parametros);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("\n  [ERRO] Falha na conexao com o banco: " + ex.Message);
            }
        }

        public MySqlDataReader ConsultarComParametros(string sql, MySqlParameter[] parametros)
        {
            try
            {
                var conn = new MySqlConnection(_strConn);
                conn.Open();
                var cmd = new MySqlCommand(sql, conn);
                if (parametros != null) cmd.Parameters.AddRange(parametros);
                return cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch { return null; }
        }

        public bool AlunoJaPossuiEmprestimo(int id)
        {
            string sql = "SELECT COUNT(*) FROM emprestimos WHERE id_aluno = @id";
            using var conn = new MySqlConnection(_strConn);
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        public bool LivroJaEstaEmprestado(int id)
        {
            string sql = "SELECT COUNT(*) FROM emprestimos WHERE id_livro = @id";
            using var conn = new MySqlConnection(_strConn);
            conn.Open();
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", id);
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
    }
}