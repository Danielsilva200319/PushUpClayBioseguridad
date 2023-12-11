using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class StateRepository : GenericRepository<State>, IState
    {
        private readonly BiosegurityContext _context;

        public StateRepository(BiosegurityContext context) : base(context)
        {
            _context = context;
        }
    }
}