﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RugbyDataApi.Data;

#nullable disable

namespace RugbyDataApi.Migrations
{
    [DbContext(typeof(RugbyDataDbContext))]
    [Migration("20240130174024_AddRugbyData")]
    partial class AddRugbyData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("RugbyDataApi.Models.Competition", b =>
                {
                    b.Property<int>("CompetitionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CompetitionName")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("SrCompetitionId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Year")
                        .HasColumnType("TEXT");

                    b.HasKey("CompetitionId");

                    b.ToTable("Competitions");
                });

            modelBuilder.Entity("RugbyDataApi.Models.Fixture", b =>
                {
                    b.Property<int>("FixtureId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AwayScore")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompetitionId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HomeScore")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RoundNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SrSportEventId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Status")
                        .HasColumnType("TEXT");

                    b.HasKey("FixtureId");

                    b.HasIndex("CompetitionId");

                    b.ToTable("Fixtures");
                });

            modelBuilder.Entity("RugbyDataApi.Models.Player", b =>
                {
                    b.Property<int>("PlayerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateOnly?>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nationality")
                        .HasColumnType("TEXT");

                    b.Property<string>("SrPlayerId")
                        .HasColumnType("TEXT");

                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlayerId");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("RugbyDataApi.Models.PlayerLineup", b =>
                {
                    b.Property<int>("PlayerLineupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("JerseyNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SrPlayerId")
                        .HasColumnType("TEXT");

                    b.Property<int>("TeamLineupId")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlayerLineupId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TeamLineupId");

                    b.ToTable("PlayerLineups");
                });

            modelBuilder.Entity("RugbyDataApi.Models.PlayerStatistics", b =>
                {
                    b.Property<int>("PlayerStatisticsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Carries")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CleanBreaks")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Conversions")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("DropGoals")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FixtureId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LineoutsLost")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("LineoutsWon")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("MetersRun")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Offloads")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Passes")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PenaltiesConceded")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PenaltyGoals")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PlayerId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("RedCards")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ScrumsLost")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ScrumsWon")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Tackles")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TacklesMissed")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TotalScrums")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Tries")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TryAssists")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("TurnoversWon")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("YellowCards")
                        .HasColumnType("INTEGER");

                    b.HasKey("PlayerStatisticsId");

                    b.HasIndex("FixtureId");

                    b.HasIndex("PlayerId");

                    b.ToTable("PlayersStatistics");
                });

            modelBuilder.Entity("RugbyDataApi.Models.Team", b =>
                {
                    b.Property<int>("TeamId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("SrCompetitorId")
                        .HasColumnType("TEXT");

                    b.Property<string>("TeamName")
                        .HasColumnType("TEXT");

                    b.HasKey("TeamId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("RugbyDataApi.Models.TeamLineup", b =>
                {
                    b.Property<int>("TeamLineupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Designation")
                        .HasColumnType("TEXT");

                    b.Property<int>("FixtureId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TeamId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TeamLineupId");

                    b.HasIndex("FixtureId");

                    b.HasIndex("TeamId");

                    b.ToTable("TeamLineups");
                });

            modelBuilder.Entity("RugbyDataApi.Models.Fixture", b =>
                {
                    b.HasOne("RugbyDataApi.Models.Competition", "Competition")
                        .WithMany("Fixtures")
                        .HasForeignKey("CompetitionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Competition");
                });

            modelBuilder.Entity("RugbyDataApi.Models.Player", b =>
                {
                    b.HasOne("RugbyDataApi.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("RugbyDataApi.Models.PlayerLineup", b =>
                {
                    b.HasOne("RugbyDataApi.Models.Player", "Player")
                        .WithMany("PlayerLineups")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RugbyDataApi.Models.TeamLineup", "TeamLineup")
                        .WithMany("PlayerLineups")
                        .HasForeignKey("TeamLineupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Player");

                    b.Navigation("TeamLineup");
                });

            modelBuilder.Entity("RugbyDataApi.Models.PlayerStatistics", b =>
                {
                    b.HasOne("RugbyDataApi.Models.Fixture", "Fixture")
                        .WithMany("PlayersStatistics")
                        .HasForeignKey("FixtureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RugbyDataApi.Models.Player", "Player")
                        .WithMany("PlayersStatistics")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fixture");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("RugbyDataApi.Models.TeamLineup", b =>
                {
                    b.HasOne("RugbyDataApi.Models.Fixture", "Fixture")
                        .WithMany("TeamLineups")
                        .HasForeignKey("FixtureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RugbyDataApi.Models.Team", "Team")
                        .WithMany("TeamLineups")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fixture");

                    b.Navigation("Team");
                });

            modelBuilder.Entity("RugbyDataApi.Models.Competition", b =>
                {
                    b.Navigation("Fixtures");
                });

            modelBuilder.Entity("RugbyDataApi.Models.Fixture", b =>
                {
                    b.Navigation("PlayersStatistics");

                    b.Navigation("TeamLineups");
                });

            modelBuilder.Entity("RugbyDataApi.Models.Player", b =>
                {
                    b.Navigation("PlayerLineups");

                    b.Navigation("PlayersStatistics");
                });

            modelBuilder.Entity("RugbyDataApi.Models.Team", b =>
                {
                    b.Navigation("Players");

                    b.Navigation("TeamLineups");
                });

            modelBuilder.Entity("RugbyDataApi.Models.TeamLineup", b =>
                {
                    b.Navigation("PlayerLineups");
                });
#pragma warning restore 612, 618
        }
    }
}
