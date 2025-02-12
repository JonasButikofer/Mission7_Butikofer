﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Mission6Movies.Models;

#nullable disable

namespace Mission6Movies.Migrations
{
    [DbContext(typeof(FilmApplicationContext))]
    [Migration("20250212022911_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("Mission6Movies.Models.FormModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("Edited")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lent")
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Notes")
                        .HasMaxLength(25)
                        .HasColumnType("TEXT");

                    b.Property<string>("Rating")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Films");
                });
#pragma warning restore 612, 618
        }
    }
}
