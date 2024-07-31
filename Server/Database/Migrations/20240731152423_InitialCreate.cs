using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    DetailId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.DetailId);
                });

            migrationBuilder.CreateTable(
                name: "FileExtensions",
                columns: table => new
                {
                    FileExtensionId = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileExtensions", x => x.FileExtensionId);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    MaterialId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.MaterialId);
                });

            migrationBuilder.CreateTable(
                name: "Pumps",
                columns: table => new
                {
                    PumpId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    MaxPressure = table.Column<float>(type: "real", nullable: false),
                    MaxLiquidTemperature = table.Column<float>(type: "real", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pumps", x => x.PumpId);
                });

            migrationBuilder.CreateTable(
                name: "SourceTypes",
                columns: table => new
                {
                    SourcesId = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceTypes", x => x.SourcesId);
                });

            migrationBuilder.CreateTable(
                name: "PumpsDetails",
                columns: table => new
                {
                    PumpDetailId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PumpId = table.Column<long>(type: "bigint", nullable: false),
                    DetailId = table.Column<int>(type: "int", nullable: false),
                    MaterialId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PumpsDetails", x => x.PumpDetailId);
                    table.ForeignKey(
                        name: "FK_PumpsDetails_Details_DetailId",
                        column: x => x.DetailId,
                        principalTable: "Details",
                        principalColumn: "DetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PumpsDetails_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "MaterialId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PumpsDetails_Pumps_PumpId",
                        column: x => x.PumpId,
                        principalTable: "Pumps",
                        principalColumn: "PumpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    FilesId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SourceTypeId = table.Column<byte>(type: "tinyint", nullable: false),
                    ExtensionId = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.FilesId);
                    table.ForeignKey(
                        name: "FK_Files_FileExtensions_ExtensionId",
                        column: x => x.ExtensionId,
                        principalTable: "FileExtensions",
                        principalColumn: "FileExtensionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Files_SourceTypes_SourceTypeId",
                        column: x => x.SourceTypeId,
                        principalTable: "SourceTypes",
                        principalColumn: "SourcesId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PumpFiles",
                columns: table => new
                {
                    FileId = table.Column<long>(type: "bigint", nullable: false),
                    PumpId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PumpFiles", x => new { x.FileId, x.PumpId });
                    table.ForeignKey(
                        name: "FK_PumpFiles_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "FilesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PumpFiles_Pumps_PumpId",
                        column: x => x.PumpId,
                        principalTable: "Pumps",
                        principalColumn: "PumpId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "DetailId", "Name" },
                values: new object[,]
                {
                    { 1, "Приводной вал" },
                    { 2, "Сальник вала" },
                    { 3, "Лопастное колесо" },
                    { 4, "Корпус насоса" },
                    { 5, "Подшипник" },
                    { 6, "Опорный вал" },
                    { 7, "Рабочее колесо" }
                });

            migrationBuilder.InsertData(
                table: "FileExtensions",
                columns: new[] { "FileExtensionId", "Name" },
                values: new object[,]
                {
                    { (byte)1, "jpg" },
                    { (byte)2, "png" },
                    { (byte)3, "zip" },
                    { (byte)4, "jpeg" },
                    { (byte)5, "pdf" },
                    { (byte)6, "rar" },
                    { (byte)7, "7z" }
                });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "MaterialId", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, "Сталь (от нем. Stahl)[1] — сплав железа с углеродом (и другими элементами периодической таблицы), содержащий не менее 45 % железа и в котором содержание углерода находится в диапазоне от 0,02 до 2,14 %, причём содержанию от 0,6 % до 2,14 % соответствует высокоуглеродистая сталь.", "Сталь" },
                    { 2L, "Чугу́н — сплав железа с углеродом (и другими элементами), в котором содержание углерода — не менее 2,14 % (точка предельной растворимости углерода в аустените на диаграмме состояний), а сплавы с содержанием углерода менее 2,14 % называются сталью. Углерод придаёт сплавам железа твёрдость, снижая пластичность и вязкость.", "Чугун" },
                    { 3L, "Нержавеющая сталь (коррозионно-стойкие стали, в просторечье «нержавейка») — легированная сталь, устойчивая к коррозии в атмосфере и агрессивных средах, обладающая термостойкими свойствами[1][2]. Различные марки нержавеющей стали включают хром, никель, углерод, азот, алюминий, кремний, серу, титан, медь, селен, ниобий и молибден[3]. Однако, в условиях, например, солевого тумана и морской воды, а также при нарушении технологии сварки и термической обработки, и нержавеющая сталь подвергается коррозии.", "Нержавеющая сталь" },
                    { 4L, "Бро́нза — сплав меди, обычно с оловом в качестве основного компонента, но к бронзам также относят медные сплавы с алюминием, кремнием, бериллием, свинцом и другими элементами, за исключением цинка (это латунь), никеля (это мельхиор), цинка и никеля (это нейзильбер). Как правило, в любой бронзе в незначительных количествах присутствуют добавки: цинк, свинец, фосфор и другие.", "Бронза" },
                    { 5L, "Кера́мика (др.-греч. κέραμος — глина) — материалы, изготавливаемые из глин или их смесей с минеральными добавками (а иногда из других неорганических соединений) под воздействием высокой температуры с последующим охлаждением; а также изделия из таких материалов[.", "Керамики" }
                });

            migrationBuilder.InsertData(
                table: "Pumps",
                columns: new[] { "PumpId", "Description", "MaxLiquidTemperature", "MaxPressure", "Name", "Price", "Weight" },
                values: new object[] { 1L, "Поверхностный насос предназначен для подачи под давлением чистой воды в дом, для орошения сада и огорода.\r\n\r\nВода не должна содержать абразивных или волокнистых, а также химических составных частей, которые могли бы повредить материал деталей насоса.", 50f, 45f, "Поверхностный насос ПН-900 Вихрь", 11980m, 25f });

            migrationBuilder.InsertData(
                table: "SourceTypes",
                columns: new[] { "SourcesId", "Description", "Name" },
                values: new object[,]
                {
                    { (byte)1, "Файлы хронятся на сервере", "Файл на сервере" },
                    { (byte)2, "Файлы хронятся на в яндекс облаке", "Файл на Яндекс облаке" },
                    { (byte)3, null, "Файл в Google облаке" }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "FilesId", "Created", "ExtensionId", "Name", "OriginalName", "Path", "SourceTypeId" },
                values: new object[,]
                {
                    { 1L, new DateTime(2024, 7, 31, 18, 24, 22, 769, DateTimeKind.Local).AddTicks(7979), (byte)1, "5422_big", "5422_big.jpg", "\\Pumps", (byte)1 },
                    { 2L, new DateTime(2024, 7, 31, 18, 24, 22, 769, DateTimeKind.Local).AddTicks(7996), (byte)1, "poverxnostnyij-nasos-pn-900che-vixr", "poverxnostnyij-nasos-pn-900che-vixr.jpg", "\\Pumps", (byte)1 }
                });

            migrationBuilder.InsertData(
                table: "PumpsDetails",
                columns: new[] { "PumpDetailId", "DetailId", "MaterialId", "PumpId" },
                values: new object[,]
                {
                    { 1L, 1, 1L, 1L },
                    { 2L, 2, 1L, 1L },
                    { 3L, 3, 2L, 1L },
                    { 4L, 4, 3L, 1L },
                    { 5L, 5, 4L, 1L },
                    { 6L, 6, 1L, 1L }
                });

            migrationBuilder.InsertData(
                table: "PumpFiles",
                columns: new[] { "FileId", "PumpId" },
                values: new object[,]
                {
                    { 1L, 1L },
                    { 2L, 1L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_ExtensionId",
                table: "Files",
                column: "ExtensionId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_SourceTypeId",
                table: "Files",
                column: "SourceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PumpFiles_PumpId",
                table: "PumpFiles",
                column: "PumpId");

            migrationBuilder.CreateIndex(
                name: "IX_PumpsDetails_DetailId",
                table: "PumpsDetails",
                column: "DetailId");

            migrationBuilder.CreateIndex(
                name: "IX_PumpsDetails_MaterialId",
                table: "PumpsDetails",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_PumpsDetails_PumpId",
                table: "PumpsDetails",
                column: "PumpId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PumpFiles");

            migrationBuilder.DropTable(
                name: "PumpsDetails");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Pumps");

            migrationBuilder.DropTable(
                name: "FileExtensions");

            migrationBuilder.DropTable(
                name: "SourceTypes");
        }
    }
}
