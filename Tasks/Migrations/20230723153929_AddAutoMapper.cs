using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tasks.Migrations
{
    /// <inheritdoc />
    public partial class AddAutoMapper : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    City_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    S_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.City_Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Std_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Std_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Std_Class = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Std_School = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Std_Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Std_Mobile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Std_Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    C_Id = table.Column<int>(type: "int", nullable: false),
                    S_Id = table.Column<int>(type: "int", nullable: false),
                    City_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Std_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
