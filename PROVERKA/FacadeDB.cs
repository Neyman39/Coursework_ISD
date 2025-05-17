using PROVERKA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROVERKA
{
    public interface IDBAgent
    {
        bool ClientCheck(int clientId);
        bool AgreementCheck(string document);
        bool SaveAgreement(string document);
        bool CreateClientAccount(string input);
        List<string> LoadingInsuranceTypes();
        List<string> LoadingInsuranceFields(string typeOfInsurance);
        List<ClientQueue> LoadingClientsQueue();
        bool QueueCheck(string client);
        bool SaveQueue(string client);
    }

    public class FacadeDB : IDBAgent
    {
        private readonly INDbContext _context;

        public FacadeDB()
        {
            _context = new INDbContext();
        }

        // Реализация методов IDBAgent
        public bool ClientCheck(int clientId)
        {
            return _context.ClientsQueues.Any(c => c.IdAgent == clientId);
        }

        public bool AgreementCheck(string document)
        {
            // Логика проверки договора
            return _context.ClientsQueues.Any(a => a.Phone == document);
        }

        public bool SaveAgreement(string document)
        {
            try
            {
                // Логика сохранения договора
                var agreement = new ClientQueue
                {
                    //DocumentNumber = document,
                    RegDate = DateTime.Now
                    // Другие поля
                };

                //_context.Agreements.Add(agreement);
                _context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateClientAccount(string input)
        {
            //try
            //{
            //    // Парсинг входных данных
            //    var data = input.Split('|');

            //    var client = new Client
            //    {
            //        FullName = data[0],
            //        Phone = data[1],
            //        Login = data[2],
            //        Passwd = data[3] // В реальном приложении нужно хэшировать пароль
            //    };

            //    _context.Clients.Add(client);
            //    _context.SaveChanges();
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
            return false;
        }

        public List<string> LoadingInsuranceTypes()
        {
            return _context.ClientsQueues
                .Select(t => t.Phone)
                .ToList();
        }

        public List<string> LoadingInsuranceFields(string typeOfInsurance)
        {
            return _context.ClientsQueues
                .Where(f => f.Phone == typeOfInsurance)
                .Select(f => f.Phone)
                .ToList();
        }
        public List<ClientQueue> LoadingClientsQueue()
        {
            return _context.ClientsQueues
                .OrderBy(q => q.RegDate)
                .ToList();
        }

        public bool QueueCheck(string client)
        {
            // Здесь можно добавить проверку, существует ли уже такой клиент в очереди
            return true;
        }

        public bool SaveQueue(string client)
        {
            try
            {
                // Парсим строку с данными клиента (формат нужно уточнить)
                var parts = client.Split('|');

                var queueItem = new ClientQueue
                {
                    IdAgent = parts.Length > 2 ? int.Parse(parts[2]) : (int?)null,
                    FullName = parts[0],
                    Phone = parts[1],
                    RegDate = DateTime.Now
                };

                _context.ClientsQueues.Add(queueItem);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Остальные методы интерфейсов...
    }
}
