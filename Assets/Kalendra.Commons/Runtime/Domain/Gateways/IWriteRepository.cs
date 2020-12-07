namespace Kalendra.Commons.Runtime.Domain.Gateways
{
    public interface IWriteRepository<T>
    {
        void Save(string hashID, T targetToSave);
    }
}