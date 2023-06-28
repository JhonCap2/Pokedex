using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infraestructure.Data
{
    public partial class DbPokedexContext : DbContext
    {

        public DbPokedexContext()
        { 
        }

        public DbPokedexContext(DbContextOptions<DbPokedexContext> options) : base(options)
        {
        }

        public  DbSet<Pokemon> Pokemon { get; set; }
        public  DbSet<Types> Types { get; set; }
        public  DbSet<Stats> Stats { get; set; }
        public  DbSet<TypesPokemon> TypesPokemon { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Evolutions> Evolutions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Stats>().HasOne(x => x.Pokemon).WithOne(x => x.Stats);
            builder.Entity<TypesPokemon>().HasKey(x => new { x.TypesId, x.PokemonId});
            builder.Entity<Species>().HasMany(x => x.Pokemon).WithOne(x=>x.Species).HasForeignKey(x => x.SpeciesId);
            builder.Entity<Evolutions>().HasMany(x => x.Pokemon).WithOne(x => x.EvolutionFamily);
        }

    }
}
