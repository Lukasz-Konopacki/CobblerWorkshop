using CobblerWorkshop.DbProviders;
using CobblerWorkshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobblerWorkshop.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly SqliteDbContext _context;

        public ClientService(SqliteDbContext databaseContext)
        {
            _context = databaseContext;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }

        public Client? GetClientById(int id)
        {
            return _context.Clients.FirstOrDefault(c => c.Id == id);
        }

        public bool DeleteClient(Client client)
        {
            _context.Clients.Remove(client);
            _context.SaveChanges();
            return true;
        }

        public bool AddClient(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
            return true;
        }

        public bool EditClient(Client client)
        {
            _context.Clients.Update(client);
            _context.SaveChanges();
            return true;
        }
    }
}
