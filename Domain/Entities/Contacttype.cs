using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Contacttype : BaseEntity
{
    public string Description { get; set; } = null!;

    public virtual ICollection<Personcontact> Personcontacts { get; set; } = new List<Personcontact>();
}
