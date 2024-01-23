using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RevertInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_WorkPlaces_CompanyName",
                table: "WorkPlaces");

            migrationBuilder.DropIndex(
                name: "IX_WorkPlaces_Title",
                table: "WorkPlaces");

            migrationBuilder.DropIndex(
                name: "IX_Educations_EducationName",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Educations_InstitutionName",
                table: "Educations");

            migrationBuilder.DropIndex(
                name: "IX_Address_City",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_PostalCode",
                table: "Address");

            migrationBuilder.DropIndex(
                name: "IX_Address_StreetName",
                table: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_WorkPlaces_CompanyName",
                table: "WorkPlaces",
                column: "CompanyName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkPlaces_Title",
                table: "WorkPlaces",
                column: "Title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Educations_EducationName",
                table: "Educations",
                column: "EducationName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Educations_InstitutionName",
                table: "Educations",
                column: "InstitutionName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_City",
                table: "Address",
                column: "City",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_PostalCode",
                table: "Address",
                column: "PostalCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Address_StreetName",
                table: "Address",
                column: "StreetName",
                unique: true);
        }
    }
}
