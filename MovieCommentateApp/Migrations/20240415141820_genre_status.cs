using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieReviewApp.Migrations
{
    /// <inheritdoc />
    public partial class genre_status : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Genres",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a445865-a24d-4543-4123-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "543d6c61-209e-49df-beee-9ddca73f2374", "AQAAAAIAAYagAAAAEI6yxMM3hBZ9arzxHySCJlD8Z0aw3tMlLmbo2oudLidQtzKun9lHAL1tetzWkTmQcg==", "8418bbc2-e618-4cb8-8ec8-519bf31181ac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a445865-a24d-4543-a6c3-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "660b4134-b178-44ae-889c-37e6da2b60c7", "AQAAAAIAAYagAAAAEGYBH6uRj24iHkCxzMiYnjtuy164dcrr/bcFFwMGJ8XNOm5CTUP91A2FQuK1QGpCdg==", "3edb8ea8-cb8b-49dc-b9a0-3033cfcd186f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "06c37dbf-7270-4cf2-bc49-c17078cd85aa", "AQAAAAIAAYagAAAAEE9TBHDlS5WZRQzvddydSQb9etl3SGT2L4wk88pjX+t4BGo2oZgBumUdLojIMd9rOg==", "dd383619-282f-4140-9a2d-df52e28e7071" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Genres");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a445865-a24d-4543-4123-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "01042bdb-05d7-43dd-b158-72518d79126d", "AQAAAAIAAYagAAAAENDcKFMFlYrhh89BeD5yTW1V8LZY6cdhxXwBDo2GjLxYv86KFJjLqvODXPQuXiIA6Q==", "27bc3aca-3f21-49d6-851b-b923b2075954" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a445865-a24d-4543-a6c3-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9fed17f7-734d-4a1c-a8c5-a1f5ec5fc40d", "AQAAAAIAAYagAAAAED37p+bdtzlIhhgDq9b4JhwWyCnXj7IevfyaSBWmw0M6pDWgMIGNHfI0hgmt6w8AtA==", "e6bbf8ca-6b7d-4fc8-9ce7-1ac99e0adde7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8a445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5446d328-f2ac-481e-8263-fc3539152783", "AQAAAAIAAYagAAAAEDoizwJqisQjA0qmjcSu+sZ52qePaPOTsh0LVi9mPx+I+8h8ZVsQWQwzPw1PurZNtg==", "c17c4394-816a-49ea-9694-701a5a68fe11" });
        }
    }
}
