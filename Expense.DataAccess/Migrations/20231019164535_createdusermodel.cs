using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expense.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class createdusermodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Userset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Userset", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Userset",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 1, "kailashrajput8799@gmail.com", "Kailash", "1234567890" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Userset");
        }
    }
}
