using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradeSystem.Data.Migrations
{
    public partial class SoftDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "379565d5-1775-4808-9a96-06864d2fc0a5", "AQAAAAEAACcQAAAAEIckdSvPKrIk+BlwXRTTwSg80oaZy8HgqD55Eu7GgJ9P+wOknzTbi+3ehF6p/7xwGg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "eb90a07d-266d-4eba-a631-44ef85682c63", "AQAAAAEAACcQAAAAECQ64POPDVqyn7VheJk8oPmJh74zTf6r9Rnd3nr8wQ2glA8rJx59/tcXf5lhu8TfBQ==" });

            migrationBuilder.UpdateData(
                table: "DataOfIndividualClients",
                keyColumn: "Id",
                keyValue: new Guid("21bbf6eb-0d93-460c-ab6f-c1530b16e97d"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 9, 21, 0, 2, 916, DateTimeKind.Local).AddTicks(4584));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("6d5800ce-d726-4fc8-83d9-d6b3ac1f591e"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2196fbe2-986b-4e63-a5db-842336c90102", "AQAAAAEAACcQAAAAEN0UcNvCORyqcUshjB45rmTqh5qQI++xru4rA9ry6rqrCskW62fh19D7uaQe9MNXoQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("dea12856-c198-4129-b3f3-b893d8395082"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5fe878b0-4e0e-4f3b-9761-fc9025a03311", "AQAAAAEAACcQAAAAEOvTCjYwpbDlg3BiDVQTc9LQdJiZRmd0MWjg9cwq+L9LxavGGwA0xAWQDGkoWZM5cg==" });

            migrationBuilder.UpdateData(
                table: "DataOfIndividualClients",
                keyColumn: "Id",
                keyValue: new Guid("21bbf6eb-0d93-460c-ab6f-c1530b16e97d"),
                column: "CreatedOn",
                value: new DateTime(2024, 3, 8, 13, 46, 52, 386, DateTimeKind.Local).AddTicks(3207));
        }
    }
}
