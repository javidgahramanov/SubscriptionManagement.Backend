using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SubscriptionManagement.DataAccess.Migrations
{
    public partial class Add_Reseller_Entity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookUserSubscriptions",
                keyColumn: "Id",
                keyValue: new Guid("b0a99c65-9adf-4364-976e-5cfe8d0ba351"));

            migrationBuilder.AddColumn<Guid>(
                name: "ResellerId",
                table: "Books",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Resellers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    ResellerName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resellers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BookUserSubscriptions",
                columns: new[] { "Id", "BookId", "SubscriptionId", "UserId" },
                values: new object[] { new Guid("d0f3167b-dfbb-422b-8bb5-e5c7c8816955"), new Guid("484c2b84-2644-4b55-8f64-27d643286b7a"), new Guid("264badb0-913a-4a83-9193-276e12e48486"), new Guid("a7ec27ee-ac75-47f3-b4b9-9e76bcdc9c39") });

            migrationBuilder.InsertData(
                table: "Resellers",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "ResellerName" },
                values: new object[] { new Guid("9ef291a7-5f8d-4bc7-bd00-34bb438e43a6"), new DateTime(2020, 9, 6, 16, 54, 26, 795, DateTimeKind.Utc).AddTicks(9638), null, new DateTime(2020, 9, 6, 16, 54, 26, 795, DateTimeKind.Utc).AddTicks(9668), null, "System" });

            migrationBuilder.InsertData(
                table: "Resellers",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "ResellerName" },
                values: new object[] { new Guid("17948b03-bdcc-436b-8006-78022fe3008a"), new DateTime(2020, 9, 6, 16, 54, 26, 796, DateTimeKind.Utc).AddTicks(1064), null, new DateTime(2020, 9, 6, 16, 54, 26, 796, DateTimeKind.Utc).AddTicks(1075), null, "Amazon" });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("43f37e69-e2f0-44eb-a224-9917d8ab3441"),
                columns: new[] { "CreatedAt", "ModifiedAt", "ResellerId" },
                values: new object[] { new DateTime(2020, 9, 6, 16, 54, 26, 794, DateTimeKind.Utc).AddTicks(133), new DateTime(2020, 9, 6, 16, 54, 26, 794, DateTimeKind.Utc).AddTicks(140), new Guid("17948b03-bdcc-436b-8006-78022fe3008a") });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("484c2b84-2644-4b55-8f64-27d643286b7a"),
                columns: new[] { "CreatedAt", "ModifiedAt", "ResellerId" },
                values: new object[] { new DateTime(2020, 9, 6, 16, 54, 26, 793, DateTimeKind.Utc).AddTicks(4757), new DateTime(2020, 9, 6, 16, 54, 26, 793, DateTimeKind.Utc).AddTicks(4780), new Guid("9ef291a7-5f8d-4bc7-bd00-34bb438e43a6") });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ca55d80e-5625-4258-94b6-a79278432a5b"),
                columns: new[] { "CreatedAt", "ModifiedAt", "ResellerId" },
                values: new object[] { new DateTime(2020, 9, 6, 16, 54, 26, 793, DateTimeKind.Utc).AddTicks(9943), new DateTime(2020, 9, 6, 16, 54, 26, 793, DateTimeKind.Utc).AddTicks(9961), new Guid("9ef291a7-5f8d-4bc7-bd00-34bb438e43a6") });

            migrationBuilder.CreateIndex(
                name: "IX_Books_ResellerId",
                table: "Books",
                column: "ResellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Resellers_ResellerId",
                table: "Books",
                column: "ResellerId",
                principalTable: "Resellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Resellers_ResellerId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Resellers");

            migrationBuilder.DropIndex(
                name: "IX_Books_ResellerId",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "BookUserSubscriptions",
                keyColumn: "Id",
                keyValue: new Guid("d0f3167b-dfbb-422b-8bb5-e5c7c8816955"));

            migrationBuilder.DropColumn(
                name: "ResellerId",
                table: "Books");

            migrationBuilder.InsertData(
                table: "BookUserSubscriptions",
                columns: new[] { "Id", "BookId", "SubscriptionId", "UserId" },
                values: new object[] { new Guid("b0a99c65-9adf-4364-976e-5cfe8d0ba351"), new Guid("484c2b84-2644-4b55-8f64-27d643286b7a"), new Guid("264badb0-913a-4a83-9193-276e12e48486"), new Guid("a7ec27ee-ac75-47f3-b4b9-9e76bcdc9c39") });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("43f37e69-e2f0-44eb-a224-9917d8ab3441"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2020, 9, 5, 13, 22, 16, 55, DateTimeKind.Utc).AddTicks(7450), new DateTime(2020, 9, 5, 13, 22, 16, 55, DateTimeKind.Utc).AddTicks(7453) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("484c2b84-2644-4b55-8f64-27d643286b7a"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2020, 9, 5, 13, 22, 16, 55, DateTimeKind.Utc).AddTicks(3983), new DateTime(2020, 9, 5, 13, 22, 16, 55, DateTimeKind.Utc).AddTicks(3998) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ca55d80e-5625-4258-94b6-a79278432a5b"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2020, 9, 5, 13, 22, 16, 55, DateTimeKind.Utc).AddTicks(7341), new DateTime(2020, 9, 5, 13, 22, 16, 55, DateTimeKind.Utc).AddTicks(7354) });
        }
    }
}
