using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Programming
{
    public int Id { get; set; }

    public int IdContract { get; set; }

    public int IdShifts { get; set; }

    public int IdEmployee { get; set; }

    public virtual Contract IdContractNavigation { get; set; } = null!;

    public virtual Person IdEmployeeNavigation { get; set; } = null!;

    public virtual Shift IdShiftsNavigation { get; set; } = null!;
}
