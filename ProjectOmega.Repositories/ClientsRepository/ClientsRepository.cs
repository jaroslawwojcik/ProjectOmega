using ProjectOmega.DAL.Firebird;
using ProjectOmega.DAL.MsSql.Services;
using ProjectOmega.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOmega.Repositories.ClientsRepository
{
    public class ClientsRepository : ProjectOmega.DAL.Firebird.Repositories.BaseRepository<R3_CONTACTS> , IClientsRepository
    {
        
        private readonly ApplicationDbContext _sqlContext = new ApplicationDbContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationDbContext>());

        public ClientsRepository(RaksConnectionString raksConnection) :
            base(raksConnection)
        {
            
        }

        public void Create(Client order)
        {
            throw new NotImplementedException();
        }

        public Client GetById(long id)
        {
            var fbClient = base.GetById((int)id);
            return new Client
            {
                Id = fbClient.ID,
                ShortName = fbClient.SHORT_NAME,
                FullName = fbClient.FULL_NAME,
            };
        }

        public void Update(Client order)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Client> IClientsRepository.GetAll()
        {
            List<Client> clients = null;
            var fbClientList = base.GetAll();
            foreach(var client in fbClientList)
            {
                var sqlClientEntity = new Client
                {
                    Id = client.ID,
                    ShortName = client.SHORT_NAME,
                    FullName = client.FULL_NAME,
                };
                clients.Add(sqlClientEntity);
            }
            return clients;
        }
    }
}
