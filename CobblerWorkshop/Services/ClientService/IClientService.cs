using CobblerWorkshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CobblerWorkshop.Services.ClientService
{
    public interface IClientService
    {
        public IEnumerable<Client> GetAllClients();
        public Client? GetClientById(int id);
        public bool DeleteClient(Client client);
        public bool AddClient(Client client);
        public bool EditClient(Client client);
    }
}
