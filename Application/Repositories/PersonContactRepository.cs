using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class PersonContactRepository : GenericRepository<Personcontact>, IPersonContact
    {
        private readonly BiosegurityContext _context;

        public PersonContactRepository(BiosegurityContext context) : base(context)
        {
            _context = context;
        }
    }
}