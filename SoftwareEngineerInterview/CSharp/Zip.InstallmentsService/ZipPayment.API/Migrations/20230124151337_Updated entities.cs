using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ZipPayment.API.Migrations
{
    public partial class Updatedentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PaymentPlans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    PurchaseAmount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InstallmentEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DueDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    PaymentPlanEntityId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstallmentEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstallmentEntity_PaymentPlans_PaymentPlanEntityId",
                        column: x => x.PaymentPlanEntityId,
                        principalTable: "PaymentPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstallmentEntity_PaymentPlanEntityId",
                table: "InstallmentEntity",
                column: "PaymentPlanEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstallmentEntity");

            migrationBuilder.DropTable(
                name: "PaymentPlans");
        }
    }
}
