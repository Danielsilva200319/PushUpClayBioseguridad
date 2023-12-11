using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class PersonTypeRepository : GenericRepository<Persontype>, IPersonType
    {
        private readonly BiosegurityContext _context;

        public PersonTypeRepository(BiosegurityContext context) : base(context)
        {
            _context = context;
        }
    }
}