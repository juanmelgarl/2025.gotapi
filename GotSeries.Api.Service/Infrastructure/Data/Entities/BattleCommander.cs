﻿using System;
using System.Collections.Generic;

namespace GotSeries.Api.Service.Infrastructure.Data.Entities;

public partial class BattleCommander
{
    public int Id { get; set; }

    public int BattleId { get; set; }

    public int CommanderId { get; set; }

    public bool IsAttacker { get; set; }

    public virtual Battle Battle { get; set; } = null!;

    public virtual Character Commander { get; set; } = null!;
}
