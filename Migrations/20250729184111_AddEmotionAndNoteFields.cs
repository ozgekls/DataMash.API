using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataMash.API.Migrations
{
    /// <inheritdoc />
    public partial class AddEmotionAndNoteFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StressLevel",
                table: "StressRecords",
                newName: "Stress");

            migrationBuilder.AlterColumn<string>(
                name: "Emotion",
                table: "StressRecords",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "StressRecords",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "StressRecords");

            migrationBuilder.RenameColumn(
                name: "Stress",
                table: "StressRecords",
                newName: "StressLevel");

            migrationBuilder.UpdateData(
                table: "StressRecords",
                keyColumn: "Emotion",
                keyValue: null,
                column: "Emotion",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Emotion",
                table: "StressRecords",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
