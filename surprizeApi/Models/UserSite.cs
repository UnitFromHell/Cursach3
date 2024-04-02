using System;
using System.Collections.Generic;

namespace surprizeApi.Models;

public partial class UserSite
{
    public int IdUser { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LoginUser { get; set; } = null!;

    public string PasswordUser { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public int RoleId { get; set; }

  
}
