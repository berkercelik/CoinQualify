using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoinQualify.Migrations
{
    public partial class first3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropColumn(
                name: "User_deposit",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "User_profit",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "User_realize",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Coin_mcap",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "Coin_supply",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "Coin_time",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "Coin_volume",
                table: "Coins");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "User_deposit",
                table: "Users",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "User_profit",
                table: "Users",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "User_realize",
                table: "Users",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Coin_mcap",
                table: "Coins",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Coin_supply",
                table: "Coins",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "Coin_time",
                table: "Coins",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "Coin_volume",
                table: "Coins",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Notify_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Coin_id = table.Column<int>(type: "int", nullable: true),
                    Notify_dir = table.Column<bool>(type: "bit", nullable: false),
                    Notify_name = table.Column<int>(type: "int", nullable: false),
                    Notify_price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    User_id = table.Column<int>(type: "int", nullable: true)
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
                name: "IX_Notifications_Coin_id",
                table: "Notifications",
                column: "Coin_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_User_id",
                table: "Notifications",
                column: "User_id");
        }
    }
}
