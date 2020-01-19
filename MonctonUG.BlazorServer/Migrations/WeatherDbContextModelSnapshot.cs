﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MonctonUG.BlazorServer.Data;

namespace MonctonUG.BlazorServer.Migrations
{
    [DbContext(typeof(WeatherDbContext))]
    partial class WeatherDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("MonctonUG.BlazorServer.Data.WeatherForecast", b =>
                {
                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Summary")
                        .HasColumnType("TEXT");

                    b.Property<int>("TemperatureC")
                        .HasColumnType("INTEGER");

                    b.HasKey("Date");

                    b.ToTable("WeatherForecasts");

                    b.HasData(
                        new
                        {
                            Date = new DateTime(2020, 1, 18, 21, 29, 20, 659, DateTimeKind.Local).AddTicks(470),
                            Summary = "Cold",
                            TemperatureC = -10
                        },
                        new
                        {
                            Date = new DateTime(2020, 1, 19, 21, 29, 20, 664, DateTimeKind.Local).AddTicks(1065),
                            Summary = "Warm",
                            TemperatureC = 25
                        },
                        new
                        {
                            Date = new DateTime(2020, 1, 20, 21, 29, 20, 664, DateTimeKind.Local).AddTicks(1230),
                            Summary = "Unbearably hot",
                            TemperatureC = 40
                        },
                        new
                        {
                            Date = new DateTime(2020, 1, 21, 21, 29, 20, 664, DateTimeKind.Local).AddTicks(1241),
                            Summary = "Deathly cold",
                            TemperatureC = -60
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
