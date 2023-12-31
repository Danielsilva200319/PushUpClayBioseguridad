﻿using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Shift : BaseEntity
{
    public string ShiftName { get; set; } = null!;

    public TimeOnly TimeShiftStart { get; set; }

    public TimeOnly TimeShiftEnd { get; set; }

    public virtual ICollection<Programming> Programmings { get; set; } = new List<Programming>();
}
