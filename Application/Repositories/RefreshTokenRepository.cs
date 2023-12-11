using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class RefreshTokenRepository : GenericRepository<RefreshToken>, IRefreshToken
    {
        private readonly BiosegurityContext _context;

        public RefreshTokenRepository(BiosegurityContext context) : base(context)
        {
            _context = context;
        }
    }
}