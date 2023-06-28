using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pokedex.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class adding_order_to_typesPokemon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "TypesPokemon",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "TypesPokemon");
        }
    }
}
