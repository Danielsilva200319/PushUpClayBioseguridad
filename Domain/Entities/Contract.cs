using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Contract
{
    public int Id { get; set; }

    public DateOnly DateContract { get; set; }

    public DateOnly DateEnd { get; set; }

    public int IdClient { get; set; }

    public int IdEmployee { get; set; }

    public int IdState { get; set; }

    public virtual Person IdClientNavigation { get; set; } = null!;

    public virtual Person IdEmployeeNavigation { get; set; } = null!;

    public virtual State IdStateNavigation { get; set; } = null!;

    public virtual ICollection<Programming> Programmings { get; set; } = new List<Programming>();
}
