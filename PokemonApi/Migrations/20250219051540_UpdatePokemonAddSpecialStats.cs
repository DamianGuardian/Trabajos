using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PokemonApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePokemonAddSpecialStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpecialAttack",
                table: "Pokemons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpecialDefense",
                table: "Pokemons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecialAttack",
                table: "Pokemons");

            migrationBuilder.DropColumn(
                name: "SpecialDefense",
                table: "Pokemons");
        }
    }
}
