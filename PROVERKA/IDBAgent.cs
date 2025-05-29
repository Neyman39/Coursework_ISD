using PROVERKA.Models;

namespace PROVERKA
{
    public interface IDBAgent
    {
        bool ClientCheck(int clientId);
        bool AgreementCheck(string document);
        bool SaveAgreement(string document);
        bool CreateClientAccount(string input);
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
