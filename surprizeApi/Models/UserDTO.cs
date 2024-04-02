using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace surprizeApi.Models
{
    public class UserDTO 
    {

       [Required]
       public string LoginUser { get; set; } = string.Empty;
       [Required]
       [DataType(DataType.Password)]
       public string PasswordUser { get; set; } = string.Empty;
      

    }
}
