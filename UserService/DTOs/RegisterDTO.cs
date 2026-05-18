using System.ComponentModel.DataAnnotations;
namespace UserService.DTOs;

public class RegisterDTO
{
    [Required]
    public required string Username { get; set; }

    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }
    [Required]
    public required string ConfirmPassword { get; set; }


}