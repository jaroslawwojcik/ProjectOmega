using ProjectOmega.DAL.Firebird;
using ProjectOmega.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectOmega.Repositories.ClientsRepository
{
    public interface IClientsRepository : ProjectOmega.DAL.Firebird.Repositories.Interfaces.IBaseRepository<R3_CONTACTS>
    {
        void Create(Client order);
        void Update(Client order);
        new IEnumerable<Client> GetAll();
        Client GetById(long id);
    }  
}
