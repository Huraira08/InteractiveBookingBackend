using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace InteractiveBookingBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBookingsTableWithSeeders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "EndDate", "Price", "StartDate", "UserID" },
                values: new object[,]
                {
                    { new Guid("2dcc976c-4cdb-4f9b-afa9-c90607ddd114"), new DateTime(2024, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000, new DateTime(2024, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("ffa51ac1-dff4-4827-a3d8-2693e10b7392") },
                    { new Guid("58056c04-2e55-41c7-85e9-d62da7c67698"), new DateTime(2024, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000, new DateTime(2024, 5, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("4360ec35-ef9f-4d3c-863c-b062d5fa0dba") },
                    { new Guid("694ac33a-9727-497a-a578-23a48aa9b118"), new DateTime(2024, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1000, new DateTime(2024, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("029c1d53-21ae-4169-9e69-d0f19751a89f") },
                    { new Guid("d64e4ae4-2b44-4de0-b654-312193ff2a02"), new DateTime(2024, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000, new DateTime(2024, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("8f4a212c-8cf1-4806-9937-6c41bb8ae2ae") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");
        }
    }
}
