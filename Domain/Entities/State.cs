using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class State : BaseEntity
{
    public string Description { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
