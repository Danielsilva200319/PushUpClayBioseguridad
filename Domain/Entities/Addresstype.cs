using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Addresstype : BaseEntity
{
    public string Description { get; set; } = null!;

    public virtual ICollection<Personaddress> Personaddresses { get; set; } = new List<Personaddress>();
}
