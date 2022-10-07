using Microsoft.EntityFrameworkCore.Migrations;

namespace CoinQualify.Migrations
{
    public partial class first4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Coin_price",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "Coin_rank",
                table: "Coins");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Coin_price",
                table: "Coins",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Coin_rank",
                table: "Coins",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
