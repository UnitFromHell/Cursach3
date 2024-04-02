using System;
using System.Collections.Generic;

namespace surprizeApi.Models;

public partial class Ordering
{
    public int? IdOrder { get; set; }

    public string OrderNumber { get; set; } = null!;

    public decimal SumOrder { get; set; }

    public DateOnly DateOrder { get; set; }

    public int UserSiteId { get; set; }

  
    
}
