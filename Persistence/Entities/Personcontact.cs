using System;
using System.Collections.Generic;

namespace Persistence.Entities;

public partial class Personcontact
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public int IdPerson { get; set; }

    public int IdContactType { get; set; }

    public virtual Contacttype IdContactTypeNavigation { get; set; } = null!;

    public virtual Person IdPersonNavigation { get; set; } = null!;
}
