using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class PersonCategoryRepository : GenericRepository<Personcategory>, IPersonCategory
    {
        private readonly BiosegurityContext _context;

        public PersonCategoryRepository(BiosegurityContext context) : base(context)
        {
            _context = context;
        }
    }
}