using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class AddressTypeRepository : GenericRepository<Addresstype>, IAddressType
    {
        private readonly BiosegurityContext _context;

        public AddressTypeRepository(BiosegurityContext context) : base(context)
        {
            _context = context;
        }
    }
}