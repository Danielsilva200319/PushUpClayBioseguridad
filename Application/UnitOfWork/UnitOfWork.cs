using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repositories;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly BiosegurityContext _context;
        public UnitOfWork(BiosegurityContext context)
        {
            _context = context;
        }
        private AddressTypeRepository _addresstypes;
        private CityRepository _cities;
        private ContactTypeRepository _contacttypes;
        private ContractRepository _contracts;
        private CountryRepository _countries;
        private DepartmentRepository _departments;
        private PersonRepository _persons;
        private PersonAddressRepository _personAddresses;
        private PersonCategoryRepository _personCategories;
        private PersonContactRepository _personContacts;
        private PersonTypeRepository _personTypes;
        private ProgrammingRepository _programmings;
        private ShiftRepository _shifts;
        private StateRepository _states;
        private RolRepository _rols;
        private RefreshTokenRepository _refreshTokens;
        private UserRepository _users;

        public IAddressType AddressTypes
        {
            get
            {
                if (_addresstypes == null)
                {
                    _addresstypes = new AddressTypeRepository(_context);
                }
                return _addresstypes;
            }
        }

        public ICity Cities
        {
            get
            {
                if (_cities == null)
                {
                    _cities = new CityRepository(_context);
                }
                return _cities;
            }
        }

        public IContactType ContactTypes
        {
            get
            {
                if (_contacttypes == null)
                {
                    _contacttypes = new ContactTypeRepository(_context);
                }
                return _contacttypes;
            }
        }

        public IContract Contracts
        {
            get
            {
                if (_contracts == null)
                {
                    _contracts = new ContractRepository(_context);
                }
                return _contracts;
            }
        }

        public ICountry Countries
        {
            get
            {
                if (_countries == null)
                {
                    _countries = new CountryRepository(_context);
                }
                return _countries;
            }
        }

        public IDepartment Departments
        {
            get
            {
                if (_departments == null)
                {
                    _departments = new DepartmentRepository(_context);
                }
                return _departments;
            }
        }

        public IPerson Persons
        {
            get
            {
                if (_persons == null)
                {
                    _persons = new PersonRepository(_context);
                }
                return _persons;
            }
        }

        public IPersonAddress PersonAddresses
        {
            get
            {
                if (_personAddresses == null)
                {
                    _personAddresses = new PersonAddressRepository(_context);
                }
                return _personAddresses;
            }
        }

        public IPersonCategory PersonCategories
        {
            get
            {
                if (_personCategories == null)
                {
                    _personCategories = new PersonCategoryRepository(_context);
                }
                return _personCategories;
            }
        }

        public IPersonContact PersonContacts
        {
            get
            {
                if (_personContacts == null)
                {
                    _personContacts = new PersonContactRepository(_context);
                }
                return _personContacts;
            }
        }

        public IPersonType PersonTypes
        {
            get
            {
                if (_personTypes == null)
                {
                    _personTypes = new PersonTypeRepository(_context);
                }
                return _personTypes;
            }
        }

        public IProgramming Programmings
        {
            get
            {
                if (_programmings == null)
                {
                    _programmings = new ProgrammingRepository(_context);
                }
                return _programmings;
            }
        }

        public IShift Shifts
        {
            get
            {
                if (_shifts == null)
                {
                    _shifts = new ShiftRepository(_context);
                }
                return _shifts;
            }
        }

        public IState States
        {
            get
            {
                if (_states == null)
                {
                    _states = new StateRepository(_context);
                }
                return _states;
            }
        }
        public IRol Rols
        {
            get
            {
                if (_rols == null)
                {
                    _rols = new RolRepository(_context);
                }
                return _rols;
            }
        }
        public IRefreshToken RefreshToken
        {
            get
            {
                if (_refreshTokens == null)
                {
                    _refreshTokens = new RefreshTokenRepository(_context);
                }
                return _refreshTokens;
            }
        }
        public IUser Users
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_context);
                }
                return _users;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}