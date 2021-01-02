namespace Kalendra.Commons.Runtime.Architecture.Gateways
{
    public interface IRepository<T> : IReadOnlyRepository<T>, IWriteRepository<T>, IDeletionRepository { }
}