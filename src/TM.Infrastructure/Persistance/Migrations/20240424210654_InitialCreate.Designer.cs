﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TM.Infrastructure.Persistance;

#nullable disable

namespace TM.Infrastructure.Persistance.Migrations
{
    [DbContext(typeof(TradeManagementDbContext))]
    [Migration("20240424210654_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FactorSetup", b =>
                {
                    b.Property<Guid>("FactorsID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SetupsID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FactorsID", "SetupsID");

                    b.HasIndex("SetupsID");

                    b.ToTable("FactorSetup");
                });

            modelBuilder.Entity("FactorTrade", b =>
                {
                    b.Property<Guid>("FactorsID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TradesID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FactorsID", "TradesID");

                    b.HasIndex("TradesID");

                    b.ToTable("FactorTrade");
                });

            modelBuilder.Entity("TM.Domain.Entities.Factor", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Factors");
                });

            modelBuilder.Entity("TM.Domain.Entities.Pair", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Pairs");
                });

            modelBuilder.Entity("TM.Domain.Entities.Setup", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Setups");
                });

            modelBuilder.Entity("TM.Domain.Entities.Trade", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("BudgetRisk")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DirectionType")
                        .HasColumnType("int");

                    b.Property<Guid>("PairID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PositionType")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Profit")
                        .HasColumnType("float");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("ResultType")
                        .HasColumnType("int");

                    b.Property<double>("RiskRevardRatio")
                        .HasColumnType("float");

                    b.Property<Guid?>("SetupID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("PairID");

                    b.HasIndex("SetupID");

                    b.ToTable("Trades");
                });

            modelBuilder.Entity("FactorSetup", b =>
                {
                    b.HasOne("TM.Domain.Entities.Factor", null)
                        .WithMany()
                        .HasForeignKey("FactorsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TM.Domain.Entities.Setup", null)
                        .WithMany()
                        .HasForeignKey("SetupsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FactorTrade", b =>
                {
                    b.HasOne("TM.Domain.Entities.Factor", null)
                        .WithMany()
                        .HasForeignKey("FactorsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TM.Domain.Entities.Trade", null)
                        .WithMany()
                        .HasForeignKey("TradesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TM.Domain.Entities.Trade", b =>
                {
                    b.HasOne("TM.Domain.Entities.Pair", "Pair")
                        .WithMany("Trades")
                        .HasForeignKey("PairID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TM.Domain.Entities.Setup", "Setup")
                        .WithMany()
                        .HasForeignKey("SetupID");

                    b.Navigation("Pair");

                    b.Navigation("Setup");
                });

            modelBuilder.Entity("TM.Domain.Entities.Pair", b =>
                {
                    b.Navigation("Trades");
                });
#pragma warning restore 612, 618
        }
    }
}
