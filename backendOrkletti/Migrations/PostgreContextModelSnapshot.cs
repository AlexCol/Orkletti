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

            modelBuilder.Entity("backendOrkletti.src.Model.Entity.Community", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("cd_community");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("dt_created_at");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text")
                        .HasColumnName("cd_created_by");

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("ds_description");

                    b.Property<byte[]>("Image")
                        .HasColumnType("bytea")
                        .HasColumnName("bl_image");

                    b.Property<string>("Tittle")
                        .HasColumnType("text")
                        .HasColumnName("ds_title");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("community");
                });

            modelBuilder.Entity("backendOrkletti.src.Model.Entity.Post", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("cd_post");

                    b.Property<byte[]>("Attachment")
                        .HasColumnType("bytea")
                        .HasColumnName("bl_post_attachment");

                    b.Property<string>("Body")
                        .HasColumnType("text")
                        .HasColumnName("ds_post_body");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("dt_created_at");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text")
                        .HasColumnName("cd_created_by");

                    b.Property<int>("Dislikes")
                        .HasColumnType("integer")
                        .HasColumnName("nr_dislikes");

                    b.Property<int>("Likes")
                        .HasColumnType("integer")
                        .HasColumnName("nr_likes");

                    b.Property<string>("ProfileId")
                        .HasColumnType("text")
                        .HasColumnName("cd_profile");

                    b.Property<Guid?>("TopicId")
                        .HasColumnType("uuid")
                        .HasColumnName("cd_topic");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.HasIndex("ProfileId");

                    b.HasIndex("TopicId");

                    b.ToTable("post");
                });

            modelBuilder.Entity("backendOrkletti.src.Model.Entity.Profile", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("cd_profile");

                    b.Property<string>("Bio")
                        .HasColumnType("text")
                        .HasColumnName("ds_bio");

                    b.Property<string>("FirstName")
                        .HasColumnType("text")
                        .HasColumnName("ds_fist_name");

                    b.Property<string>("LastName")
                        .HasColumnType("text")
                        .HasColumnName("ds_last_name");

                    b.Property<byte[]>("ProfileImage")
                        .HasColumnType("bytea")
                        .HasColumnName("bl_profile_image");

                    b.HasKey("Id");

                    b.ToTable("profile");
                });

            modelBuilder.Entity("backendOrkletti.src.Model.Entity.Topic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("cd_topic");

                    b.Property<Guid?>("CommunityId")
                        .HasColumnType("uuid")
                        .HasColumnName("cd_community");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("dt_created_at");

                    b.Property<string>("CreatedById")
                        .HasColumnType("text")
                        .HasColumnName("cd_created_by");

                    b.Property<string>("Tittle")
                        .HasColumnType("text")
                        .HasColumnName("ds_title");

                    b.HasKey("Id");

                    b.HasIndex("CommunityId");

                    b.HasIndex("CreatedById");

                    b.ToTable("topic");
                });

            modelBuilder.Entity("backendOrkletti.src.Model.Entity.Community", b =>
                {
                    b.HasOne("backendOrkletti.src.Model.Entity.Profile", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("backendOrkletti.src.Model.Entity.Post", b =>
                {
                    b.HasOne("backendOrkletti.src.Model.Entity.Profile", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("backendOrkletti.src.Model.Entity.Profile", "Profile")
                        .WithMany()
                        .HasForeignKey("ProfileId");

                    b.HasOne("backendOrkletti.src.Model.Entity.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("CreatedBy");

                    b.Navigation("Profile");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("backendOrkletti.src.Model.Entity.Topic", b =>
                {
                    b.HasOne("backendOrkletti.src.Model.Entity.Community", "Community")
                        .WithMany()
                        .HasForeignKey("CommunityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("backendOrkletti.src.Model.Entity.Profile", "CreatedBy")
                        .WithMany()
                        .HasForeignKey("CreatedById");

                    b.Navigation("Community");

                    b.Navigation("CreatedBy");
                });
#pragma warning restore 612, 618
        }
    }
}
