using System.Threading.Tasks;

namespace Kalendra.Commons.Runtime.Domain.Patterns
{
    #region Sync
    public interface ICommand
    {
        void Execute();
        void Undo();
    }
    
    public interface ICommand<in T>
    {
        void Execute(T arg);
        void Undo(T arg);
    }
    #endregion

    public interface ICommandAsync
    {
        Task Execute();
        Task Undo();
    }

    public interface ICommandAsync<T>
    {
        Task Execute(T arg);
        Task Undo(T arg);
    }
}