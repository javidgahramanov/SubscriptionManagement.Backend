using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SubscriptionManagement.DataAccess.Migrations
{
    public partial class AddedPrice_To_book : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookUserSubscriptions",
                keyColumn: "Id",
                keyValue: new Guid("0490465c-1655-47e5-96d1-bc96e7d3e6aa"));

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Books",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "BookUserSubscriptions",
                columns: new[] { "Id", "BookId", "SubscriptionId", "UserId" },
                values: new object[] { new Guid("b0a99c65-9adf-4364-976e-5cfe8d0ba351"), new Guid("484c2b84-2644-4b55-8f64-27d643286b7a"), new Guid("264badb0-913a-4a83-9193-276e12e48486"), new Guid("a7ec27ee-ac75-47f3-b4b9-9e76bcdc9c39") });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("43f37e69-e2f0-44eb-a224-9917d8ab3441"),
                columns: new[] { "CreatedAt", "ModifiedAt", "Price" },
                values: new object[] { new DateTime(2020, 9, 5, 13, 22, 16, 55, DateTimeKind.Utc).AddTicks(7450), new DateTime(2020, 9, 5, 13, 22, 16, 55, DateTimeKind.Utc).AddTicks(7453), 40m });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("484c2b84-2644-4b55-8f64-27d643286b7a"),
                columns: new[] { "CreatedAt", "ModifiedAt", "Price" },
                values: new object[] { new DateTime(2020, 9, 5, 13, 22, 16, 55, DateTimeKind.Utc).AddTicks(3983), new DateTime(2020, 9, 5, 13, 22, 16, 55, DateTimeKind.Utc).AddTicks(3998), 25m });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ca55d80e-5625-4258-94b6-a79278432a5b"),
                columns: new[] { "CreatedAt", "ModifiedAt", "Price" },
                values: new object[] { new DateTime(2020, 9, 5, 13, 22, 16, 55, DateTimeKind.Utc).AddTicks(7341), new DateTime(2020, 9, 5, 13, 22, 16, 55, DateTimeKind.Utc).AddTicks(7354), 30m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookUserSubscriptions",
                keyColumn: "Id",
                keyValue: new Guid("b0a99c65-9adf-4364-976e-5cfe8d0ba351"));

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Books");

            migrationBuilder.InsertData(
                table: "BookUserSubscriptions",
                columns: new[] { "Id", "BookId", "SubscriptionId", "UserId" },
                values: new object[] { new Guid("0490465c-1655-47e5-96d1-bc96e7d3e6aa"), new Guid("484c2b84-2644-4b55-8f64-27d643286b7a"), new Guid("264badb0-913a-4a83-9193-276e12e48486"), new Guid("a7ec27ee-ac75-47f3-b4b9-9e76bcdc9c39") });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("43f37e69-e2f0-44eb-a224-9917d8ab3441"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2020, 9, 5, 12, 39, 47, 864, DateTimeKind.Utc).AddTicks(8624), new DateTime(2020, 9, 5, 12, 39, 47, 864, DateTimeKind.Utc).AddTicks(8627) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("484c2b84-2644-4b55-8f64-27d643286b7a"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2020, 9, 5, 12, 39, 47, 864, DateTimeKind.Utc).AddTicks(5637), new DateTime(2020, 9, 5, 12, 39, 47, 864, DateTimeKind.Utc).AddTicks(5660) });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ca55d80e-5625-4258-94b6-a79278432a5b"),
                columns: new[] { "CreatedAt", "ModifiedAt" },
                values: new object[] { new DateTime(2020, 9, 5, 12, 39, 47, 864, DateTimeKind.Utc).AddTicks(8539), new DateTime(2020, 9, 5, 12, 39, 47, 864, DateTimeKind.Utc).AddTicks(8551) });
        }
    }
}
