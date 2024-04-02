using System;
using System.Collections.Generic;

namespace surprizeApi.Models;

public partial class PeriodeSubscription
{
    public int? IdPeriodeSubscription { get; set; }

    public int SubscriptionId { get; set; }
    public int PeriodeId { get; set; }

}
