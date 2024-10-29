﻿// <auto-generated />
using BasicCRUD.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BasicCRUD.Migrations
{
    [DbContext(typeof(GamerContext))]
    partial class GamerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BasicCRUD.Models.Gamer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FavouriteGame")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gamers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 32,
                            FavouriteGame = "Metaphor Re:Fantazio",
                            Name = "BladeRED"
                        },
                        new
                        {
                            Id = 2,
                            Age = 26,
                            FavouriteGame = "Légendes Pokémon: Arceus",
                            Name = "Eurons"
                        },
                        new
                        {
                            Id = 3,
                            Age = 33,
                            FavouriteGame = "Octopath Traveler 2",
                            Name = "Katsuki"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
