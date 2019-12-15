﻿// <auto-generated />
using Game.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Game.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20191204072615_GameMigration5")]
    partial class GameMigration5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Game.Models.Games", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("endTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("score")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("startTime")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("teamA")
                        .HasColumnType("int");

                    b.Property<int>("teamB")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            endTime = "05:00",
                            score = " 3 - 1",
                            startTime = "03:00",
                            teamA = 1,
                            teamB = 2
                        });
                });

            modelBuilder.Entity("Game.Models.Players", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Speed")
                        .HasColumnType("int");

                    b.Property<int>("TeamsId")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamsId");

                    b.ToTable("Players");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 23,
                            Height = 184,
                            Name = "Essa",
                            Speed = 26,
                            TeamsId = 1,
                            Weight = 80
                        },
                        new
                        {
                            Id = 2,
                            Age = 20,
                            Height = 180,
                            Name = "Ali",
                            Speed = 30,
                            TeamsId = 2,
                            Weight = 75
                        },
                        new
                        {
                            Id = 3,
                            Age = 25,
                            Height = 178,
                            Name = "Mohammed",
                            Speed = 23,
                            TeamsId = 1,
                            Weight = 85
                        });
                });

            modelBuilder.Entity("Game.Models.Teams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Location = "Riyadh",
                            Name = "Team 1"
                        },
                        new
                        {
                            Id = 2,
                            Location = "Dammam",
                            Name = "Team 2"
                        });
                });

            modelBuilder.Entity("Game.Models.Players", b =>
                {
                    b.HasOne("Game.Models.Teams", "Team")
                        .WithMany()
                        .HasForeignKey("TeamsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
