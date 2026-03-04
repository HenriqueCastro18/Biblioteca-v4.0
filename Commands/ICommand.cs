namespace Projeto_Livraria.Commands
{
    public interface ICommand
    {
        void Execute();
        void Desfazer();
    }
}