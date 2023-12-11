using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IAddressType AddressTypes { get; }
        ICity Cities { get; }
        IContactType ContactTypes { get; }
        IContract Contracts { get; }
        IDepartment Departments { get; }
        IPerson Persons { get; }
        IPersonAddress PersonAddresses { get; }
        IPersonCategory PersonCategories { get; }
        IPersonContact PersonContacts { get; }
        IPersonType PersonTypes { get; }
        IProgramming Programmings { get; }
        IShift Shifts { get; }
        IState States { get; }
        Task<int> SaveAsync();
    }
}