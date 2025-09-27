using System;
using System.Collections.Generic;

namespace GotSeries.Api.Service.Infrastructure.Data.Entities;

public partial class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}
