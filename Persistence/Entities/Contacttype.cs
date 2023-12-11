using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Contacttype
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Personcontact> Personcontacts { get; set; } = new List<Personcontact>();
}
