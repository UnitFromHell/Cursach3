using System;
using System.Collections.Generic;

namespace surprizeApi.Models;

public partial class ProductInSubscription
{
    public int? IdProductInSubscription { get; set; }

    public int ProductId { get; set; }

    public int SubscriptionId { get; set; }

    }
