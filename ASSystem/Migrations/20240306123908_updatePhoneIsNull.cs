﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoJWT.Migrations
{
    public partial class updatePhoneIsNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Convenient",
                columns: table => new
                {
                    ConvenientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Convenient", x => x.ConvenientID);
                });

            migrationBuilder.CreateTable(
                name: "Motel",
                columns: table => new
                {
                    MotelID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountID = table.Column<int>(type: "int", nullable: true),
                    Tittle = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    MinPrice = table.Column<decimal>(type: "money", nullable: true),
                    MaxPrice = table.Column<decimal>(type: "money", nullable: true),
                    QuantityEmptyRooms = table.Column<int>(type: "int", nullable: true),
                    Contact = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    deleteAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    City = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    District = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motel", x => x.MotelID);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotelID = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: true),
                    UnitPrice = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Acreage = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Quanlity = table.Column<int>(type: "int", nullable: true),
                    DeleteAt = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomID);
                    table.ForeignKey(
                        name: "FK_Room_Motel",
                        column: x => x.MotelID,
                        principalTable: "Motel",
                        principalColumn: "MotelID");
                });

            migrationBuilder.CreateTable(
                name: "Account",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    deleteAt = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Account", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_Account_Role",
                        column: x => x.RoleID,
                        principalTable: "Role",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "Facility",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    Covenient = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facility_1", x => new { x.RoomID, x.Covenient });
                    table.ForeignKey(
                        name: "FK_Facility_Convenient",
                        column: x => x.Covenient,
                        principalTable: "Convenient",
                        principalColumn: "ConvenientID");
                    table.ForeignKey(
                        name: "FK_Facility_Room",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "RoomID");
                });

            migrationBuilder.CreateTable(
                name: "RoomImage",
                columns: table => new
                {
                    RoomImageID = table.Column<int>(type: "int", nullable: false),
                    roomID = table.Column<int>(type: "int", nullable: false),
                    imageDetail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    pathImageDetail = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomImage", x => x.RoomImageID);
                    table.ForeignKey(
                        name: "FK_RoomImage_Room",
                        column: x => x.roomID,
                        principalTable: "Room",
                        principalColumn: "RoomID");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentID = table.Column<int>(type: "int", nullable: false),
                    AccountID = table.Column<int>(type: "int", nullable: true),
                    RoomID = table.Column<int>(type: "int", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "date", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentID);
                    table.ForeignKey(
                        name: "FK_Payment_Account",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "AccountID");
                });

            migrationBuilder.CreateTable(
                name: "Vote",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    ReviewStar = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vote", x => new { x.AccountID, x.RoomID });
                    table.ForeignKey(
                        name: "FK_Vote_Account",
                        column: x => x.AccountID,
                        principalTable: "Account",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK_Vote_Room",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "RoomID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Account",
                table: "Account",
                columns: new[] { "Username", "Phone", "Email" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_RoleID",
                table: "Account",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Facility_Covenient",
                table: "Facility",
                column: "Covenient");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_AccountID",
                table: "Payment",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Room_MotelID",
                table: "Room",
                column: "MotelID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomImage_roomID",
                table: "RoomImage",
                column: "roomID");

            migrationBuilder.CreateIndex(
                name: "IX_Vote_RoomID",
                table: "Vote",
                column: "RoomID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Facility");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "RoomImage");

            migrationBuilder.DropTable(
                name: "Vote");

            migrationBuilder.DropTable(
                name: "Convenient");

            migrationBuilder.DropTable(
                name: "Account");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Motel");
        }
    }
}
