using static PROVERKA.FacadeDB;

namespace PROVERKA
{
    public interface IDBClient
    {
        ClientAgreementInfo GetClientAgreementInfo(int? clientId);
    }
}
