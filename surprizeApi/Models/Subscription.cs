using System;
using System.Collections.Generic;

namespace surprizeApi.Models;

public partial class Subscription
{
    public int? IdSubscription { get; set; }

    public string NameSubscription { get; set; } = null!;

    public decimal PriceSubscription { get; set; }

    

    public string DescriptionSubscription { get; set; } = null!;
    public string ImageProduct { get; set; } = null!;

}
