using Microsoft.EntityFrameworkCore.Migrations;

namespace CorePostgre.Data.Migrations
{
    public partial class addedroletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "OnrTable",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OnrTable_RoleId",
                table: "OnrTable",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_OnrTable_Role_RoleId",
                table: "OnrTable",
                column: "RoleId",
                principalTable: "Role",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OnrTable_Role_RoleId",
                table: "OnrTable");

            migrationBuilder.DropIndex(
                name: "IX_OnrTable_RoleId",
                table: "OnrTable");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "OnrTable");
        }
    }
}
