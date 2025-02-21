using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable
namespace Database.Migrations
{
    public partial class AddUserIdToConsultorios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Add the UserId column as nullable first
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Consultorios",
                type: "int",
                nullable: true);

            // Create index for better query performance
            migrationBuilder.CreateIndex(
                name: "IX_Consultorios_UserId",
                table: "Consultorios",
                column: "UserId");

            // Update existing records with a more robust strategy
            migrationBuilder.Sql(
                @"
                DECLARE @DefaultUserId int;
                SELECT TOP 1 @DefaultUserId = Id FROM Users ORDER BY Id;
                
                IF @DefaultUserId IS NOT NULL
                BEGIN
                    UPDATE c
                    SET c.UserId = @DefaultUserId
                    FROM Consultorios c
                    WHERE c.UserId IS NULL;
                END
                ELSE
                BEGIN
                    RAISERROR ('No users exist in the Users table to set as default owner.', 16, 1);
                END
                ");

            // Make UserId non-nullable after data is updated
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Consultorios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            // Add the foreign key constraint last
            migrationBuilder.AddForeignKey(
                name: "FK_Consultorios_Users_UserId",
                table: "Consultorios",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove the foreign key constraint first
            migrationBuilder.DropForeignKey(
                name: "FK_Consultorios_Users_UserId",
                table: "Consultorios");

            // Remove the index
            migrationBuilder.DropIndex(
                name: "IX_Consultorios_UserId",
                table: "Consultorios");

            // Make the column nullable before dropping it
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Consultorios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: false);

            // Finally drop the column
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Consultorios");
        }
    }
}