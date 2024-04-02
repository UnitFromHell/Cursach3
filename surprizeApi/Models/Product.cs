using System;
using System;
using System.Collections.Generic;

namespace surprizeApi.Models;

public partial class Product
{
    public int? IdProduct { get; set; }

    public string NameProduct { get; set; } = null!;

    public string DescriptionProduct { get; set; } = null!;

    public decimal Price { get; set; }

  

}
