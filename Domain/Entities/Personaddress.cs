using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Personaddress
{
    public int Id { get; set; }

    public string Address { get; set; } = null!;

    public int IdPerson { get; set; }

    public int IdAddressType { get; set; }

    public virtual Addresstype IdAddressTypeNavigation { get; set; } = null!;

    public virtual Person IdPersonNavigation { get; set; } = null!;
}
