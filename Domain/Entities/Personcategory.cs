using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Personcategory
{
    public int Id { get; set; }

    public string NameCategory { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
