using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MusicServerApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tracks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Tracks",
                columns: new[] { "Id", "ArtistId", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 3, 1, new TimeSpan(0, 0, 8, 0, 0), "Thrash Metal", new DateTime(1986, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Master of Puppets" },
                    { 4, 2, new TimeSpan(0, 0, 3, 0, 0), "Rap Rock", new DateTime(2003, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Numb" }
                });
        }
    }
}
