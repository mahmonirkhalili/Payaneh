using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    InvoiceNo = table.Column<int>(type: "int", nullable: false),
                    inty = table.Column<int>(type: "int", nullable: false),
                    inp = table.Column<int>(type: "int", nullable: false),
                    ins = table.Column<int>(type: "int", nullable: false),
                    top = table.Column<int>(type: "int", nullable: false),
                    bid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    bpc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sbc = table.Column<int>(type: "int", nullable: false),
                    bbc = table.Column<int>(type: "int", nullable: false),
                    tax17 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "InvoiceDet",
                columns: table => new
                {
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sstid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sstt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    am = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    exr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dis = table.Column<double>(type: "float", nullable: false),
                    vra = table.Column<double>(type: "float", nullable: false),
                    vam = table.Column<double>(type: "float", nullable: false),
                    odt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    odr = table.Column<double>(type: "float", nullable: false),
                    odam = table.Column<double>(type: "float", nullable: false),
                    olt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    olr = table.Column<double>(type: "float", nullable: false),
                    olam = table.Column<double>(type: "float", nullable: false),
                    bsrn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoorsNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BoorsDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "InvoicePay",
                columns: table => new
                {
                    InvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pmt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pdt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pv = table.Column<double>(type: "float", nullable: false),
                    iinn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    acn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trmn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    trn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pcn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    pid = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "InvoiceDet");

            migrationBuilder.DropTable(
                name: "InvoicePay");
        }
    }
}
