using PROVERKA.Models;

namespace PROVERKA
{
    public interface IDBAgent
    {
        bool ClientCheck(string phone);
        Client GetClient(string phone);
        void RemoveClientFromQueue(int? clientId);
        bool AgreementCheck(string document);
        bool CreateClientAccount(string input);
        bool CreateAgreement(decimal sumInsured, int? idAgent, int? idClient, int? branchId, int? insuranceId, decimal? agentPremium);
        List<InsuranceType> LoadingInsuranceTypes();
        List<Field> LoadingInsuranceFields(int typeOfInsurance);
        List<ClientQueue> LoadingClientsQueue();
        bool QueueCheck(string client);
        bool SaveQueue(string client);

        decimal CalculateInsuranceCost(int insuranceTypeId, Dictionary<int, string> fieldValues);
        //decimal CalculateCascoCost(Dictionary<int, string> fieldValues, decimal baseCost);
        //decimal CalculateHealthCost(Dictionary<int, string> fieldValues, decimal baseCost);
        //decimal CalculatePropertyCost(Dictionary<int, string> fieldValues, decimal baseCost);
    }
}
