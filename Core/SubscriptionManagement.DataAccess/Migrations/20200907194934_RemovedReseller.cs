using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SubscriptionManagement.DataAccess.Migrations
{
    public partial class RemovedReseller : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Resellers_ResellerId",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "UserBooks",
                keyColumn: "Id",
                keyValue: new Guid("1e387e0f-744d-43ba-b4b0-ce9728239457"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ResellerId",
                table: "Books",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("43f37e69-e2f0-44eb-a224-9917d8ab3441"),
                columns: new[] { "CreatedAt", "ModifiedAt", "ResellerId" },
                values: new object[] { new DateTime(2020, 9, 7, 19, 49, 33, 209, DateTimeKind.Utc).AddTicks(2334), new DateTime(2020, 9, 7, 19, 49, 33, 209, DateTimeKind.Utc).AddTicks(2343), null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("484c2b84-2644-4b55-8f64-27d643286b7a"),
                columns: new[] { "CreatedAt", "ModifiedAt", "ResellerId" },
                values: new object[] { new DateTime(2020, 9, 7, 19, 49, 33, 208, DateTimeKind.Utc).AddTicks(8534), new DateTime(2020, 9, 7, 19, 49, 33, 208, DateTimeKind.Utc).AddTicks(8545), null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ca55d80e-5625-4258-94b6-a79278432a5b"),
                columns: new[] { "CreatedAt", "ModifiedAt", "ResellerId" },
                values: new object[] { new DateTime(2020, 9, 7, 19, 49, 33, 209, DateTimeKind.Utc).AddTicks(2202), new DateTime(2020, 9, 7, 19, 49, 33, 209, DateTimeKind.Utc).AddTicks(2216), null });

            migrationBuilder.UpdateData(
                table: "Resellers",
                keyColumn: "Id",
                keyValue: new Guid("17948b03-bdcc-436b-8006-78022fe3008a"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2020, 9, 7, 19, 49, 33, 210, DateTimeKind.Utc).AddTicks(4026), new DateTime(2020, 9, 7, 19, 49, 33, 210, DateTimeKind.Utc).AddTicks(4032) });

            migrationBuilder.UpdateData(
                table: "Resellers",
                keyColumn: "Id",
                keyValue: new Guid("9ef291a7-5f8d-4bc7-bd00-34bb438e43a6"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2020, 9, 7, 19, 49, 33, 210, DateTimeKind.Utc).AddTicks(3247), new DateTime(2020, 9, 7, 19, 49, 33, 210, DateTimeKind.Utc).AddTicks(3256) });

            migrationBuilder.InsertData(
                table: "UserBooks",
                columns: new[] { "Id", "BookId", "OnSale", "SubscriptionId", "UserId" },
                values: new object[] { new Guid("7bec1764-d0d7-42aa-b0d1-cb2beaa309de"), new Guid("484c2b84-2644-4b55-8f64-27d643286b7a"), false, new Guid("264badb0-913a-4a83-9193-276e12e48486"), new Guid("a7ec27ee-ac75-47f3-b4b9-9e76bcdc9c39") });

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Resellers_ResellerId",
                table: "Books",
                column: "ResellerId",
                principalTable: "Resellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Resellers_ResellerId",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "UserBooks",
                keyColumn: "Id",
                keyValue: new Guid("7bec1764-d0d7-42aa-b0d1-cb2beaa309de"));

            migrationBuilder.AlterColumn<Guid>(
                name: "ResellerId",
                table: "Books",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("43f37e69-e2f0-44eb-a224-9917d8ab3441"),
                columns: new[] { "CreatedAt", "ModifiedAt", "ResellerId" },
                values: new object[] { new DateTime(2020, 9, 6, 17, 25, 54, 474, DateTimeKind.Utc).AddTicks(3084), new DateTime(2020, 9, 6, 17, 25, 54, 474, DateTimeKind.Utc).AddTicks(3086), new Guid("17948b03-bdcc-436b-8006-78022fe3008a") });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("484c2b84-2644-4b55-8f64-27d643286b7a"),
                columns: new[] { "CreatedAt", "ModifiedAt", "ResellerId" },
                values: new object[] { new DateTime(2020, 9, 6, 17, 25, 54, 473, DateTimeKind.Utc).AddTicks(9792), new DateTime(2020, 9, 6, 17, 25, 54, 473, DateTimeKind.Utc).AddTicks(9800), new Guid("9ef291a7-5f8d-4bc7-bd00-34bb438e43a6") });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ca55d80e-5625-4258-94b6-a79278432a5b"),
                columns: new[] { "CreatedAt", "ModifiedAt", "ResellerId" },
                values: new object[] { new DateTime(2020, 9, 6, 17, 25, 54, 474, DateTimeKind.Utc).AddTicks(3015), new DateTime(2020, 9, 6, 17, 25, 54, 474, DateTimeKind.Utc).AddTicks(3022), new Guid("9ef291a7-5f8d-4bc7-bd00-34bb438e43a6") });

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

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Resellers_ResellerId",
                table: "Books",
                column: "ResellerId",
                principalTable: "Resellers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
