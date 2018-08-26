﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bot.DataModel;

namespace bot.Migrations
{
    [DbContext(typeof(BotContext))]
    [Migration("20180826102920_ChangePercentageForChangeToDecimal")]
    partial class ChangePercentageForChangeToDecimal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("bot.DataModel.DailyOHLCV", b =>
                {
                    b.Property<string>("BaseCurrency")
                        .HasMaxLength(3);

                    b.Property<string>("QuoteCurrency")
                        .HasMaxLength(3);

                    b.Property<DateTime>("Time");

                    b.Property<decimal>("Close");

                    b.Property<decimal>("High");

                    b.Property<decimal>("Open");

                    b.Property<double>("VolumeFrom");

                    b.Property<double>("VolumeTo");

                    b.HasKey("BaseCurrency", "QuoteCurrency", "Time");

                    b.ToTable("DailyOHLCVs");
                });

            modelBuilder.Entity("bot.DataModel.PercentageOfChangeAction", b =>
                {
                    b.Property<string>("BaseCurrency")
                        .HasMaxLength(3);

                    b.Property<string>("QuoteCurrency")
                        .HasMaxLength(3);

                    b.Property<DateTime>("Time");

                    b.Property<decimal>("Amount");

                    b.Property<int>("TradeAction");

                    b.HasKey("BaseCurrency", "QuoteCurrency", "Time");

                    b.ToTable("PercentageOfChangeActions");
                });

            modelBuilder.Entity("bot.DataModel.PercentageOfChangeConfiguration", b =>
                {
                    b.Property<string>("BaseCurrency")
                        .HasMaxLength(3);

                    b.Property<string>("QuoteCurrency")
                        .HasMaxLength(3);

                    b.Property<DateTime>("Time");

                    b.Property<decimal>("AmountToTrade");

                    b.Property<int>("DaysForChange");

                    b.Property<decimal>("PercentageForChange");

                    b.HasKey("BaseCurrency", "QuoteCurrency", "Time");

                    b.ToTable("PercentageOfChangeConfigurations");
                });

            modelBuilder.Entity("bot.DataModel.PercentageOfChangeTrend", b =>
                {
                    b.Property<string>("BaseCurrency")
                        .HasMaxLength(3);

                    b.Property<string>("QuoteCurrency")
                        .HasMaxLength(3);

                    b.Property<DateTime>("Time");

                    b.Property<int>("DaysTrendingDown");

                    b.Property<int>("DaysTrendingUp");

                    b.Property<int>("DaysWithNoTrend");

                    b.Property<int>("TradeAction");

                    b.HasKey("BaseCurrency", "QuoteCurrency", "Time");

                    b.ToTable("PercentageOfChangeTrends");
                });

            modelBuilder.Entity("bot.DataModel.UnitsOfChangeAction", b =>
                {
                    b.Property<string>("BaseCurrency")
                        .HasMaxLength(3);

                    b.Property<string>("QuoteCurrency")
                        .HasMaxLength(3);

                    b.Property<DateTime>("Time");

                    b.Property<decimal>("Amount");

                    b.Property<int>("TradeAction");

                    b.HasKey("BaseCurrency", "QuoteCurrency", "Time");

                    b.ToTable("UnitsOfChangeActions");
                });

            modelBuilder.Entity("bot.DataModel.UnitsOfChangeConfiguration", b =>
                {
                    b.Property<string>("BaseCurrency")
                        .HasMaxLength(3);

                    b.Property<string>("QuoteCurrency")
                        .HasMaxLength(3);

                    b.Property<DateTime>("Time");

                    b.Property<decimal>("AmountToTrade");

                    b.Property<int>("DaysForChange");

                    b.Property<decimal>("UnitsForChange");

                    b.HasKey("BaseCurrency", "QuoteCurrency", "Time");

                    b.ToTable("UnitsOfChangeConfigurations");
                });

            modelBuilder.Entity("bot.DataModel.UnitsOfChangeTrend", b =>
                {
                    b.Property<string>("BaseCurrency")
                        .HasMaxLength(3);

                    b.Property<string>("QuoteCurrency")
                        .HasMaxLength(3);

                    b.Property<DateTime>("Time");

                    b.Property<int>("DaysTrendingDown");

                    b.Property<int>("DaysTrendingUp");

                    b.Property<int>("DaysWithNoTrend");

                    b.Property<int>("TradeAction");

                    b.HasKey("BaseCurrency", "QuoteCurrency", "Time");

                    b.ToTable("UnitsOfChangeTrends");
                });
#pragma warning restore 612, 618
        }
    }
}