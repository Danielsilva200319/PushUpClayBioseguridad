using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class State
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
