using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClashRoyaleManage.Infraestructure.Migrations.SqliteMigrations
{
    /// <inheritdoc />
    public partial class PlayerCardMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Battles",
                table: "Battles");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "PlayerCards",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            // migrationBuilder.AlterColumn<int>(
            //     name: "Region",
            //     table: "Clans",
            //     type: "integer",
            //     nullable: false,
            //     defaultValue: 0,
            //     oldClrType: typeof(string),
            //     oldType: "text");

            migrationBuilder.Sql(
                @"
                ALTER TABLE ""Clans"" 
                ALTER COLUMN ""Region"" TYPE integer 
                USING (""Region""::text::integer);
                "
            );

            migrationBuilder.AddPrimaryKey(
                name: "PK_Battles",
                table: "Battles",
                columns: new[] { "Player1Id", "Date" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Battles",
                table: "Battles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "PlayerCards");

            // migrationBuilder.AlterColumn<string>(
            //     name: "Region",
            //     table: "Clans",
            //     type: "text",
            //     nullable: false,
            //     defaultValue: "",
            //     oldClrType: typeof(int),
            //     oldType: "integer");

            migrationBuilder.Sql(
                @"
                ALTER TABLE ""Clans"" 
                ALTER COLUMN ""Region"" TYPE text 
                USING (""Region""::integer::text);
                "
            );

            migrationBuilder.AddPrimaryKey(
                name: "PK_Battles",
                table: "Battles",
                columns: new[] { "Player1Id", "Player2Id", "Date" });
        }
    }
}
