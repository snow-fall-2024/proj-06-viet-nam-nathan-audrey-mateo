using System;
using System.Collections.Generic;

namespace Dadabase.data;

public partial class Jokecategory
{
    public int Id { get; set; }

    public string? Jokecategoryname { get; set; }

    public string? Descripion { get; set; }

    public virtual ICollection<Categorizedjoke> Categorizedjokes { get; set; } = new List<Categorizedjoke>();
}
