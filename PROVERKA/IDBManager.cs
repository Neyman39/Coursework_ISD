using PROVERKA.Models;

namespace PROVERKA
{
    public interface IDBManager
    {
        bool SaveAgent(string agent);
        bool RemoveAgent(int? agentId);
        List<Agent> LoadingAgents();
    }
}
