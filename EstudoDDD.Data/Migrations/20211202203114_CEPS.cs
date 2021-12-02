using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EstudoDDD.Data.Migrations
{
    public partial class CEPS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fad5c710-fb9c-41c1-8299-76c9d13c3211"));

            migrationBuilder.CreateTable(
                name: "Uf",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uf", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CodIBGE = table.Column<int>(type: "int", nullable: false),
                    UfId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipio_Uf_UfId",
                        column: x => x.UfId,
                        principalTable: "Uf",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cep",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Logradouro = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MunicipioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cep_Municipio_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Uf",
                columns: new[] { "Id", "CreateAt", "Nome", "Sigla", "UpdateAt" },
                values: new object[,]
                {
                    { new Guid("77df935a-ca53-4ffd-94ae-c197e016ccf0"), new DateTime(2021, 12, 2, 20, 31, 14, 96, DateTimeKind.Utc).AddTicks(8899), "Acre", "AC", null },
                    { new Guid("7fdaaa4c-13ed-49d4-b1aa-ceaae53254b6"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(9057), "Tocantins", "TO", null },
                    { new Guid("6d2e386b-a450-4976-83ce-ed107120c9fb"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(9053), "Sergipe", "SE", null },
                    { new Guid("5e684315-735e-4c8e-a508-8df50649dc1d"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(9049), "Sao Paulo", "SP", null },
                    { new Guid("dbb01ebc-4776-4f72-b630-7b249d81c440"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(9045), "Santa Catarina", "SC", null },
                    { new Guid("a850fb53-9f5b-449e-b691-d084f8b5a402"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(9041), "Roraima", "RR", null },
                    { new Guid("12405ad1-e3e5-43fd-9bfe-0c6fa4816105"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(9036), "Rondonia", "RO", null },
                    { new Guid("6b57ce63-eb3a-4c73-8b59-8098e6862d48"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(9032), "Rio Grande do Sul", "RS", null },
                    { new Guid("dca93b97-5ef7-44ee-bfb4-5f63b0c72598"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(9028), "Rio Grande do Norte", "RN", null },
                    { new Guid("3b0458c6-5eff-4342-bd53-4591d7c006de"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(9024), "Rio de Janeiro", "RJ", null },
                    { new Guid("275002db-aa62-444e-a179-b801583c3568"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(9021), "Piaui", "PI", null },
                    { new Guid("451ecb2b-0ba5-48c7-84ff-32772634c258"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(9017), "Pernambuco", "PE", null },
                    { new Guid("ef7e5a58-45a2-4b80-8e13-fdeefb2f5a5e"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(9012), "Parana", "PR", null },
                    { new Guid("d4fdba6b-ee4c-4c06-b8d7-7dcbbc0d02fa"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(9009), "Paraiba", "PB", null },
                    { new Guid("06759cc3-cf92-49fe-9d98-a8eacb5ee621"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(9005), "Para", "PA", null },
                    { new Guid("3b72bc3f-4613-4313-963c-9621db443e32"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(9001), "Minas Gerais", "MG", null },
                    { new Guid("c4dc2412-b190-411a-8352-0a857b7e327b"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(8997), "Mato Grosso do Sul", "MS", null },
                    { new Guid("786e47a5-f326-40bc-afb5-0af531e7af9f"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(8993), "Mato Grosso", "MT", null },
                    { new Guid("7451a52c-8460-4f6a-bca6-7573b9a44759"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(8988), "Maranhao", "MA", null },
                    { new Guid("8c797ec8-ea24-4bc5-9288-56a6cb14a8ef"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(8984), "Goias", "GO", null },
                    { new Guid("20792100-80af-49a8-8195-f7c36441c38d"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(8980), "Espirito Santo", "ES", null },
                    { new Guid("38cdbdab-bc0b-4f2e-b561-500a1708d8da"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(8976), "Ceara", "CE", null },
                    { new Guid("3a8ca4e0-eb66-452c-b4d5-dd4b428f3cbf"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(8971), "Bahia", "BA", null },
                    { new Guid("2b3cb7d6-f792-4ae6-b068-38da911997d8"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(8965), "Amazonas", "AM", null },
                    { new Guid("489e8c02-00cc-4113-8dab-8e44ead66543"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(8958), "Amapa", "AP", null },
                    { new Guid("8f7ae6df-d6a5-4d86-8994-e64002ee557e"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(8934), "Alagoas", "AL", null },
                    { new Guid("141a0daa-47e8-49fe-8dea-0ee97e4db538"), new DateTime(2021, 12, 2, 17, 31, 14, 96, DateTimeKind.Local).AddTicks(9061), "Distrito Federal", "DF", null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("1980a9da-d23d-4e11-821f-82f3ab3ebb5b"), new DateTime(2021, 12, 2, 17, 31, 14, 90, DateTimeKind.Local).AddTicks(5373), "vini.souza00@gmail.com", "Vinicius", new DateTime(2021, 12, 2, 17, 31, 14, 92, DateTimeKind.Local).AddTicks(5596) });

            migrationBuilder.CreateIndex(
                name: "IX_Cep_Cep",
                table: "Cep",
                column: "Cep");

            migrationBuilder.CreateIndex(
                name: "IX_Cep_MunicipioId",
                table: "Cep",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_CodIBGE",
                table: "Municipio",
                column: "CodIBGE");

            migrationBuilder.CreateIndex(
                name: "IX_Municipio_UfId",
                table: "Municipio",
                column: "UfId");

            migrationBuilder.CreateIndex(
                name: "IX_Uf_Sigla",
                table: "Uf",
                column: "Sigla",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cep");

            migrationBuilder.DropTable(
                name: "Municipio");

            migrationBuilder.DropTable(
                name: "Uf");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("1980a9da-d23d-4e11-821f-82f3ab3ebb5b"));

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreateAt", "Email", "Name", "UpdateAt" },
                values: new object[] { new Guid("fad5c710-fb9c-41c1-8299-76c9d13c3211"), new DateTime(2021, 12, 1, 14, 31, 40, 46, DateTimeKind.Local).AddTicks(1782), "vini.souza00@gmail.com", "Vinicius", new DateTime(2021, 12, 1, 14, 31, 40, 47, DateTimeKind.Local).AddTicks(8224) });
        }
    }
}
