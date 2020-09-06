using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class create_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mobiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 70, nullable: false),
                    Manufacturer = table.Column<string>(maxLength: 100, nullable: false),
                    Size = table.Column<double>(nullable: false),
                    Weight = table.Column<double>(nullable: false),
                    ScreenSize = table.Column<double>(nullable: false),
                    Processor = table.Column<string>(maxLength: 70, nullable: false),
                    Memory = table.Column<int>(nullable: false),
                    OS = table.Column<string>(maxLength: 70, nullable: false),
                    Price = table.Column<double>(nullable: false),
                    VideoThumb = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MobilePictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MobileId = table.Column<int>(nullable: false),
                    Thumb = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobilePictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobilePictures_Mobiles_MobileId",
                        column: x => x.MobileId,
                        principalTable: "Mobiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MobilePictures_MobileId",
                table: "MobilePictures",
                column: "MobileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MobilePictures");

            migrationBuilder.DropTable(
                name: "Mobiles");
        }
    }
}
