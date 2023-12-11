using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Country : BaseEntity
{
    public string Name { get; set; } = null!;

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
