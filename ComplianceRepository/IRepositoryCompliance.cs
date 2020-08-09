using ComplianceRepository.Data;

namespace ComplianceRepository
{
    public interface IRepositoryCompliance
    {
        Peoples GetPeoples(int sinceSec = 0, int untilSec = 0);
        void Init(string key, string urlService);
    }
}