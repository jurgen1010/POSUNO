﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POSUNO.Api.Data;

namespace POSUNO.Api.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210716172807_InitialDb")]
    partial class InitialDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("POSUNO.Api.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("int");

                    b.Property<int>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("POSUNO.Api.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Email")
                        .HasColumnType("int");

                    b.Property<int>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<int>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<int>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("POSUNO.Api.Data.Entities.Product", b =>
                {
                    b.HasOne("POSUNO.Api.Data.Entities.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("POSUNO.Api.Data.Entities.User", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
