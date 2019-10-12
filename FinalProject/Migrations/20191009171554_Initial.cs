using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TuckShop_Membership_MembershipID",
                table: "TuckShop");

            migrationBuilder.DropColumn(
                name: "TrainerID",
                table: "Trainer");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "PlanID",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "TrainerName",
                table: "Plan");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Membership");

            migrationBuilder.DropColumn(
                name: "MembershipID",
                table: "Membership");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Plan",
                newName: "Duration");

            migrationBuilder.RenameColumn(
                name: "Expiry",
                table: "Membership",
                newName: "MemberFrom");

            migrationBuilder.AlterColumn<int>(
                name: "MembershipID",
                table: "TuckShop",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Membership",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Membership",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TuckShop_Membership_MembershipID",
                table: "TuckShop",
                column: "MembershipID",
                principalTable: "Membership",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TuckShop_Membership_MembershipID",
                table: "TuckShop");

            migrationBuilder.RenameColumn(
                name: "Duration",
                table: "Plan",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "MemberFrom",
                table: "Membership",
                newName: "Expiry");

            migrationBuilder.AlterColumn<int>(
                name: "MembershipID",
                table: "TuckShop",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "TrainerID",
                table: "Trainer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EndTime",
                table: "Plan",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PlanID",
                table: "Plan",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "TrainerName",
                table: "Plan",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Membership",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Membership",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Membership",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MembershipID",
                table: "Membership",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_TuckShop_Membership_MembershipID",
                table: "TuckShop",
                column: "MembershipID",
                principalTable: "Membership",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
