using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repositories
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartment
    {
        private readonly BiosegurityContext _context;

        public DepartmentRepository(BiosegurityContext context) : base(context)
        {
            _context = context;
        }
    }
}