using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Projeto_Livraria.DataBase;
using MySql.Data.MySqlClient;
using System.Text;

namespace Projeto_Livraria.Commands
{
    public class ImportarLivrosAPICommand : ICommand
    {
        private readonly string _tema;
        private readonly Repositorio _repo = new Repositorio();

        public ImportarLivrosAPICommand(string tema) => _tema = tema;

        public void Execute()
        {
            Console.OutputEncoding = Encoding.UTF8;
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    Console.WriteLine($"\n[INFO] Consultando Nuvem para: {_tema}...");
                
                    string url = $"https://www.googleapis.com/books/v1/volumes?q={Uri.EscapeDataString(_tema)}&maxResults=5&langRestrict=pt";

                    string response = client.GetStringAsync(url).Result;
                    var items = JObject.Parse(response)["items"];

                    if (items != null)
                    {
                        foreach (var item in items)
                        {
                            string tit = item["volumeInfo"]["title"]?.ToString() ?? "S/T";
                            string aut = item["volumeInfo"]["authors"]?[0]?.ToString() ?? "Desconhecido";

                            Salvar(tit, aut);
                            Console.WriteLine($" [+] Importado: {tit}");
                        }
                    }
                    else Console.WriteLine("\n[!] Nenhum resultado encontrado.");
                }
                catch (Exception ex) { Console.WriteLine("\n[Erro API]: " + ex.Message); }
            }
        }

        private void Salvar(string t, string a)
        {
            string sql = "INSERT INTO livros (titulo, autor) VALUES (@t, @a)";
            var p = new[] { new MySqlParameter("@t", t), new MySqlParameter("@a", a) };
            _repo.ExecutarComando(sql, p);
        }

        public void Desfazer() { }
    }
}