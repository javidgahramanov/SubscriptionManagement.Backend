using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SubscriptionManagement.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Catalogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    CatalogName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catalogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    SubscriptionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    BookName = table.Column<string>(nullable: true),
                    CatalogId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Catalogs_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    ModifiedBy = table.Column<string>(nullable: true),
                    ModifiedAt = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    SubscriptionId = table.Column<Guid>(nullable: true),
                    UserRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BookUserSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    SubscriptionId = table.Column<Guid>(nullable: false),
                    BookId = table.Column<Guid>(nullable: false)
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
                table: "Catalogs",
                columns: new[] { "Id", "CatalogName", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy" },
                values: new object[,]
                {
                    { new Guid("ac06b5ad-af65-435c-bb49-4adb5668fd67"), "Classics", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { new Guid("35ad6824-3027-4721-8c8d-9048a5bd6ebd"), "Romance", new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Subscriptions",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy", "SubscriptionName" },
                values: new object[,]
                {
                    { new Guid("264badb0-913a-4a83-9193-276e12e48486"), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Standart" },
                    { new Guid("d1c05ba7-cc98-4842-83f3-9d160a970ab4"), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Silver" },
                    { new Guid("5fd8c947-ef44-4bec-a38d-72fef313394a"), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Gold" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "BookName", "CatalogId", "CreatedAt", "CreatedBy", "ModifiedAt", "ModifiedBy" },
                values: new object[,]
                {
                    { new Guid("484c2b84-2644-4b55-8f64-27d643286b7a"), "To Kill a Mockingbird", new Guid("ac06b5ad-af65-435c-bb49-4adb5668fd67"), new DateTime(2020, 9, 5, 12, 39, 47, 864, DateTimeKind.Utc).AddTicks(5637), null, new DateTime(2020, 9, 5, 12, 39, 47, 864, DateTimeKind.Utc).AddTicks(5660), null },
                    { new Guid("ca55d80e-5625-4258-94b6-a79278432a5b"), "The Boy, the Mole, the Fox and the Horse", new Guid("ac06b5ad-af65-435c-bb49-4adb5668fd67"), new DateTime(2020, 9, 5, 12, 39, 47, 864, DateTimeKind.Utc).AddTicks(8539), null, new DateTime(2020, 9, 5, 12, 39, 47, 864, DateTimeKind.Utc).AddTicks(8551), null },
                    { new Guid("43f37e69-e2f0-44eb-a224-9917d8ab3441"), "Brazen and the Beast", new Guid("35ad6824-3027-4721-8c8d-9048a5bd6ebd"), new DateTime(2020, 9, 5, 12, 39, 47, 864, DateTimeKind.Utc).AddTicks(8624), null, new DateTime(2020, 9, 5, 12, 39, 47, 864, DateTimeKind.Utc).AddTicks(8627), null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Email", "FirstName", "LastName", "ModifiedAt", "ModifiedBy", "Password", "SubscriptionId", "UserRole" },
                values: new object[,]
                {
                    { new Guid("a7ec27ee-ac75-47f3-b4b9-9e76bcdc9c39"), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "javid@mail.com", null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mFdxtcYpmVV5T/cXNFV+M7uNlRQ=", new Guid("264badb0-913a-4a83-9193-276e12e48486"), 0 },
                    { new Guid("685b4197-c2f4-4d75-a241-b8dc204e59bc"), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "john@mail.com", null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mFdxtcYpmVV5T/cXNFV+M7uNlRQ=", new Guid("d1c05ba7-cc98-4842-83f3-9d160a970ab4"), 0 },
                    { new Guid("ebf0c1b9-3210-41c4-9765-fa2b805ca0f4"), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "amanda@mail.com", null, null, new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "mFdxtcYpmVV5T/cXNFV+M7uNlRQ=", new Guid("d1c05ba7-cc98-4842-83f3-9d160a970ab4"), 1 }
                });

            migrationBuilder.InsertData(
                table: "BookUserSubscriptions",
                columns: new[] { "Id", "BookId", "SubscriptionId", "UserId" },
                values: new object[] { new Guid("0490465c-1655-47e5-96d1-bc96e7d3e6aa"), new Guid("484c2b84-2644-4b55-8f64-27d643286b7a"), new Guid("264badb0-913a-4a83-9193-276e12e48486"), new Guid("a7ec27ee-ac75-47f3-b4b9-9e76bcdc9c39") });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CatalogId",
                table: "Books",
                column: "CatalogId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Users_SubscriptionId",
                table: "Users",
                column: "SubscriptionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookUserSubscriptions");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Catalogs");

            migrationBuilder.DropTable(
                name: "Subscriptions");
        }
    }
}
