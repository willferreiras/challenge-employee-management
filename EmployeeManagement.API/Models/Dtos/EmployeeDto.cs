namespace EmployeeManagement.API.Models.Dtos
{
    public class EmployeeDto
    {
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string docNumber { get; set; } = string.Empty;
        public string managerName { get; set; } = string.Empty;
        public string? password { get; set; } = string.Empty;
    }
}
