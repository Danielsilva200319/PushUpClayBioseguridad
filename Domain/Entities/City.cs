using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class City : BaseEntity
{
    public string Name { get; set; } = null!;

    public int IdDepartment { get; set; }

    public virtual Department IdDepartmentNavigation { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
