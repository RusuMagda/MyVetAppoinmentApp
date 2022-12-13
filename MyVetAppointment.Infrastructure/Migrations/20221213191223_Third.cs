using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVetAppointment.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Iamge",
                table: "Cabinets",
                newName: "Image");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Cabinets",
                newName: "Iamge");
        }
    }
}
