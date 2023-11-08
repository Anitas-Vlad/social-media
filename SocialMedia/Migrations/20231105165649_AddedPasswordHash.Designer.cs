﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialMedia.Context;

#nullable disable

namespace SocialMedia.Migrations
{
    [DbContext(typeof(SocialMediaContext))]
    [Migration("20231105165649_AddedPasswordHash")]
    partial class AddedPasswordHash
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SocialMedia.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1000,
                            Email = "a@a.a",
                            PasswordHash = "AAAAAA",
                            UserName = "AAAAA"
                        },
                        new
                        {
                            Id = 1001,
                            Email = "b@b.b",
                            PasswordHash = "BBBBB",
                            UserName = "BBBBB"
                        },
                        new
                        {
                            Id = 1002,
                            Email = "c@c.c",
                            PasswordHash = "CCCCC",
                            UserName = "CCCCC"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}