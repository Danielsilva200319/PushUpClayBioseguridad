using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Person
{
    public int Id { get; set; }

    public int IdPerson { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly DateReg { get; set; }

    public int IdPersonType { get; set; }

    public int IdCategory { get; set; }

    public int IdCity { get; set; }

    public virtual ICollection<Contract> ContractIdClientNavigations { get; set; } = new List<Contract>();

    public virtual ICollection<Contract> ContractIdEmployeeNavigations { get; set; } = new List<Contract>();

    public virtual Personcategory IdCategoryNavigation { get; set; } = null!;

    public virtual City IdCityNavigation { get; set; } = null!;

    public virtual Persontype IdPersonTypeNavigation { get; set; } = null!;

    public virtual ICollection<Personaddress> Personaddresses { get; set; } = new List<Personaddress>();

    public virtual ICollection<Personcontact> Personcontacts { get; set; } = new List<Personcontact>();

    public virtual ICollection<Programming> Programmings { get; set; } = new List<Programming>();
}
