using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Department : BaseEntity
{
    public string Name { get; set; } = null!;

    public int IdCountry { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country IdCountryNavigation { get; set; } = null!;
}
