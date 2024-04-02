using System;
using System.Collections.Generic;

namespace surprizeApi.Models;

public partial class SubscriptionInOrder
{
    public int? IdSubscriptionInOrder { get; set; }

    public int SubscriptionId { get; set; }

    public int OrderId { get; set; }


}
