using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class m1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventoID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Local = table.Column<string>(nullable: true),
                    Visitante = table.Column<string>(nullable: true),
                    Goles = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventoID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Edad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioID);
                });

            migrationBuilder.CreateTable(
                name: "Mercados",
                columns: table => new
                {
                    MercadoID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Over_under = table.Column<double>(nullable: false),
                    Cuota_over = table.Column<double>(nullable: false),
                    Cuota_under = table.Column<double>(nullable: false),
                    Dinero_over = table.Column<double>(nullable: false),
                    Dinero_under = table.Column<double>(nullable: false),
                    EventoID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mercados", x => x.MercadoID);
                    table.ForeignKey(
                        name: "FK_Mercados_Eventos_EventoID",
                        column: x => x.EventoID,
                        principalTable: "Eventos",
                        principalColumn: "EventoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cuenta",
                columns: table => new
                {
                    CuentaID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreBanco = table.Column<string>(nullable: true),
                    NumeroTarjeta = table.Column<string>(nullable: true),
                    SaldoActual = table.Column<int>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cuenta", x => x.CuentaID);
                    table.ForeignKey(
                        name: "FK_Cuenta_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Apuestas",
                columns: table => new
                {
                    ApuestaID = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EventoID = table.Column<int>(nullable: false),
                    MercadoID = table.Column<int>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: false),
                    Tipo_apuesta = table.Column<int>(nullable: false),
                    Cuota = table.Column<double>(nullable: false),
                    Dinero_apostado = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apuestas", x => x.ApuestaID);
                    table.ForeignKey(
                        name: "FK_Apuestas_Mercados_MercadoID",
                        column: x => x.MercadoID,
                        principalTable: "Mercados",
                        principalColumn: "MercadoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Apuestas_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Eventos",
                columns: new[] { "EventoID", "Goles", "Local", "Visitante" },
                values: new object[,]
                {
                    { 1, 2, "Madrid", "Barcelona" },
                    { 2, 2, "Valencia", "Betis" },
                    { 3, 3, "Sevilla", "Deportivo" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioID", "Apellido", "Edad", "Email", "Nombre" },
                values: new object[,]
                {
                    { 1, "garcia", 21, "paco@gmail.com", "paco" },
                    { 2, "fernandez", 27, "pepe@gmail.com", "pepe" },
                    { 3, "martinez", 32, "pedro@gmail.com", "pedro" }
                });

            migrationBuilder.InsertData(
                table: "Mercados",
                columns: new[] { "MercadoID", "Cuota_over", "Cuota_under", "Dinero_over", "Dinero_under", "EventoID", "Over_under" },
                values: new object[] { 1, 1.4299999999999999, 2.8500000000000001, 100.0, 50.0, 1, 1.5 });

            migrationBuilder.InsertData(
                table: "Mercados",
                columns: new[] { "MercadoID", "Cuota_over", "Cuota_under", "Dinero_over", "Dinero_under", "EventoID", "Over_under" },
                values: new object[] { 2, 1.8999999999999999, 1.8999999999999999, 100.0, 100.0, 2, 2.5 });

            migrationBuilder.InsertData(
                table: "Mercados",
                columns: new[] { "MercadoID", "Cuota_over", "Cuota_under", "Dinero_over", "Dinero_under", "EventoID", "Over_under" },
                values: new object[] { 3, 2.8500000000000001, 1.4299999999999999, 50.0, 100.0, 3, 3.5 });

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "ApuestaID", "Cuota", "Dinero_apostado", "EventoID", "MercadoID", "Tipo_apuesta", "UsuarioID" },
                values: new object[] { 3, 3.5, 150.0, 2, 1, 1, 3 });

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "ApuestaID", "Cuota", "Dinero_apostado", "EventoID", "MercadoID", "Tipo_apuesta", "UsuarioID" },
                values: new object[] { 1, 2.5, 50.0, 1, 2, 1, 1 });

            migrationBuilder.InsertData(
                table: "Apuestas",
                columns: new[] { "ApuestaID", "Cuota", "Dinero_apostado", "EventoID", "MercadoID", "Tipo_apuesta", "UsuarioID" },
                values: new object[] { 2, 1.5, 100.0, 3, 3, 0, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Apuestas_MercadoID",
                table: "Apuestas",
                column: "MercadoID");

            migrationBuilder.CreateIndex(
                name: "IX_Apuestas_UsuarioID",
                table: "Apuestas",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Cuenta_UsuarioID",
                table: "Cuenta",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Mercados_EventoID",
                table: "Mercados",
                column: "EventoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Apuestas");

            migrationBuilder.DropTable(
                name: "Cuenta");

            migrationBuilder.DropTable(
                name: "Mercados");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Eventos");
        }
    }
}
