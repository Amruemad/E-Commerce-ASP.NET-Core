using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Context.Migrations
{
    /// <inheritdoc />
    public partial class userIdOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_AspNetUsers_Id",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "orders",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_Id",
                table: "orders",
                newName: "IX_orders_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_AspNetUsers_AppUserId",
                table: "orders",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_AspNetUsers_AppUserId",
                table: "orders");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "orders",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_orders_AppUserId",
                table: "orders",
                newName: "IX_orders_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_AspNetUsers_Id",
                table: "orders",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
