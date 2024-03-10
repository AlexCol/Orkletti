﻿// <auto-generated />
using System;
using AUTENTICADOR.src.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backendOrkletti.Migrations
{
    [DbContext(typeof(PostgreContext))]
    partial class PostgreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("backendOrkletti.src.Model.Entity.Profile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Bio")
                        .HasColumnType("text")
                        .HasColumnName("ds_bio");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("ds_fistname");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("ds_lastname");

                    b.Property<byte[]>("ProfileImage")
                        .HasColumnType("bytea")
                        .HasColumnName("bl_profileimage");

                    b.HasKey("Id");

                    b.ToTable("profile");
                });
#pragma warning restore 612, 618
        }
    }
}
