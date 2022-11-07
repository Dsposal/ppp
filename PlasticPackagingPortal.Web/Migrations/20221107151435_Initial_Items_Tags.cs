using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlasticPackagingPortal.Web.Migrations
{
    public partial class Initial_Items_Tags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Identifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LowCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<double>(type: "float", nullable: true),
                    HeightDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Width = table.Column<double>(type: "float", nullable: true),
                    WidthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Depth = table.Column<double>(type: "float", nullable: true),
                    DepthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Volume = table.Column<double>(type: "float", nullable: true),
                    VolumeDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    WeightDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WeightTolerance = table.Column<double>(type: "float", nullable: true),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shape = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flexibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentRecyclingDisruptors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReuseSystem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturedCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecycledContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecycledContentEvidenceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecycledContentEvidenceReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recyclability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecyclabilitySource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecyclabilityDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PartOfMultipack = table.Column<bool>(type: "bit", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DiscontinuedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SystemCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SystemUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StagingItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Identifier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LowCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Height = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeightDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Width = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WidthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Depth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Volume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VolumeDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeightDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeightTolerance = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Function = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shape = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Flexibility = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComponentRecyclingDisruptors = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Colours = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opacity = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReuseSystem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturedCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecycledContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecycledContentEvidenceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecycledContentEvidenceReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Recyclability = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecyclabilitySource = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RecyclabilityDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PartOfMultipack = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscontinuedDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SystemUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StagingItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SystemUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StagingTags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemCreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SystemUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StagingTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StagingTags_StagingItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "StagingItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StagingTags_ItemId",
                table: "StagingTags",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ItemId",
                table: "Tags",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StagingTags");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "StagingItems");

            migrationBuilder.DropTable(
                name: "Items");
        }
    }
}
