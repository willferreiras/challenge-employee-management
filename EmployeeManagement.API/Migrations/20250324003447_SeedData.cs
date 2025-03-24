using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO ""Users"" (""FirstName"", ""LastName"", ""Username"", ""Password"") 
                VALUES ('John', 'Doe', 'johndoe', '$2a$11$tORx/5bwwbFfpqg5xgPlo.7KbeIt/1u3zCEdnwPgAPhPRsNQhFT2u');
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Users WHERE Username = 'JohnDoe';");
        }
    }
}
