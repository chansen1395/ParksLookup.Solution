using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParkLookup.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    ParkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    User = table.Column<string>(type: "varchar(20) CHARACTER SET utf8mb4", maxLength: 20, nullable: false),
                    State = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    City = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    ParkName = table.Column<string>(type: "varchar(50) CHARACTER SET utf8mb4", maxLength: 50, nullable: false),
                    Activities = table.Column<string>(type: "varchar(500) CHARACTER SET utf8mb4", maxLength: 500, nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.ParkId);
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Activities", "City", "ParkName", "Rating", "State", "User" },
                values: new object[,]
                {
                    { 1, "Camping, Hiking, Fishing, Biking, Museum", "St. Paul", "Champoeg", 4, "Oregon", "Bob" },
                    { 2, "Camping, Hiking, Rafting, Biking, Wildlife", "Bozeman", "Yellowstone", 5, "Montana", "Jerry" },
                    { 3, "Camping, Hiking, Waterfall, Museum, Food", "Troutdale", "Multnomah Falls", 5, "Oregon", "Elizabeth" },
                    { 4, "Camping, Mining, Hunting", "Plush", "Oregon Sunstone Mine", 4, "Oregon", "Elizabeth" },
                    { 5, "Camping, Museum", "Astoria", "Fort Clatsop", 3, "Oregon", "Joe" },
                    { 6, "Camping, Hiking, Waterfall, River", "Estes Park", "Rocky Mountain National Park", 3, "Colorado", "Joe" },
                    { 7, "Camping, Hiking, Waterfall, River, Fishing, Hunting", "Tillamook", "Tillamook State Forest", 3, "Oregon", "Henrietta" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parks");
        }
    }
}
