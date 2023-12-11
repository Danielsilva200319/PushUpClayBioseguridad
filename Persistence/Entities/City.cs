using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int IdDepartment { get; set; }

    public virtual Department IdDepartmentNavigation { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
