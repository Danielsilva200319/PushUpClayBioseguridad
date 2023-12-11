﻿using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Country
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
