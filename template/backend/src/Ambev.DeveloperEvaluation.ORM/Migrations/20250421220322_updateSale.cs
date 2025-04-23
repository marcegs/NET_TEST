using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class updateSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountApplied",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "Total",
                table: "Sales",
                newName: "Price");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Sales",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<decimal>(
                name: "DiscountPercentage",
                table: "Sales",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPercentage",
                table: "Sales");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Sales",
                newName: "Total");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Sales",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<bool>(
                name: "DiscountApplied",
                table: "Sales",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
