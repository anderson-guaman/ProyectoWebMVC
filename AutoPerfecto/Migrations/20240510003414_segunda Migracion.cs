using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoPerfecto.Migrations
{
    /// <inheritdoc />
    public partial class segundaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Auto_AutoId",
                table: "Compra");

            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Cliente_ClienteId",
                table: "Compra");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Compra",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AutoId",
                table: "Compra",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Auto_AutoId",
                table: "Compra",
                column: "AutoId",
                principalTable: "Auto",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Cliente_ClienteId",
                table: "Compra",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Auto_AutoId",
                table: "Compra");

            migrationBuilder.DropForeignKey(
                name: "FK_Compra_Cliente_ClienteId",
                table: "Compra");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "Compra",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AutoId",
                table: "Compra",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Auto_AutoId",
                table: "Compra",
                column: "AutoId",
                principalTable: "Auto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Compra_Cliente_ClienteId",
                table: "Compra",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
