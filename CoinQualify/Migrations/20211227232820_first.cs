using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoinQualify.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_mail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_pw = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    User_deposit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    User_profit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    User_realize = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_id);
                });

            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    Coin_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coin_symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coin_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Coin_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Coin_mcap = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Coin_supply = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Coin_volume = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Coin_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Coin_rank = table.Column<int>(type: "int", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.Coin_id);
                    table.ForeignKey(
                        name: "FK_Coins_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Notify_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notify_name = table.Column<int>(type: "int", nullable: false),
                    Notify_dir = table.Column<bool>(type: "bit", nullable: false),
                    Notify_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: true),
                    Coin_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Notify_id);
                    table.ForeignKey(
                        name: "FK_Notifications_Coins_Coin_id",
                        column: x => x.Coin_id,
                        principalTable: "Coins",
                        principalColumn: "Coin_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Coins_User_id",
                table: "Coins",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_Coin_id",
                table: "Notifications",
                column: "Coin_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_User_id",
                table: "Notifications",
                column: "User_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "Coins");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
