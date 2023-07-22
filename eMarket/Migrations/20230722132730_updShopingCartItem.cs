using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eMarket.Migrations
{
    /// <inheritdoc />
    public partial class updShopingCartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopingCartItems_Products_ProductId",
                table: "ShopingCartItems");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ShopingCartItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShopingCartItems_Products_ProductId",
                table: "ShopingCartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShopingCartItems_Products_ProductId",
                table: "ShopingCartItems");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "ShopingCartItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ShopingCartItems_Products_ProductId",
                table: "ShopingCartItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
