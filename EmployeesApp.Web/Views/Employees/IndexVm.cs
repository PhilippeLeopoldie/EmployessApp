using System.ComponentModel.DataAnnotations;
using EmployeesApp.Web.Models;
namespace EmployeesApp.Web.Views.Employees;

public class IndexVM
{
    public class IndexVMItems
    {
        public required int Id { get; set; }
        public required string Name { get; set; }

        public required string Email { get; set; }

        public required bool ShowAsHighlighted { get; set; }
    }


    public required IndexVMItems[] ListOfIndexVmItems { get; set; }
}
