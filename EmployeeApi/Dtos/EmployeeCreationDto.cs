using System;
namespace EmployeeApi.Dtos
{
    public class EmployeeCreationDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Sex { get; set; }
        public int CompanyId { get; set; }
    }
}
