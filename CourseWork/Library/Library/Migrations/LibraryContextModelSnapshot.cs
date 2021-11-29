﻿// <auto-generated />
using System;
using Library.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Library.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pages")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library.Entities.CatalogCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("QantityOfBook")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("CatalogCards");
                });

            modelBuilder.Entity("Library.Entities.ReaderList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ReaderLists");
                });

            modelBuilder.Entity("Library.Entities.SubscriptionCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CatalogCardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("IssueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ReaderListId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CatalogCardId");

                    b.HasIndex("ReaderListId");

                    b.ToTable("SubscriptionCards");
                });

            modelBuilder.Entity("Library.Entities.Book", b =>
                {
                    b.HasOne("Library.Entities.Book", null)
                        .WithMany("Books")
                        .HasForeignKey("BookId");
                });

            modelBuilder.Entity("Library.Entities.CatalogCard", b =>
                {
                    b.HasOne("Library.Entities.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Library.Entities.SubscriptionCard", b =>
                {
                    b.HasOne("Library.Entities.CatalogCard", "CatalogCard")
                        .WithMany("SubsciptionCards")
                        .HasForeignKey("CatalogCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Library.Entities.ReaderList", "ReaderList")
                        .WithMany("SubsciptionCards")
                        .HasForeignKey("ReaderListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CatalogCard");

                    b.Navigation("ReaderList");
                });

            modelBuilder.Entity("Library.Entities.Book", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("Library.Entities.CatalogCard", b =>
                {
                    b.Navigation("SubsciptionCards");
                });

            modelBuilder.Entity("Library.Entities.ReaderList", b =>
                {
                    b.Navigation("SubsciptionCards");
                });
#pragma warning restore 612, 618
        }
    }
}
