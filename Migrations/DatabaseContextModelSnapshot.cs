﻿// <auto-generated />
using System;
using Game.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Game.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime>("endTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("score")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("startTime")
                        .HasColumnType("datetime2");

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
                            endTime = new DateTime(2019, 12, 12, 15, 18, 28, 486, DateTimeKind.Local).AddTicks(1430),
                            score = " 3 - 1",
                            startTime = new DateTime(2019, 12, 11, 13, 18, 28, 482, DateTimeKind.Local).AddTicks(6588),
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
                        .IsRequired()
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
