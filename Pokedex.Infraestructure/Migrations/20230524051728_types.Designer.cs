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
    [Migration("20230524051728_types")]
    partial class types
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Pokedex.Core.Entities.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Heigth")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pokemon_Number")
                        .HasColumnType("int");

                    b.Property<int?>("SpeciesId")
                        .HasColumnType("int");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SpeciesId")
                        .IsUnique()
                        .HasFilter("[SpeciesId] IS NOT NULL");

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
                    b.Property<int>("IdType")
                        .HasColumnType("int");

                    b.Property<int>("IdPokemon")
                        .HasColumnType("int");

                    b.Property<int?>("PokemonId")
                        .HasColumnType("int");

                    b.HasKey("IdType", "IdPokemon");

                    b.HasIndex("PokemonId");

                    b.ToTable("TypesPokemon");
                });

            modelBuilder.Entity("Pokedex.Core.Entities.Pokemon", b =>
                {
                    b.HasOne("Pokedex.Core.Entities.Species", "Species")
                        .WithOne("Pokemon")
                        .HasForeignKey("Pokedex.Core.Entities.Pokemon", "SpeciesId");

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
                    b.HasOne("Pokedex.Core.Entities.Pokemon", null)
                        .WithMany("TypesPokemons")
                        .HasForeignKey("PokemonId");
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
