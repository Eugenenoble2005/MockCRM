using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MockCRM.Migrations
{
    /// <inheritdoc />
    public partial class CreateUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(name: "Users", columns: table => new
            {
                Id = table.Column<int>(nullable: false, type: "int"),
                UserName = table.Column<string>(nullable: false),
                Password = table.Column<string>(nullable: false),
            }, constraints: table =>
            {
                table.PrimaryKey("PK_Users", t => t.Id);
            }); 
            //i aint got a clue how Entity can't do this automatically
            migrationBuilder.Sql("ALTER TABLE Users MODIFY Id int NOT NULL AUTO_INCREMENT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Users");
        }
    }
}
