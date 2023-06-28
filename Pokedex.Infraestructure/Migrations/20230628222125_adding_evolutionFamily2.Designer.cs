﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Pokedex.Infraestructure.Data;

#nullable disable

namespace Pokedex.Infraestructure.Migrations
{
    [DbContext(typeof(DbPokedexContext))]
    [Migration("20230628222125_adding_evolutionFamily2")]
    partial class adding_evolutionFamily2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pokedex.Core.Entities.Evolutions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PokemonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Evolutions");
                });

            modelBuilder.Entity("Pokedex.Core.Entities.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EvolutionFamilyId")
                        .HasColumnType("int");

                    b.Property<string>("Heigth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrderEvolution")
                        .HasColumnType("int");

                    b.Property<int>("Pokemon_Number")
                        .HasColumnType("int");

                    b.Property<int?>("SpeciesId")
                        .HasColumnType("int");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EvolutionFamilyId");

                    b.HasIndex("SpeciesId");

                    b.ToTable("Pokemon");
                });

            modelBuilder.Entity("Pokedex.Core.Entities.Species", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Species");
                });

            modelBuilder.Entity("Pokedex.Core.Entities.Stats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<int>("Defense")
                        .HasColumnType("int");

                    b.Property<int>("HP")
                        .HasColumnType("int");

                    b.Property<int>("PokemonId")
                        .HasColumnType("int");

                    b.Property<int>("Special_Attack")
                        .HasColumnType("int");

                    b.Property<int>("Special_Defense")
                        .HasColumnType("int");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId")
                        .IsUnique();

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("Pokedex.Core.Entities.Types", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("Pokedex.Core.Entities.TypesPokemon", b =>
                {
                    b.Property<int>("TypesId")
                        .HasColumnType("int");

                    b.Property<int>("PokemonId")
                        .HasColumnType("int");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.HasKey("TypesId", "PokemonId");

                    b.HasIndex("PokemonId");

                    b.ToTable("TypesPokemon");
                });

            modelBuilder.Entity("Pokedex.Core.Entities.Pokemon", b =>
                {
                    b.HasOne("Pokedex.Core.Entities.Evolutions", "EvolutionFamily")
                        .WithMany("Pokemon")
                        .HasForeignKey("EvolutionFamilyId");

                    b.HasOne("Pokedex.Core.Entities.Species", "Species")
                        .WithMany("Pokemon")
                        .HasForeignKey("SpeciesId");

                    b.Navigation("EvolutionFamily");

                    b.Navigation("Species");
                });

            modelBuilder.Entity("Pokedex.Core.Entities.Stats", b =>
                {
                    b.HasOne("Pokedex.Core.Entities.Pokemon", "Pokemon")
                        .WithOne("Stats")
                        .HasForeignKey("Pokedex.Core.Entities.Stats", "PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("Pokedex.Core.Entities.TypesPokemon", b =>
                {
                    b.HasOne("Pokedex.Core.Entities.Pokemon", "Pokemon")
                        .WithMany("TypesPokemons")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Pokedex.Core.Entities.Types", "Types")
                        .WithMany()
                        .HasForeignKey("TypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");

                    b.Navigation("Types");
                });

            modelBuilder.Entity("Pokedex.Core.Entities.Evolutions", b =>
                {
                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("Pokedex.Core.Entities.Pokemon", b =>
                {
                    b.Navigation("Stats");

                    b.Navigation("TypesPokemons");
                });

            modelBuilder.Entity("Pokedex.Core.Entities.Species", b =>
                {
                    b.Navigation("Pokemon");
                });
#pragma warning restore 612, 618
        }
    }
}
