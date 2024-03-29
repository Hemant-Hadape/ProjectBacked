﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aspnetserver.Data;

#nullable disable

namespace aspnetserver.Migrations
{
    [DbContext(typeof(KanbanContext))]
    [Migration("20220519052851_newvm migration")]
    partial class newvmmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("aspnetserver.Data.KanbanTask", b =>
                {
                    b.Property<int>("TId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TId"), 1L, 1);

                    b.Property<string>("AssignBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AssignTo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PId")
                        .HasColumnType("int");

                    b.Property<string>("TaskDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskStatusId")
                        .HasColumnType("int");

                    b.HasKey("TId");

                    b.ToTable("task");
                });

            modelBuilder.Entity("aspnetserver.Data.Project", b =>
                {
                    b.Property<int>("PojectId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PojectId"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("startdate")
                        .HasColumnType("datetime2");

                    b.HasKey("PojectId");

                    b.ToTable("project");
                });

            modelBuilder.Entity("aspnetserver.Data.ProjectMembers", b =>
                {
                    b.Property<int>("project_MId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("project_MId"), 1L, 1);

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<int?>("projectId")
                        .HasColumnType("int");

                    b.HasKey("project_MId");

                    b.ToTable("projectMember");
                });

            modelBuilder.Entity("aspnetserver.Data.Reportcs", b =>
                {
                    b.Property<int?>("RId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("RId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PId")
                        .HasColumnType("int");

                    b.Property<int>("PIdNavigationPojectId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReportedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("TaskDetails")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Taskstatus")
                        .HasColumnType("int");

                    b.Property<string>("WhatAction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RId");

                    b.HasIndex("PIdNavigationPojectId");

                    b.ToTable("reports");
                });

            modelBuilder.Entity("aspnetserver.Data.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StatusId"), 1L, 1);

                    b.Property<string>("StatusDetails")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StatusId");

                    b.ToTable("status");
                });

            modelBuilder.Entity("aspnetserver.Data.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("aspnetserver.Data.Reportcs", b =>
                {
                    b.HasOne("aspnetserver.Data.Project", "PIdNavigation")
                        .WithMany()
                        .HasForeignKey("PIdNavigationPojectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PIdNavigation");
                });
#pragma warning restore 612, 618
        }
    }
}
