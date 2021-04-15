﻿// <auto-generated />
using System;
using FTeam.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataLayer.Migrations.FIdentityNpanel
{
    [DbContext(typeof(FIdentityNpanelContext))]
    partial class FIdentityNpanelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "6.0.0-preview.2.21154.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FTeam.Entity.Applications.Applications", b =>
                {
                    b.Property<Guid>("ApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApplicationEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationIcon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsConfirm")
                        .HasColumnType("bit");

                    b.HasKey("ApplicationId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("FTeam.Entity.Sessions.ApplicationSessions", b =>
                {
                    b.Property<int>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationsApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SetDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SessionId");

                    b.HasIndex("ApplicationsApplicationId");

                    b.ToTable("ApplicationSessions");
                });

            modelBuilder.Entity("FTeam.EntityNpanel.ManyToMany.RoleAccessPages", b =>
                {
                    b.Property<int>("RoleAccessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("PageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PagesPageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RolesRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("RoleAccessId");

                    b.HasIndex("PagesPageId");

                    b.HasIndex("RolesRoleId");

                    b.ToTable("RoleAccessPages");
                });

            modelBuilder.Entity("FTeam.EntityNpanel.ManyToMany.UserApplications", b =>
                {
                    b.Property<int>("UserApplicationsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationsApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsersUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserApplicationsId");

                    b.HasIndex("ApplicationsApplicationId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("UserApplications");
                });

            modelBuilder.Entity("FTeam.EntityNpanel.ManyToMany.UserRoles", b =>
                {
                    b.Property<int>("UserRolesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RolesRoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsersUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserRolesId");

                    b.HasIndex("RolesRoleId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("FTeam.EntityNpanel.Roles.Pages", b =>
                {
                    b.Property<Guid>("PageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PageId");

                    b.ToTable("Pages");
                });

            modelBuilder.Entity("FTeam.EntityNpanel.Roles.Roles", b =>
                {
                    b.Property<Guid>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("FTeam.EntityNpanel.Sessions.UsersSessions", b =>
                {
                    b.Property<int>("UserSessionsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UsersUserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserSessionsId");

                    b.HasIndex("UsersUserId");

                    b.ToTable("UsersSessions");
                });

            modelBuilder.Entity("FTeam.EntityNpanel.Users.Users", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ActiveCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ActiveDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsConfirm")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FTeam.Entity.Sessions.ApplicationSessions", b =>
                {
                    b.HasOne("FTeam.Entity.Applications.Applications", "Applications")
                        .WithMany("ApplicationSessions")
                        .HasForeignKey("ApplicationsApplicationId");

                    b.Navigation("Applications");
                });

            modelBuilder.Entity("FTeam.EntityNpanel.ManyToMany.RoleAccessPages", b =>
                {
                    b.HasOne("FTeam.EntityNpanel.Roles.Pages", "Pages")
                        .WithMany("RoleAccessPages")
                        .HasForeignKey("PagesPageId");

                    b.HasOne("FTeam.EntityNpanel.Roles.Roles", "Roles")
                        .WithMany("RoleAccessPages")
                        .HasForeignKey("RolesRoleId");

                    b.Navigation("Pages");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("FTeam.EntityNpanel.ManyToMany.UserApplications", b =>
                {
                    b.HasOne("FTeam.Entity.Applications.Applications", "Applications")
                        .WithMany("UserApplications")
                        .HasForeignKey("ApplicationsApplicationId");

                    b.HasOne("FTeam.EntityNpanel.Users.Users", "Users")
                        .WithMany("UserApplications")
                        .HasForeignKey("UsersUserId");

                    b.Navigation("Applications");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("FTeam.EntityNpanel.ManyToMany.UserRoles", b =>
                {
                    b.HasOne("FTeam.EntityNpanel.Roles.Roles", "Roles")
                        .WithMany("UserRoles")
                        .HasForeignKey("RolesRoleId");

                    b.HasOne("FTeam.EntityNpanel.Users.Users", "Users")
                        .WithMany("UserRoles")
                        .HasForeignKey("UsersUserId");

                    b.Navigation("Roles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("FTeam.EntityNpanel.Sessions.UsersSessions", b =>
                {
                    b.HasOne("FTeam.EntityNpanel.Users.Users", "Users")
                        .WithMany("UsersSessions")
                        .HasForeignKey("UsersUserId");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("FTeam.Entity.Applications.Applications", b =>
                {
                    b.Navigation("ApplicationSessions");

                    b.Navigation("UserApplications");
                });

            modelBuilder.Entity("FTeam.EntityNpanel.Roles.Pages", b =>
                {
                    b.Navigation("RoleAccessPages");
                });

            modelBuilder.Entity("FTeam.EntityNpanel.Roles.Roles", b =>
                {
                    b.Navigation("RoleAccessPages");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("FTeam.EntityNpanel.Users.Users", b =>
                {
                    b.Navigation("UserApplications");

                    b.Navigation("UserRoles");

                    b.Navigation("UsersSessions");
                });
#pragma warning restore 612, 618
        }
    }
}
