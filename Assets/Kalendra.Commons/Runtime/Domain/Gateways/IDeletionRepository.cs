namespace Kalendra.Commons.Runtime.Domain.Gateways
{
    public interface IDeletionRepository
    {
        bool Delete(string hashID);
    }
}