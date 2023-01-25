using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HostelManagementSystem.Data.Migrations
{
    /// <inheritdoc />
    public partial class init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReceiveFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiveFeeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StudentMonthlyFeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiveFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceiveFees_StudentMonthlyFee_StudentMonthlyFeeId",
                        column: x => x.StudentMonthlyFeeId,
                        principalTable: "StudentMonthlyFee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceiveFees_StudentMonthlyFeeId",
                table: "ReceiveFees",
                column: "StudentMonthlyFeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceiveFees");
        }
    }
}
