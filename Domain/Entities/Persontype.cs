using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Persontype
{
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
