using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClashRoyaleManage.Infraestructure.Migrations.SqliteMigrations
{
    /// <inheritdoc />
    public partial class InitMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ElixirCost = table.Column<double>(type: "double precision", nullable: false),
                    Quality = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Challenges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Cost = table.Column<double>(type: "double precision", nullable: false),
                    NumberOfPrizes = table.Column<int>(type: "integer", nullable: false),
                    NumberOfAdmissibleDefeats = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<double>(type: "double precision", nullable: false),
                    MaximumLevel = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Challenges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nickname = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    NumberOfTrophies = table.Column<int>(type: "integer", nullable: false),
                    NumberOfWins = table.Column<int>(type: "integer", nullable: false),
                    MaximunTrophiesAchieved = table.Column<int>(type: "integer", nullable: false),
                    NumberOfCardsFound = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeClans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeClans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wars",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpellCards",
                columns: table => new
                {
                    CardId = table.Column<Guid>(type: "uuid", nullable: false),
                    Radio = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    DamageToTowers = table.Column<int>(type: "integer", nullable: false),
                    DamageInArea = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpellCards", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_SpellCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StructureCards",
                columns: table => new
                {
                    CardId = table.Column<Guid>(type: "uuid", nullable: false),
                    LifePoints = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StructureCards", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_StructureCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TroopCards",
                columns: table => new
                {
                    CardId = table.Column<Guid>(type: "uuid", nullable: false),
                    LifePoints = table.Column<int>(type: "integer", nullable: false),
                    DamageInArea = table.Column<int>(type: "integer", nullable: false),
                    NumberOfUnits = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TroopCards", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_TroopCards_Cards_CardId",
                        column: x => x.CardId,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Battles",
                columns: table => new
                {
                    Player1Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Player2Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Winner = table.Column<bool>(type: "boolean", nullable: false),
                    NumberOfTrophies = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Battles", x => new { x.Player1Id, x.Player2Id, x.Date });
                    table.ForeignKey(
                        name: "FK_Battles_Players_Player1Id",
                        column: x => x.Player1Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Battles_Players_Player2Id",
                        column: x => x.Player2Id,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerChallenges",
                columns: table => new
                {
                    IdPlayer = table.Column<Guid>(type: "uuid", nullable: false),
                    IdChallenge = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerChallenges", x => new { x.IdPlayer, x.IdChallenge });
                    table.ForeignKey(
                        name: "FK_PlayerChallenges_Challenges_IdChallenge",
                        column: x => x.IdChallenge,
                        principalTable: "Challenges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerChallenges_Players_IdPlayer",
                        column: x => x.IdPlayer,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    IdType = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    NumberOfTrophiesObtainedInWars = table.Column<int>(type: "integer", nullable: false),
                    Region = table.Column<string>(type: "text", nullable: false),
                    NumberOfMembers = table.Column<int>(type: "integer", nullable: false),
                    TrophiesNeededToEnter = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clans_TypeClans_IdType",
                        column: x => x.IdType,
                        principalTable: "TypeClans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClanWars",
                columns: table => new
                {
                    IdWar = table.Column<Guid>(type: "uuid", nullable: false),
                    IdClan = table.Column<Guid>(type: "uuid", nullable: false),
                    NumberOfPrizes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClanWars", x => new { x.IdClan, x.IdWar });
                    table.ForeignKey(
                        name: "FK_ClanWars_Clans_IdClan",
                        column: x => x.IdClan,
                        principalTable: "Clans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClanWars_Wars_IdWar",
                        column: x => x.IdWar,
                        principalTable: "Wars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerCards",
                columns: table => new
                {
                    IdPlayer = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCard = table.Column<Guid>(type: "uuid", nullable: false),
                    IdClan = table.Column<Guid>(type: "uuid", nullable: false),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    IsFavority = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerCards", x => new { x.IdPlayer, x.IdCard });
                    table.ForeignKey(
                        name: "FK_PlayerCards_Cards_IdCard",
                        column: x => x.IdCard,
                        principalTable: "Cards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerCards_Clans_IdClan",
                        column: x => x.IdClan,
                        principalTable: "Clans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerCards_Players_IdPlayer",
                        column: x => x.IdPlayer,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlayerClans",
                columns: table => new
                {
                    IdPlayer = table.Column<Guid>(type: "uuid", nullable: false),
                    IdClan = table.Column<Guid>(type: "uuid", nullable: false),
                    IdCargo = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerClans", x => new { x.IdPlayer, x.IdClan });
                    table.ForeignKey(
                        name: "FK_PlayerClans_Cargos_IdCargo",
                        column: x => x.IdCargo,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerClans_Clans_IdClan",
                        column: x => x.IdClan,
                        principalTable: "Clans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerClans_Players_IdPlayer",
                        column: x => x.IdPlayer,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Battles_Player2Id",
                table: "Battles",
                column: "Player2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Clans_IdType",
                table: "Clans",
                column: "IdType");

            migrationBuilder.CreateIndex(
                name: "IX_ClanWars_IdWar",
                table: "ClanWars",
                column: "IdWar");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCards_IdCard",
                table: "PlayerCards",
                column: "IdCard");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerCards_IdClan",
                table: "PlayerCards",
                column: "IdClan");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerChallenges_IdChallenge",
                table: "PlayerChallenges",
                column: "IdChallenge");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerClans_IdCargo",
                table: "PlayerClans",
                column: "IdCargo");

            migrationBuilder.CreateIndex(
                name: "IX_PlayerClans_IdClan",
                table: "PlayerClans",
                column: "IdClan");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Battles");

            migrationBuilder.DropTable(
                name: "ClanWars");

            migrationBuilder.DropTable(
                name: "PlayerCards");

            migrationBuilder.DropTable(
                name: "PlayerChallenges");

            migrationBuilder.DropTable(
                name: "PlayerClans");

            migrationBuilder.DropTable(
                name: "SpellCards");

            migrationBuilder.DropTable(
                name: "StructureCards");

            migrationBuilder.DropTable(
                name: "TroopCards");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Wars");

            migrationBuilder.DropTable(
                name: "Challenges");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Clans");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "TypeClans");
        }
    }
}
