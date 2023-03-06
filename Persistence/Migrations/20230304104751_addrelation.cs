using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "InvoicePay",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InvoiceId",
                table: "InvoiceDet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "tax17",
                table: "Invoice",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePay_InvoiceId",
                table: "InvoicePay",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDet_InvoiceId",
                table: "InvoiceDet",
                column: "InvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDet_Invoice_InvoiceId",
                table: "InvoiceDet",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicePay_Invoice_InvoiceId",
                table: "InvoicePay",
                column: "InvoiceId",
                principalTable: "Invoice",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDet_Invoice_InvoiceId",
                table: "InvoiceDet");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoicePay_Invoice_InvoiceId",
                table: "InvoicePay");

            migrationBuilder.DropIndex(
                name: "IX_InvoicePay_InvoiceId",
                table: "InvoicePay");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDet_InvoiceId",
                table: "InvoiceDet");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "InvoicePay");

            migrationBuilder.DropColumn(
                name: "InvoiceId",
                table: "InvoiceDet");

            migrationBuilder.AlterColumn<string>(
                name: "tax17",
                table: "Invoice",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }
    }
}
