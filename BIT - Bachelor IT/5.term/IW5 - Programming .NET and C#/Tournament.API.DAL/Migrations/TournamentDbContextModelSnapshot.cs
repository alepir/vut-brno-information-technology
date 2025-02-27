﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tournament.API.DAL.Database;

#nullable disable

namespace Tournament.API.DAL.Migrations
{
    [DbContext(typeof(TournamentDbContext))]
    partial class TournamentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0-rc.2.21480.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Tournament.API.DAL.Entities.GameEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("End")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Start")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TeamBlueId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TeamBluePoints")
                        .HasColumnType("int");

                    b.Property<Guid>("TeamRedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("TeamRedPoints")
                        .HasColumnType("int");

                    b.Property<Guid>("TournamentVenueId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TeamBlueId");

                    b.HasIndex("TeamRedId");

                    b.HasIndex("TournamentVenueId");

                    b.ToTable("Games", (string)null);
                });

            modelBuilder.Entity("Tournament.API.DAL.Entities.PlayerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TeamEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TeamEntityId");

                    b.ToTable("Players", (string)null);
                });

            modelBuilder.Entity("Tournament.API.DAL.Entities.TeamEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teams", (string)null);
                });

            modelBuilder.Entity("Tournament.API.DAL.Entities.TournamentVenueEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TournamentVenues", (string)null);
                });

            modelBuilder.Entity("Tournament.API.DAL.Entities.GameEntity", b =>
                {
                    b.HasOne("Tournament.API.DAL.Entities.TeamEntity", "TeamBlue")
                        .WithMany("TeamBlueGames")
                        .HasForeignKey("TeamBlueId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Tournament.API.DAL.Entities.TeamEntity", "TeamRed")
                        .WithMany("TeamRedGames")
                        .HasForeignKey("TeamRedId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Tournament.API.DAL.Entities.TournamentVenueEntity", "TournamentVenue")
                        .WithMany("Games")
                        .HasForeignKey("TournamentVenueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TeamBlue");

                    b.Navigation("TeamRed");

                    b.Navigation("TournamentVenue");
                });

            modelBuilder.Entity("Tournament.API.DAL.Entities.PlayerEntity", b =>
                {
                    b.HasOne("Tournament.API.DAL.Entities.TeamEntity", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("Tournament.API.DAL.Entities.TeamEntity", b =>
                {
                    b.Navigation("Players");

                    b.Navigation("TeamBlueGames");

                    b.Navigation("TeamRedGames");
                });

            modelBuilder.Entity("Tournament.API.DAL.Entities.TournamentVenueEntity", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
