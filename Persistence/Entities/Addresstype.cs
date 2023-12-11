using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Addresstype
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Personaddress> Personaddresses { get; set; } = new List<Personaddress>();
}
