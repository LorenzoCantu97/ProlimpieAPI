using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProlimpieAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeAgreganTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historial_Modulos_ModuloId",
                table: "Historial");

            migrationBuilder.RenameColumn(
                name: "ModuloId",
                table: "Historial",
                newName: "PaginasId");

            migrationBuilder.RenameIndex(
                name: "IX_Historial_ModuloId",
                table: "Historial",
                newName: "IX_Historial_PaginasId");

            migrationBuilder.AlterColumn<int>(
                name: "ModulosId",
                table: "Historial",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Paginas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModulosId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedById = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedById = table.Column<int>(type: "int", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paginas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paginas_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Paginas_AspNetUsers_UpdatedById",
                        column: x => x.UpdatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Paginas_Modulos_ModulosId",
                        column: x => x.ModulosId,
                        principalTable: "Modulos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Historial_ModulosId",
                table: "Historial",
                column: "ModulosId");

            migrationBuilder.CreateIndex(
                name: "IX_Paginas_CreatedById",
                table: "Paginas",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Paginas_ModulosId",
                table: "Paginas",
                column: "ModulosId");

            migrationBuilder.CreateIndex(
                name: "IX_Paginas_UpdatedById",
                table: "Paginas",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Historial_Modulos_ModulosId",
                table: "Historial",
                column: "ModulosId",
                principalTable: "Modulos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Historial_Paginas_PaginasId",
                table: "Historial",
                column: "PaginasId",
                principalTable: "Paginas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Historial_Modulos_ModulosId",
                table: "Historial");

            migrationBuilder.DropForeignKey(
                name: "FK_Historial_Paginas_PaginasId",
                table: "Historial");

            migrationBuilder.DropTable(
                name: "Paginas");

            migrationBuilder.DropIndex(
                name: "IX_Historial_ModulosId",
                table: "Historial");

            migrationBuilder.RenameColumn(
                name: "PaginasId",
                table: "Historial",
                newName: "ModuloId");

            migrationBuilder.RenameIndex(
                name: "IX_Historial_PaginasId",
                table: "Historial",
                newName: "IX_Historial_ModuloId");

            migrationBuilder.AlterColumn<string>(
                name: "ModulosId",
                table: "Historial",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Historial_Modulos_ModuloId",
                table: "Historial",
                column: "ModuloId",
                principalTable: "Modulos",
                principalColumn: "Id");
        }
    }
}
