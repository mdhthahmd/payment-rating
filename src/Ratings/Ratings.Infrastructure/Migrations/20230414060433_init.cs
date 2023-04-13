using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ratings.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "rating");

            migrationBuilder.CreateSequence(
                name: "employerseq",
                schema: "rating",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "paymentseq",
                schema: "rating",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "ranking",
                schema: "rating",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ranking", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "employers",
                schema: "rating",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    points = table.Column<int>(type: "int", nullable: false),
                    ranking_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employers", x => x.id);
                    table.ForeignKey(
                        name: "FK_employers_ranking_ranking_id",
                        column: x => x.ranking_id,
                        principalSchema: "rating",
                        principalTable: "ranking",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                schema: "rating",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    employer_id = table.Column<int>(type: "int", nullable: false),
                    contribution_month = table.Column<DateTime>(type: "datetime2", nullable: false),
                    due_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    paid_amount = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.id);
                    table.ForeignKey(
                        name: "FK_payments_employers_employer_id",
                        column: x => x.employer_id,
                        principalSchema: "rating",
                        principalTable: "employers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employers_ranking_id",
                schema: "rating",
                table: "employers",
                column: "ranking_id");

            migrationBuilder.CreateIndex(
                name: "IX_payments_employer_id",
                schema: "rating",
                table: "payments",
                column: "employer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "payments",
                schema: "rating");

            migrationBuilder.DropTable(
                name: "employers",
                schema: "rating");

            migrationBuilder.DropTable(
                name: "ranking",
                schema: "rating");

            migrationBuilder.DropSequence(
                name: "employerseq",
                schema: "rating");

            migrationBuilder.DropSequence(
                name: "paymentseq",
                schema: "rating");
        }
    }
}
