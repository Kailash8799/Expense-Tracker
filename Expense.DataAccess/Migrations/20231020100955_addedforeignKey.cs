using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Expense.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedforeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoryset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoryset", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactionset",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactionset", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactionset_Categoryset_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categoryset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactionset_Userset_UserId",
                        column: x => x.UserId,
                        principalTable: "Userset",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactionset_CategoryId",
                table: "Transactionset",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactionset_UserId",
                table: "Transactionset",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactionset");

            migrationBuilder.DropTable(
                name: "Categoryset");
        }
    }
}
