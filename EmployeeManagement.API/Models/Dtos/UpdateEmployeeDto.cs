namespace EmployeeManagement.API.Models.Dtos
{
    public class UpdateEmployeeDto
    {
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string docNumber { get; set; } = string.Empty;

        public bool isActive { get; set; } = true;
    }
}
