using System;
using System.Collections.Generic;

namespace Dadabase.data;

public partial class Audiencecategory
{
    public int Id { get; set; }

    public string? Categoryname { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Categorizedaudience> Categorizedaudiences { get; set; } = new List<Categorizedaudience>();
}
