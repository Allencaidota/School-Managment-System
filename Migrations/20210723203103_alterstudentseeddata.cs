using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentManagmen.Migrations
{
    public partial class alterstudentseeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "ClassName", "Email", "Name" },
                values: new object[] { 2, 3, "Lichyuki@gmail.com", "JoJo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
