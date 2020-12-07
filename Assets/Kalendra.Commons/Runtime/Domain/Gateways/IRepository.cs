namespace Kalendra.Commons.Runtime.Domain.Gateways
{
    public interface IRepository<T> : IReadOnlyRepository<T>, IWriteRepository<T>, IDeletionRepository { }
}