using Projeto_Livraria.DataBase;
using MySql.Data.MySqlClient;
using System;

namespace Projeto_Livraria.Commands
{
    public class ExcluirRegistroCommand : ICommand
    {
        private readonly string _tabela;
        private readonly int _id;
        private readonly Repositorio _repo = new Repositorio();

        public ExcluirRegistroCommand(string tabela, int id)
        {
            _tabela = tabela;
            _id = id;
        }

        public void Execute()
        {
         
            string sql = $"DELETE FROM {_tabela} WHERE id = @id";
            var p = new[] { new MySqlParameter("@id", _id) };
            _repo.ExecutarComando(sql, p);
            Console.WriteLine($"\n[✓] Registro ID {_id} removido da tabela {_tabela}.");
        }

        public void Desfazer()
        {
            
        }
    }
}