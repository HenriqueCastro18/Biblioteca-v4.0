using System.Collections.Generic;

namespace Projeto_Livraria.Commands
{
    public class Invoker
    {

        private readonly Stack<ICommand> _historico = new Stack<ICommand>();

        public void Executar(ICommand comando)
        {
            comando.Execute();
            _historico.Push(comando);
        }

        public void DesfazerUltimo()
        {
            if (_historico.Count > 0)
            {
                var comando = _historico.Pop();
                comando.Desfazer();
            }
        }
    }
}