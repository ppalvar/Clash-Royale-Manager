using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClashRoyaleManage.Infraestructure.Migrations.SqliteMigrations
{
    /// <inheritdoc />
    public partial class AddCodeToPlayerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Players",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Players");
        }
    }
}
