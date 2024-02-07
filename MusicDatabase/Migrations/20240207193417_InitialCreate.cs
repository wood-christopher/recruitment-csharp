using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicDatabase.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "ArtistSequence");

            migrationBuilder.CreateTable(
                name: "artist",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, defaultValueSql: "NEXT VALUE FOR ArtistSequence"),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateOnly>(type: "date", nullable: false, defaultValue: DateOnly.FromDateTime(DateTime.Today)),
                    LastModified = table.Column<DateOnly>(type: "date", nullable: false, defaultValue: DateOnly.FromDateTime(DateTime.Today))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artist_name",
                table: "artist",
                column: "name",
                unique: true);

            migrationBuilder.Sql(File.ReadAllText("data.sql"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropTable(
                name: "artist");

            migrationBuilder.DropSequence(
                name: "ArtistSequence");
        }
    }
}
