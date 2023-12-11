using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Department
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdCountry { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country IdCountryNavigation { get; set; } = null!;
}
