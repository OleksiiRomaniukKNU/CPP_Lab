namespace MyApp.Web.ViewModels;

using System.ComponentModel.DataAnnotations;

public class UserLoginViewModel
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public required string Password { get; set; }
}