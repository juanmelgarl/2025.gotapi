using System;
using System.Collections.Generic;

namespace GotSeries.Api.Service.Infrastructure.Data.Entities;

public partial class Season
{
    public byte Id { get; set; }

    public string Name { get; set; } = null!;

    public int Year { get; set; }

    public virtual ICollection<Chapter> Chapters { get; set; } = new List<Chapter>();
}
