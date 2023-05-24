using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokedex.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class changing_TypesPokemonClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypesPokemon_Pokemon_PokemonId",
                table: "TypesPokemon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypesPokemon",
                table: "TypesPokemon");

            migrationBuilder.DropColumn(
                name: "IdType",
                table: "TypesPokemon");

            migrationBuilder.RenameColumn(
                name: "IdPokemon",
                table: "TypesPokemon",
                newName: "TypesId");

            migrationBuilder.AlterColumn<int>(
                name: "PokemonId",
                table: "TypesPokemon",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypesPokemon",
                table: "TypesPokemon",
                columns: new[] { "TypesId", "PokemonId" });

            migrationBuilder.AddForeignKey(
                name: "FK_TypesPokemon_Pokemon_PokemonId",
                table: "TypesPokemon",
                column: "PokemonId",
                principalTable: "Pokemon",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TypesPokemon_Types_TypesId",
                table: "TypesPokemon",
                column: "TypesId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TypesPokemon_Pokemon_PokemonId",
                table: "TypesPokemon");

            migrationBuilder.DropForeignKey(
                name: "FK_TypesPokemon_Types_TypesId",
                table: "TypesPokemon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypesPokemon",
                table: "TypesPokemon");

            migrationBuilder.RenameColumn(
                name: "TypesId",
                table: "TypesPokemon",
                newName: "IdPokemon");

            migrationBuilder.AlterColumn<int>(
                name: "PokemonId",
                table: "TypesPokemon",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdType",
                table: "TypesPokemon",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypesPokemon",
                table: "TypesPokemon",
                columns: new[] { "IdType", "IdPokemon" });

            migrationBuilder.AddForeignKey(
                name: "FK_TypesPokemon_Pokemon_PokemonId",
                table: "TypesPokemon",
                column: "PokemonId",
                principalTable: "Pokemon",
                principalColumn: "Id");
        }
    }
}
