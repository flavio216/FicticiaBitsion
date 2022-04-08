using Ficticia_Bitsion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ficticia_Bitsion.Services
{
    public class ClientBusiness
    {
        public List<Client> ClientList()
        {
            using (var db = new FicticiaSAContext())
            {
                return db.Clients.ToList();
            }
        }

        public void CreateClient(Client c)
        {
            using (var db = new FicticiaSAContext())
            {
                db.Clients.Add(c);
                db.SaveChanges();
            }
        }

        public void DeleteClient(int id)
        {
            using (var db = new FicticiaSAContext())
            {
                Client client = db.Clients.Find(id);
                db.Clients.Remove(client);
                db.SaveChanges();
            }
        }

        public void UpdateClient(Client c)
        {
            using (var db = new FicticiaSAContext())
            {
                db.Clients.Update(c);
                db.SaveChanges();
            }
        }

        public Client ClientById(int id)
        {
            using (var db = new FicticiaSAContext())
            {
                return db.Clients.FirstOrDefault(c => c.CliId == id);
            }
        }
    }
}
