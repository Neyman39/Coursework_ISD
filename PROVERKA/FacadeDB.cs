using PROVERKA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace PROVERKA
{
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

        public decimal CalculateInsuranceCost(int insuranceTypeId, Dictionary<int, string> fieldValues)
        {
            // Получаем тип страхования
            var insuranceType = _context.InsuranceTypes
                .FirstOrDefault(it => it.IdInsurance == insuranceTypeId);

            if (insuranceType == null) return 0;

            decimal baseCost = 0;
            decimal finalCost = 0;

            // Расчет в зависимости от типа страхования
            switch (insuranceType.Name.ToLower())
            {
                case "каско":
                    baseCost = 20000;
                    finalCost = CalculateCascoCost(fieldValues, baseCost);
                    break;

                case "здоровье":
                    baseCost = 10000;
                    finalCost = CalculateHealthCost(fieldValues, baseCost);
                    break;

                case "квартира":
                    baseCost = 15000;
                    finalCost = CalculatePropertyCost(fieldValues, baseCost);
                    break;

                default:
                    return 0;
            }

            return finalCost;
        }

        private int GetFieldId(string fieldName)
        {
            return _context.Fields.First(f => f.Name == fieldName).IdField;
        }

        // Расчет стоимости КАСКО
        public decimal CalculateCascoCost(Dictionary<int, string> fieldValues, decimal baseCost)
        {
            decimal cost = baseCost;

            // Стаж вождения
            if (fieldValues.TryGetValue(GetFieldId("Стаж вождения"), out string expValue) &&
                int.TryParse(expValue, out int experience))
            {
                if (experience < 2) cost *= 1.6m;
                else if (experience < 6) cost *= 1.3m;
                else cost *= 1.1m;
            }

            // Мощность двигателя
            if (fieldValues.TryGetValue(GetFieldId("Мощность двигателя"), out string powerValue) &&
                int.TryParse(powerValue, out int power))
            {
                if (power > 200) cost *= 1.5m;
                else if (power > 150) cost *= 1.3m;
                else if (power > 100) cost *= 1.1m;
            }

            return cost;
        }

        // Расчет стоимости страхования здоровья
        public decimal CalculateHealthCost(Dictionary<int, string> fieldValues, decimal baseCost)
        {
            decimal cost = baseCost;

            // Возраст
            if (fieldValues.TryGetValue(GetFieldId("Возраст"), out string ageValue) &&
                int.TryParse(ageValue, out int age))
            {
                if (age > 60) cost *= 1.8m;
                else if (age > 45) cost *= 1.4m;
                else if (age > 30) cost *= 1.1m;
            }

            // Степень опасности
            if (fieldValues.TryGetValue(GetFieldId("Степень опасности производства"), out string dangerValue))
            {
                if (int.TryParse(dangerValue, out int dangerLevel))
                {
                    if (dangerLevel == 1) cost *= 1.1m;
                    else if (dangerLevel == 2) cost *= 1.3m;
                    else if (dangerLevel == 3) cost *= 1.6m;
                    else if (dangerLevel == 4) cost *= 2.0m;
                }
            }

            return cost;
        }

        // Расчет стоимости страхования квартиры
        public decimal CalculatePropertyCost(Dictionary<int, string> fieldValues, decimal baseCost)
        {
            decimal cost = baseCost;

            // Площадь
            if (fieldValues.TryGetValue(GetFieldId("Площадь"), out string areaValue) &&
                int.TryParse(areaValue, out int area))
            {
                if (area > 100) cost *= 1.5m;
                else if (area > 70) cost *= 1.3m;
                else if (area > 50) cost *= 1.1m;
            }

            // Район
            if (fieldValues.TryGetValue(GetFieldId("Район"), out string districtValue))
            {
                districtValue = districtValue.ToLower();

                if (districtValue.Contains("центр")) cost *= 1.5m;
                else if (districtValue.Contains("спальный")) cost *= 1.2m;
                else if (districtValue.Contains("окраина")) cost *= 0.9m;
            }

            return cost;
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

        public List<InsuranceType> LoadingInsuranceTypes()
        {
            return _context.InsuranceTypes
            .AsNoTracking()
            .ToList();
        }

        //public List<InsuranceTypeField> LoadingInsuranceFields(int? insuranceTypeId)
        //{
        //    return _context.InsuranceTypeFields
        //        .Where(itf => itf.IdInsurance == insuranceTypeId)
        //        .Include(itf => itf.IdField) // Подгружаем связанную сущность Field
        //        .AsNoTracking()
        //        .ToList();
        //}

        public List<Field> LoadingInsuranceFields(int insuranceTypeId)
        {
            return _context.InsuranceTypeFields
                .Where(itf => itf.IdInsurance == insuranceTypeId)  // Фильтр по id_insurance
                .Join(_context.Fields,                                  // Соединяем с таблицей field
                    itf => itf.IdField,                            // Поле из insurance_type_field
                    f => f.IdField,                                // Поле из field
                    (itf, f) => new Field                      // Результирующий объект
                    {
                        IdField = f.IdField,
                        Name = f.Name,
                        Type = f.Type
                    })
                .AsNoTracking()
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
        // Реализация методов IDBManager
        public bool SaveAgent(string agent)
        {
            try
            {
                // Парсим строку с данными клиента (формат нужно уточнить)
                var parts = agent.Split('|');

                var queueItem = new Agent
                {
                    FullName = parts[0],
                    Adress = parts[1],
                    Phone = parts[2],
                    Salary = decimal.Parse(parts[3]),
                    Experience = int.Parse(parts[4]),
                    Login = parts[5],
                    Passwd = parts[6]
                };

                _context.Agents.Add(queueItem);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Agent> LoadingAgents()
        {
            return _context.Agents.ToList();
        }
        // Остальные методы интерфейсов...
    }
    public class DatabaseInitializer
    {
        private readonly INDbContext _context;

        public DatabaseInitializer(INDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Создает начальную запись пользователя, если таблица Users пуста
        /// </summary>
        /// <returns>True - если запись была создана, False - если не была создана</returns>
        public bool InitializeDefaultUser()
        {
            try
            {
                // Проверяем подключение к БД
                if (!_context.Database.CanConnect())
                {
                    //Console.WriteLine("Ошибка: Нет подключения к базе данных");
                    return false;
                }

                // Проверяем наличие записей
                if (_context.Users.Any())
                {
                    //Console.WriteLine("Таблица Users уже содержит записи");
                    return false;
                }

                // Создаем начального пользователя
                var defaultUser = new User
                {
                    Id = GenerateShortId(),
                    Login = "admin",
                    Passwd = HashPassword("admin123") // Хешируем пароль
                };

                _context.Users.Add(defaultUser);
                _context.SaveChanges();

                Console.WriteLine("Создана начальная запись пользователя");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при инициализации: {ex.Message}");
                return false;
            }
        }

        private string GenerateShortId()
        {
            return Guid.NewGuid().ToString("N").Substring(0, 10);
        }

        private string HashPassword(string password)
        {
            // Реальная реализация должна использовать надежное хеширование
            // Например, BCrypt или PBKDF2
            using var sha256 = System.Security.Cryptography.SHA256.Create();
            var hashedBytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }

        
    }
}
