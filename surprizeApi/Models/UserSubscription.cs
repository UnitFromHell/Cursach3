using System;
using System.Collections.Generic;

namespace surprizeApi.Models;

public partial class UserSubscription
{
    public int? IdUserSubscription { get; set; }

    public bool IsFavourite { get; set; }

    public int UserSiteId { get; set; }

    public int SubscriptionId { get; set; }

}
