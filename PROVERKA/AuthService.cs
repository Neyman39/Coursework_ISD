//using PROVERKA;
//using System.Linq;
//using PROVERKA.Models;

//namespace PROVERKA
//{
//    public class AuthService
//    {
//        private readonly INDbContext _context;
//        private readonly IPasswordHasher _passwordHasher;

//        public AuthService(INDbContext context, IPasswordHasher passwordHasher)
//        {
//            _context = context;
//            _passwordHasher = passwordHasher;
//        }

//        public (object user, string role)? Authenticate(string login, string password)
//        {
//            // Сначала проверяем менеджеров (агентов с IsManager = true)
//            var manager = _context.Agents
//                .FirstOrDefault(a => a.Login == login && a.IsManager);

//            if (manager != null && _passwordHasher.VerifyPassword(password, manager.Password))
//            {
//                return (manager, "manager");
//            }

//            // Затем проверяем обычных агентов
//            var agent = _context.Agents
//                .FirstOrDefault(a => a.Login == login && !a.IsManager);

//            if (agent != null && _passwordHasher.VerifyPassword(password, agent.Password))
//            {
//                return (agent, "agent");
//            }

//            // Затем проверяем клиентов
//            var client = _context.Clients
//                .FirstOrDefault(c => c.Login == login);

//            if (client != null && _passwordHasher.VerifyPassword(password, client.Password))
//            {
//                return (client, "client");
//            }

//            return null;
//        }
//    }
//}