using System;
using System.Collections.Generic;

namespace Dadabase.data;

public partial class Jokereactioncategory
{
    public int Id { get; set; }

    public string? Recationlevel { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<Deliveredjoke> Deliveredjokes { get; set; } = new List<Deliveredjoke>();
}
