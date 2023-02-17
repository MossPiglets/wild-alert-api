using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WildAlert.Persistence.Migrations
{
    public partial class Exampledata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sensors",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Sensors",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Sensors",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sensors",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "SensorId",
                table: "SensorData",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DetectedAt",
                table: "SensorData",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "DetectedAnimal",
                table: "SensorData",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "SensorData",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Alerts",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Alerts",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Alerts",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Alerts",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Animal",
                table: "Alerts",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Alerts",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.InsertData(
                table: "Alerts",
                columns: new[] { "Id", "Animal", "Comments", "CreatedAt", "Latitude", "Longitude" },
                values: new object[] { new Guid("351b8c74-6f0d-4e1d-846a-87432ee6e9a3"), 2, "testowy alert lis", new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.0, 30.0 });

            migrationBuilder.InsertData(
                table: "Alerts",
                columns: new[] { "Id", "Animal", "Comments", "CreatedAt", "Latitude", "Longitude" },
                values: new object[] { new Guid("9390acd1-f75c-4541-bf26-e54a04de1340"), 3, "testowy alert jeleń", new DateTime(2023, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 30.0, 20.0 });

            migrationBuilder.InsertData(
                table: "Alerts",
                columns: new[] { "Id", "Animal", "Comments", "CreatedAt", "Latitude", "Longitude" },
                values: new object[] { new Guid("bf152ece-9dd3-4f60-abab-32c43235e2fb"), 1, "testowy alert dzik", new DateTime(2023, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.0, 20.0 });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "Latitude", "Longitude", "Name" },
                values: new object[] { new Guid("237ac44e-c4ea-4ef4-bc3c-d4db57f5a343"), 31.0, 21.0, "skrzyzowanie x z y" });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "Latitude", "Longitude", "Name" },
                values: new object[] { new Guid("3dc6abcc-3d4d-4c34-8fb2-5e115b5b73cd"), 51.0, 21.0, "ulica przykladowa" });

            migrationBuilder.InsertData(
                table: "Sensors",
                columns: new[] { "Id", "Latitude", "Longitude", "Name" },
                values: new object[] { new Guid("fe447da9-2c08-4bbb-9b4e-53043f56fff1"), 31.0, 31.0, "testowy park" });

            migrationBuilder.InsertData(
                table: "SensorData",
                columns: new[] { "Id", "DetectedAnimal", "DetectedAt", "SensorId" },
                values: new object[] { new Guid("6964b836-ef63-4736-b6cb-b4f7d74649f0"), 1, new DateTime(2023, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("237ac44e-c4ea-4ef4-bc3c-d4db57f5a343") });

            migrationBuilder.InsertData(
                table: "SensorData",
                columns: new[] { "Id", "DetectedAnimal", "DetectedAt", "SensorId" },
                values: new object[] { new Guid("dc4ef180-4dc3-4c3a-a42e-2e034c693897"), 666, new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("3dc6abcc-3d4d-4c34-8fb2-5e115b5b73cd") });

            migrationBuilder.InsertData(
                table: "SensorData",
                columns: new[] { "Id", "DetectedAnimal", "DetectedAt", "SensorId" },
                values: new object[] { new Guid("fe447da9-2c08-4bbb-9b4e-53043f56fff1"), 0, new DateTime(2023, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("fe447da9-2c08-4bbb-9b4e-53043f56fff1") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: new Guid("351b8c74-6f0d-4e1d-846a-87432ee6e9a3"));

            migrationBuilder.DeleteData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: new Guid("9390acd1-f75c-4541-bf26-e54a04de1340"));

            migrationBuilder.DeleteData(
                table: "Alerts",
                keyColumn: "Id",
                keyValue: new Guid("bf152ece-9dd3-4f60-abab-32c43235e2fb"));

            migrationBuilder.DeleteData(
                table: "SensorData",
                keyColumn: "Id",
                keyValue: new Guid("6964b836-ef63-4736-b6cb-b4f7d74649f0"));

            migrationBuilder.DeleteData(
                table: "SensorData",
                keyColumn: "Id",
                keyValue: new Guid("dc4ef180-4dc3-4c3a-a42e-2e034c693897"));

            migrationBuilder.DeleteData(
                table: "SensorData",
                keyColumn: "Id",
                keyValue: new Guid("fe447da9-2c08-4bbb-9b4e-53043f56fff1"));

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("237ac44e-c4ea-4ef4-bc3c-d4db57f5a343"));

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("3dc6abcc-3d4d-4c34-8fb2-5e115b5b73cd"));

            migrationBuilder.DeleteData(
                table: "Sensors",
                keyColumn: "Id",
                keyValue: new Guid("fe447da9-2c08-4bbb-9b4e-53043f56fff1"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Sensors",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Sensors",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Sensors",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Sensors",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<Guid>(
                name: "SensorId",
                table: "SensorData",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DetectedAt",
                table: "SensorData",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "DetectedAnimal",
                table: "SensorData",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "SensorData",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<double>(
                name: "Longitude",
                table: "Alerts",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<double>(
                name: "Latitude",
                table: "Alerts",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "Alerts",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Alerts",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Animal",
                table: "Alerts",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Alerts",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "TEXT");
        }
    }
}
