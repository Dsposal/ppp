using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlasticPackagingPortal.Web.Migrations
{
    /// <inheritdoc />
    public partial class Itemtypos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscontinuedDate",
                table: "StagingItems",
                newName: "DiscontinueDate");

            migrationBuilder.RenameColumn(
                name: "Colours",
                table: "StagingItems",
                newName: "Colour");

            migrationBuilder.RenameColumn(
                name: "DiscontinuedDate",
                table: "Items",
                newName: "DiscontinueDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscontinueDate",
                table: "StagingItems",
                newName: "DiscontinuedDate");

            migrationBuilder.RenameColumn(
                name: "Colour",
                table: "StagingItems",
                newName: "Colours");

            migrationBuilder.RenameColumn(
                name: "DiscontinueDate",
                table: "Items",
                newName: "DiscontinuedDate");
        }
    }
}
