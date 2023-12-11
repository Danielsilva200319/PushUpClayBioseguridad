using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Personcontact : BaseEntity
{
    public string Description { get; set; } = null!;

    public int IdPerson { get; set; }

    public int IdContactType { get; set; }

    public virtual Contacttype IdContactTypeNavigation { get; set; } = null!;

    public virtual Person IdPersonNavigation { get; set; } = null!;
}
