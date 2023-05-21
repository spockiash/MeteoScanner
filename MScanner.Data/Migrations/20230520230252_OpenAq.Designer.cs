﻿// <auto-generated />
using System;
using MScanner.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MScanner.Data.Migrations
{
    [DbContext(typeof(MeteoScannerContext))]
    [Migration("20230520230252_OpenAq")]
    partial class OpenAq
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("MScanner.Data.Entities.RequestPresets.OpenAqRequestPreset", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApiService")
                        .HasColumnType("INTEGER");

                    b.Property<string>("City")
                        .HasColumnType("TEXT");

                    b.Property<string>("CountryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Limit")
                        .HasColumnType("TEXT");

                    b.Property<string>("Offset")
                        .HasColumnType("TEXT");

                    b.Property<string>("Page")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sort")
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlHost")
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlPath")
                        .HasColumnType("TEXT");

                    b.Property<string>("UrlQuery")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("OpenAqPresets", (string)null);
                });

            modelBuilder.Entity("MScanner.Data.Entities.SensorDataEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("AirQuality")
                        .HasColumnType("REAL");

                    b.Property<double>("Humidity")
                        .HasColumnType("REAL");

                    b.Property<double>("Temperature")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("TimeStamp")
                        .HasColumnType("TEXT");

                    b.Property<double>("UVIntensity")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("SensorData", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
