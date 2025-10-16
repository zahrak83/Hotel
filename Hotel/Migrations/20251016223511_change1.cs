using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hotel.Migrations
{
    /// <inheritdoc />
    public partial class change1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CheckOutData",
                table: "Reservations",
                newName: "CheckOutDate");

            migrationBuilder.RenameColumn(
                name: "CheckInData",
                table: "Reservations",
                newName: "CheckInDate");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_RoomId_CheckInData_CheckOutData",
                table: "Reservations",
                newName: "IX_Reservations_RoomId_CheckInDate_CheckOutDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CheckOutDate",
                table: "Reservations",
                newName: "CheckOutData");

            migrationBuilder.RenameColumn(
                name: "CheckInDate",
                table: "Reservations",
                newName: "CheckInData");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_RoomId_CheckInDate_CheckOutDate",
                table: "Reservations",
                newName: "IX_Reservations_RoomId_CheckInData_CheckOutData");
        }
    }
}
