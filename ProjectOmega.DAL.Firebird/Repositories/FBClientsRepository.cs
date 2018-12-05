using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using ProjectOmega.DAL.Firebird;
using ProjectOmega.DAL.Firebird.Repositories.Interfaces;

namespace ProjectOmega.DAL.Firebird.Repositories
{
    public class FBClientsRepository : BaseRepository<R3_CONTACTS>, IFBClientsRepository<R3_CONTACTS> 
    {
        public FBClientsRepository(RaksConnectionString context)
            : base(context)
        {

        }

    }
}