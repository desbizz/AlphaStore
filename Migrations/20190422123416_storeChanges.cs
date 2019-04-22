using Microsoft.EntityFrameworkCore.Migrations;

namespace AlphaStore.Migrations
{
    public partial class storeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Stores",
                newName: "address1");

            migrationBuilder.RenameColumn(
                name: "Price_Sell",
                table: "Products",
                newName: "PriceSell");

            migrationBuilder.RenameColumn(
                name: "Price_Buy",
                table: "Products",
                newName: "PriceBuy");

            migrationBuilder.AddColumn<string>(
                name: "address",
                table: "Stores",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "address",
                table: "Stores");

            migrationBuilder.RenameColumn(
                name: "address1",
                table: "Stores",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "PriceSell",
                table: "Products",
                newName: "Price_Sell");

            migrationBuilder.RenameColumn(
                name: "PriceBuy",
                table: "Products",
                newName: "Price_Buy");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
