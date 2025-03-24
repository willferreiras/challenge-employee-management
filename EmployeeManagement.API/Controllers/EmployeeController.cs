using Microsoft.AspNetCore.Mvc;
using EmployeeManagement.API.Data;
using EmployeeManagement.API.Models;
using EmployeeManagement.API.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using BCrypt.Net;
using System.Linq;
using System.Text;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees([FromQuery] string? search, [FromQuery] int page = 1)
        {
            const int pageSize = 100;
            
            if (page < 1) page = 1;

            IQueryable<Employee> query = _context.Employees;

            if (!string.IsNullOrWhiteSpace(search)) {
                search = RemoveAccents(search.ToLower());
                query = query.Where(e =>
                    EF.Functions.ILike(RemoveAccents(e.FirstName).ToLower(), $"%{search}%") ||
                    EF.Functions.ILike(RemoveAccents(e.LastName).ToLower(), $"%{search}%") ||
                    EF.Functions.ILike(RemoveAccents(e.Email).ToLower(), $"%{search}%") ||
                    EF.Functions.ILike(RemoveAccents(e.DocNumber).ToLower(), $"%{search}%")
                );
            }

            int totalCount = await query.CountAsync();

            var employees = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(new
            {
                employees,
                pages = (int)Math.Ceiling((double)totalCount / pageSize),
                count = totalCount
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound("Funcionário não encontrado.");
            }
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeDto employeeDto)
        {
            if (string.IsNullOrWhiteSpace(employeeDto.password)) {
                return BadRequest("A senha não pode estar vazia.");
            }

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(employeeDto.password);

            var employee = new Employee
            {
                FirstName = employeeDto.firstName,
                LastName = employeeDto.lastName,
                Email = employeeDto.email,
                DocNumber = employeeDto.docNumber,
                ManagerName = employeeDto.managerName,
                Password = hashedPassword,
                IsActive = true,
            };

            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.Id }, employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] UpdateEmployeeDto updateEmployeeDto)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound("Funcionário não encontrado.");
            }

            employee.FirstName = updateEmployeeDto.firstName ?? employee.FirstName;
            employee.LastName = updateEmployeeDto.lastName ?? employee.LastName;
            employee.Email = updateEmployeeDto.email ?? employee.Email;
            employee.DocNumber = updateEmployeeDto.docNumber ?? employee.DocNumber;
            employee.IsActive = updateEmployeeDto.isActive;

            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        private static string RemoveAccents(string text)
        {
            return string.Concat(text.Normalize(NormalizationForm.FormD)
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark))
                .Normalize(NormalizationForm.FormC);
        }
    }
}
