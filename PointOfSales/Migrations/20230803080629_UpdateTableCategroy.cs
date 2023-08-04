using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PointOfSales.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableCategroy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "updateddate",
                table: "Category",
                newName: "UpdatedDate");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Category",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "createddate",
                table: "Category",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Category",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Category",
                newName: "updateddate");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Category",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Category",
                newName: "createddate");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Category",
                newName: "id");
        }
    }
}
