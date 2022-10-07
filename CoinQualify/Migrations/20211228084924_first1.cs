using Microsoft.EntityFrameworkCore.Migrations;

namespace CoinQualify.Migrations
{
    public partial class first1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Usercoin_amount",
                table: "Coins",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Usercoin_buyprice",
                table: "Coins",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Usercoin_id",
                table: "Coins",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Usercoin_profit",
                table: "Coins",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Usercoin_sellprice",
                table: "Coins",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Usercoin_amount",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "Usercoin_buyprice",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "Usercoin_id",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "Usercoin_profit",
                table: "Coins");

            migrationBuilder.DropColumn(
                name: "Usercoin_sellprice",
                table: "Coins");
        }
    }
}
