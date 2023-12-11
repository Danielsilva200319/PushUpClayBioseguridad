using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class CityRepository : GenericRepository<City>, ICity
    {
        private readonly BiosegurityContext context;

        public CityRepository(BiosegurityContext context) : base(context)
        {
            this.context = context;
        }
    }
}