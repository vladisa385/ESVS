﻿// <auto-generated />
using System;
using ESVS.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ESVS.Persistence.Migrations
{
    [DbContext(typeof(ESVSDbContext))]
    [Migration("20190710180239_2")]
    partial class _2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ESVS.Domain.Entities.Catalog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name");

                    b.Property<Guid?>("ParentCatalogId");

                    b.Property<string>("Text");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("ParentCatalogId");

                    b.ToTable("Catalogs");
                });

            modelBuilder.Entity("ESVS.Domain.Entities.Field", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Caption");

                    b.Property<Guid>("CatalogId");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsForeignKey");

                    b.Property<int?>("Length");

                    b.Property<string>("Name");

                    b.Property<bool>("NotNull");

                    b.Property<Guid>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("CatalogId");

                    b.HasIndex("TypeId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("ESVS.Domain.Entities.Type", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsDeleted");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("ESVS.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Email");

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool>("Gender");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ESVS.Domain.Entities.Catalog", b =>
                {
                    b.HasOne("ESVS.Domain.Entities.Catalog", "ParentCatalog")
                        .WithMany("ChildCatalogs")
                        .HasForeignKey("ParentCatalogId");
                });

            modelBuilder.Entity("ESVS.Domain.Entities.Field", b =>
                {
                    b.HasOne("ESVS.Domain.Entities.Catalog", "Catalog")
                        .WithMany("Fields")
                        .HasForeignKey("CatalogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ESVS.Domain.Entities.Type", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("System.Collections.Generic.List<ESVS.Domain.ValueObjects.FieldValue>", "FieldValues", b1 =>
                        {
                            b1.Property<Guid>("FieldId");

                            b1.Property<int>("Capacity");

                            b1.HasKey("FieldId");

                            b1.ToTable("Fields");

                            b1.HasOne("ESVS.Domain.Entities.Field")
                                .WithOne("FieldValues")
                                .HasForeignKey("System.Collections.Generic.List<ESVS.Domain.ValueObjects.FieldValue>", "FieldId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}