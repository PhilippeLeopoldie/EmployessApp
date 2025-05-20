using System.ComponentModel.DataAnnotations;

namespace EmployeesApp.Web.Views.Employees;

public class CreateVM
{
    [Required(ErrorMessage = "You must specify a name")]
    public required string Name { get; set; }

    [Display(Name = "E-mail")]
    [EmailAddress(ErrorMessage = "Invalid e-mail address")]
    [Required(ErrorMessage = "You must specify an e-mail address")]
    public required string Email { get; set; }

    [Range(4, 4, ErrorMessage = "Value must be the correct value")]
    [Display(Name = "What's 2+2")]
    [Required(ErrorMessage = "You must answer")]
    public required int BotCheck { get; set; }
}
