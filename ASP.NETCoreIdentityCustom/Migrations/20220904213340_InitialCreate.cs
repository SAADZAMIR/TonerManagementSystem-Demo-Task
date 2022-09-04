using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASP.NETCoreIdentityCustom.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "PaperUseage",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaperUseage_UserId",
                table: "PaperUseage",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaperUseage_AspNetUsers_UserId",
                table: "PaperUseage",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaperUseage_AspNetUsers_UserId",
                table: "PaperUseage");

            migrationBuilder.DropIndex(
                name: "IX_PaperUseage_UserId",
                table: "PaperUseage");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PaperUseage");
        }
    }
}
