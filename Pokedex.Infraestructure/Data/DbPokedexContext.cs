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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Stats>().HasOne(x => x.Pokemon).WithOne(x => x.Stats);
            builder.Entity<TypesPokemon>().HasKey(x => new { x.IdType, x.IdPokemon});
            builder.Entity<Species>().HasOne(x => x.Pokemon).WithOne(x=>x.Species);
        }

    }
}
