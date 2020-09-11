using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SubscriptionManagement.DataAccess.Migrations
{
    public partial class Provided_Reselling_Possilibity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookUserSubscriptions");

            migrationBuilder.AddColumn<bool>(
                name: "IsReseller",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "UserBooks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    SubscriptionId = table.Column<Guid>(nullable: true),
                    BookId = table.Column<Guid>(nullable: false),
                    OnSale = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserBooks_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserBooks_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserBooks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("43f37e69-e2f0-44eb-a224-9917d8ab3441"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2020, 9, 6, 17, 25, 54, 474, DateTimeKind.Utc).AddTicks(3084), new DateTime(2020, 9, 6, 17, 25, 54, 474, DateTimeKind.Utc).AddTicks(3086) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("484c2b84-2644-4b55-8f64-27d643286b7a"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2020, 9, 6, 17, 25, 54, 473, DateTimeKind.Utc).AddTicks(9792), new DateTime(2020, 9, 6, 17, 25, 54, 473, DateTimeKind.Utc).AddTicks(9800) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ca55d80e-5625-4258-94b6-a79278432a5b"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2020, 9, 6, 17, 25, 54, 474, DateTimeKind.Utc).AddTicks(3015), new DateTime(2020, 9, 6, 17, 25, 54, 474, DateTimeKind.Utc).AddTicks(3022) });

            migrationBuilder.UpdateData(
                table: "Resellers",
                keyColumn: "Id",
                keyValue: new Guid("17948b03-bdcc-436b-8006-78022fe3008a"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2020, 9, 6, 17, 25, 54, 475, DateTimeKind.Utc).AddTicks(6339), new DateTime(2020, 9, 6, 17, 25, 54, 475, DateTimeKind.Utc).AddTicks(6346) });

            migrationBuilder.UpdateData(
                table: "Resellers",
                keyColumn: "Id",
                keyValue: new Guid("9ef291a7-5f8d-4bc7-bd00-34bb438e43a6"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2020, 9, 6, 17, 25, 54, 475, DateTimeKind.Utc).AddTicks(5531), new DateTime(2020, 9, 6, 17, 25, 54, 475, DateTimeKind.Utc).AddTicks(5542) });

            migrationBuilder.InsertData(
                table: "UserBooks",
                columns: new[] { "Id", "BookId", "OnSale", "SubscriptionId", "UserId" },
                values: new object[] { new Guid("1e387e0f-744d-43ba-b4b0-ce9728239457"), new Guid("484c2b84-2644-4b55-8f64-27d643286b7a"), false, new Guid("264badb0-913a-4a83-9193-276e12e48486"), new Guid("a7ec27ee-ac75-47f3-b4b9-9e76bcdc9c39") });

            migrationBuilder.CreateIndex(
                name: "IX_UserBooks_BookId",
                table: "UserBooks",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBooks_SubscriptionId",
                table: "UserBooks",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserBooks_UserId",
                table: "UserBooks",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBooks");

            migrationBuilder.DropColumn(
                name: "IsReseller",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "BookUserSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BookId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookUserSubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookUserSubscriptions_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUserSubscriptions_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookUserSubscriptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BookUserSubscriptions",
                columns: new[] { "Id", "BookId", "SubscriptionId", "UserId" },
                values: new object[] { new Guid("d0f3167b-dfbb-422b-8bb5-e5c7c8816955"), new Guid("484c2b84-2644-4b55-8f64-27d643286b7a"), new Guid("264badb0-913a-4a83-9193-276e12e48486"), new Guid("a7ec27ee-ac75-47f3-b4b9-9e76bcdc9c39") });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("43f37e69-e2f0-44eb-a224-9917d8ab3441"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2020, 9, 6, 16, 54, 26, 794, DateTimeKind.Utc).AddTicks(133), new DateTime(2020, 9, 6, 16, 54, 26, 794, DateTimeKind.Utc).AddTicks(140) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("484c2b84-2644-4b55-8f64-27d643286b7a"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2020, 9, 6, 16, 54, 26, 793, DateTimeKind.Utc).AddTicks(4757), new DateTime(2020, 9, 6, 16, 54, 26, 793, DateTimeKind.Utc).AddTicks(4780) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ca55d80e-5625-4258-94b6-a79278432a5b"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2020, 9, 6, 16, 54, 26, 793, DateTimeKind.Utc).AddTicks(9943), new DateTime(2020, 9, 6, 16, 54, 26, 793, DateTimeKind.Utc).AddTicks(9961) });

            migrationBuilder.UpdateData(
                table: "Resellers",
                keyColumn: "Id",
                keyValue: new Guid("17948b03-bdcc-436b-8006-78022fe3008a"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2020, 9, 6, 16, 54, 26, 796, DateTimeKind.Utc).AddTicks(1064), new DateTime(2020, 9, 6, 16, 54, 26, 796, DateTimeKind.Utc).AddTicks(1075) });

            migrationBuilder.UpdateData(
                table: "Resellers",
                keyColumn: "Id",
                keyValue: new Guid("9ef291a7-5f8d-4bc7-bd00-34bb438e43a6"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2020, 9, 6, 16, 54, 26, 795, DateTimeKind.Utc).AddTicks(9638), new DateTime(2020, 9, 6, 16, 54, 26, 795, DateTimeKind.Utc).AddTicks(9668) });

            migrationBuilder.CreateIndex(
                name: "IX_BookUserSubscriptions_BookId",
                table: "BookUserSubscriptions",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_BookUserSubscriptions_SubscriptionId",
                table: "BookUserSubscriptions",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_BookUserSubscriptions_UserId",
                table: "BookUserSubscriptions",
                column: "UserId");
        }
    }
}
