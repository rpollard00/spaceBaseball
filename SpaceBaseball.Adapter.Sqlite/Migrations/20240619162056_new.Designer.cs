﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpaceBaseball.Adapter.Sqlite;

#nullable disable

namespace SpaceBaseball.Adapter.Sqlite.Migrations
{
    [DbContext(typeof(BaseballDbContext))]
    [Migration("20240619162056_new")]
    partial class @new
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.5");

            modelBuilder.Entity("SpaceBaseball.Core.Models.AbilityScores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Charisma")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Constitution")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Dexterity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Intelligence")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Strength")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Wisdom")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("AbilityScores");
                });

            modelBuilder.Entity("SpaceBaseball.Core.Models.BullpenEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RosterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("RosterId");

                    b.ToTable("BullpenEntry");
                });

            modelBuilder.Entity("SpaceBaseball.Core.Models.Player", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AbilityScoresId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Fielding")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("HitChance")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AbilityScoresId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("SpaceBaseball.Core.Models.PositionPlayerEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RosterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("RosterId");

                    b.ToTable("PositionPlayerEntry");
                });

            modelBuilder.Entity("SpaceBaseball.Core.Models.PositionsEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Rating")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.ToTable("PositionsEntry");
                });

            modelBuilder.Entity("SpaceBaseball.Core.Models.Roster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Roster");
                });

            modelBuilder.Entity("SpaceBaseball.Core.Models.StartingRotationEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Rank")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("RosterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlayerId");

                    b.HasIndex("RosterId");

                    b.ToTable("StartingRotationEntry");
                });

            modelBuilder.Entity("SpaceBaseball.Core.Models.Team", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ballpark")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RosterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RosterId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("SpaceBaseball.Core.Models.BullpenEntry", b =>
                {
                    b.HasOne("SpaceBaseball.Core.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpaceBaseball.Core.Models.Roster", null)
                        .WithMany("Bullpen")
                        .HasForeignKey("RosterId");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("SpaceBaseball.Core.Models.Player", b =>
                {
                    b.HasOne("SpaceBaseball.Core.Models.AbilityScores", "AbilityScores")
                        .WithMany()
                        .HasForeignKey("AbilityScoresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AbilityScores");
                });

            modelBuilder.Entity("SpaceBaseball.Core.Models.PositionPlayerEntry", b =>
                {
                    b.HasOne("SpaceBaseball.Core.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpaceBaseball.Core.Models.Roster", null)
                        .WithMany("PositionPlayers")
                        .HasForeignKey("RosterId");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("SpaceBaseball.Core.Models.PositionsEntry", b =>
                {
                    b.HasOne("SpaceBaseball.Core.Models.Player", null)
                        .WithMany("Positions")
                        .HasForeignKey("PlayerId");
                });

            modelBuilder.Entity("SpaceBaseball.Core.Models.StartingRotationEntry", b =>
                {
                    b.HasOne("SpaceBaseball.Core.Models.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SpaceBaseball.Core.Models.Roster", null)
                        .WithMany("StartingRotation")
                        .HasForeignKey("RosterId");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("SpaceBaseball.Core.Models.Team", b =>
                {
                    b.HasOne("SpaceBaseball.Core.Models.Roster", "Roster")
                        .WithMany()
                        .HasForeignKey("RosterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Roster");
                });

            modelBuilder.Entity("SpaceBaseball.Core.Models.Player", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("SpaceBaseball.Core.Models.Roster", b =>
                {
                    b.Navigation("Bullpen");

                    b.Navigation("PositionPlayers");

                    b.Navigation("StartingRotation");
                });
#pragma warning restore 612, 618
        }
    }
}