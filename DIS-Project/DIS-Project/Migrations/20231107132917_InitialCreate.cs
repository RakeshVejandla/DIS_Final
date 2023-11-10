using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DIS_Project.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Subject = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Message = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RoadCharacter",
                columns: table => new
                {
                    RoadCharacterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadCharacter", x => x.RoadCharacterId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RoadCondition",
                columns: table => new
                {
                    RoadConditionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadCondition", x => x.RoadConditionId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "RoadConfiguration",
                columns: table => new
                {
                    RoadConfigurationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoadConfiguration", x => x.RoadConfigurationId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "VehicleType",
                columns: table => new
                {
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleType", x => x.VehicleTypeId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WeatherCondition",
                columns: table => new
                {
                    WeatherConditionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherCondition", x => x.WeatherConditionId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CrashRecord",
                columns: table => new
                {
                    CrashRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CrashDateTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    CrashYear = table.Column<int>(type: "int", nullable: true),
                    CrashLocation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoadCharacterId = table.Column<int>(type: "int", nullable: true),
                    RoadConfigurationId = table.Column<int>(type: "int", nullable: true),
                    RoadConditionId = table.Column<int>(type: "int", nullable: true),
                    WeatherConditionId = table.Column<int>(type: "int", nullable: true),
                    Injuries = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdditionalInformation = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VehicleTypeId = table.Column<int>(type: "int", nullable: true),
                    TamainId = table.Column<int>(type: "int", nullable: true),
                    CreatedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CrashRecord", x => x.CrashRecordId);
                    table.ForeignKey(
                        name: "FK_CrashRecord_RoadCharacter_RoadCharacterId",
                        column: x => x.RoadCharacterId,
                        principalTable: "RoadCharacter",
                        principalColumn: "RoadCharacterId");
                    table.ForeignKey(
                        name: "FK_CrashRecord_RoadCondition_RoadConditionId",
                        column: x => x.RoadConditionId,
                        principalTable: "RoadCondition",
                        principalColumn: "RoadConditionId");
                    table.ForeignKey(
                        name: "FK_CrashRecord_RoadConfiguration_RoadConfigurationId",
                        column: x => x.RoadConfigurationId,
                        principalTable: "RoadConfiguration",
                        principalColumn: "RoadConfigurationId");
                    table.ForeignKey(
                        name: "FK_CrashRecord_VehicleType_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleType",
                        principalColumn: "VehicleTypeId");
                    table.ForeignKey(
                        name: "FK_CrashRecord_WeatherCondition_WeatherConditionId",
                        column: x => x.WeatherConditionId,
                        principalTable: "WeatherCondition",
                        principalColumn: "WeatherConditionId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "RoadCharacter",
                columns: new[] { "RoadCharacterId", "CreatedBy", "CreatedDate", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8145), "Straight", "Straight" },
                    { 2, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8182), "Level", "Level" },
                    { 3, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8184), "Curve", "Curve" },
                    { 4, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8186), "HillCrest", "HillCrest" },
                    { 5, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8188), "Other", "Other" }
                });

            migrationBuilder.InsertData(
                table: "RoadCondition",
                columns: new[] { "RoadConditionId", "CreatedBy", "CreatedDate", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8229), "Dry", "Dry" },
                    { 2, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8234), "Wet", "Wet" },
                    { 3, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8236), "Ice", "Ice" },
                    { 4, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8238), "Snow", "Snow" },
                    { 5, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8240), "UnKnown", "UnKnown" }
                });

            migrationBuilder.InsertData(
                table: "RoadConfiguration",
                columns: new[] { "RoadConfigurationId", "CreatedBy", "CreatedDate", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8265), "Two-Way", "Two-Way" },
                    { 2, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8270), "Not Divided", "Not Divided" },
                    { 3, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8273), "Divided", "Divided" },
                    { 4, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8275), "Other", "Other" }
                });

            migrationBuilder.InsertData(
                table: "VehicleType",
                columns: new[] { "VehicleTypeId", "CreatedBy", "CreatedDate", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8296), "Passenger", "Passenger" },
                    { 2, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8300), "Sport", "Sport" },
                    { 3, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8301), "PickUp", "PickUp" },
                    { 4, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8304), "Van", "Van" },
                    { 5, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8306), "Unknown", "Unknown" }
                });

            migrationBuilder.InsertData(
                table: "WeatherCondition",
                columns: new[] { "WeatherConditionId", "CreatedBy", "CreatedDate", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8325), "Clear", "Clear" },
                    { 2, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8330), "Cloudy", "Cloudy" },
                    { 3, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8332), "Rain", "Rain" },
                    { 4, "System", new DateTime(2023, 11, 7, 8, 29, 17, 16, DateTimeKind.Local).AddTicks(8335), "Other", "Other" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CrashRecord_RoadCharacterId",
                table: "CrashRecord",
                column: "RoadCharacterId");

            migrationBuilder.CreateIndex(
                name: "IX_CrashRecord_RoadConditionId",
                table: "CrashRecord",
                column: "RoadConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_CrashRecord_RoadConfigurationId",
                table: "CrashRecord",
                column: "RoadConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_CrashRecord_VehicleTypeId",
                table: "CrashRecord",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CrashRecord_WeatherConditionId",
                table: "CrashRecord",
                column: "WeatherConditionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "CrashRecord");

            migrationBuilder.DropTable(
                name: "RoadCharacter");

            migrationBuilder.DropTable(
                name: "RoadCondition");

            migrationBuilder.DropTable(
                name: "RoadConfiguration");

            migrationBuilder.DropTable(
                name: "VehicleType");

            migrationBuilder.DropTable(
                name: "WeatherCondition");
        }
    }
}
