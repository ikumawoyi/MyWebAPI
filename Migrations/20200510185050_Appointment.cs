using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyWebAPI.Migrations
{
    public partial class Appointment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoasterId",
                table: "Nurses",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "Doctors",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Doctors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsAssigned",
                table: "Doctors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnDuty",
                table: "Doctors",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "RoasterId",
                table: "Doctors",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roasters", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Nurses_RoasterId",
                table: "Nurses",
                column: "RoasterId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_AppointmentId",
                table: "Doctors",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_RoasterId",
                table: "Doctors",
                column: "RoasterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Appointments_AppointmentId",
                table: "Doctors",
                column: "AppointmentId",
                principalTable: "Appointments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Roasters_RoasterId",
                table: "Doctors",
                column: "RoasterId",
                principalTable: "Roasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Nurses_Roasters_RoasterId",
                table: "Nurses",
                column: "RoasterId",
                principalTable: "Roasters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Appointments_AppointmentId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Roasters_RoasterId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Nurses_Roasters_RoasterId",
                table: "Nurses");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Roasters");

            migrationBuilder.DropIndex(
                name: "IX_Nurses_RoasterId",
                table: "Nurses");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_AppointmentId",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_RoasterId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "RoasterId",
                table: "Nurses");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "IsAssigned",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "IsOnDuty",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "RoasterId",
                table: "Doctors");
        }
    }
}
