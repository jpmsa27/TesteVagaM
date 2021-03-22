using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class quartamigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ToDoCategorias",
                columns: table => new
                {
                    atividade_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    atividade_Nome = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoCategorias", x => x.atividade_Id);
                });

            migrationBuilder.CreateTable(
                name: "ToDoLista",
                columns: table => new
                {
                    lista_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lista_Nome = table.Column<string>(type: "varchar(100)", nullable: true),
                    lista_CategoriaId = table.Column<int>(type: "int", nullable: false),
                    lista_Concluida = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ToDoLista", x => x.lista_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ToDoCategorias");

            migrationBuilder.DropTable(
                name: "ToDoLista");
        }
    }
}
