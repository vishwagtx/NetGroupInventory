﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetGroupInventory.Persistent;

#nullable disable

namespace NetGroupInventory.Persistent.Migrations
{
    [DbContext(typeof(InventoryDbContext))]
    [Migration("20220331055758_ChangedTabelName")]
    partial class ChangedTabelName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NetGroupInventory.Domain.Items.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTimeOffset>("CreatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTimeOffset?>("ModifiedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatedBy");

                    b.ToTable("Item", (string)null);
                });

            modelBuilder.Entity("NetGroupInventory.Domain.Items.ItemCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("ItemCategory", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Category = "Category 1"
                        },
                        new
                        {
                            Id = 2,
                            Category = "Category 2"
                        },
                        new
                        {
                            Id = 3,
                            Category = "Category 3"
                        },
                        new
                        {
                            Id = 4,
                            Category = "Category 4"
                        });
                });

            modelBuilder.Entity("NetGroupInventory.Domain.Stoarge.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTimeOffset>("CreatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTimeOffset?>("ModifiedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Note")
                        .HasMaxLength(3000)
                        .HasColumnType("nvarchar(3000)");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("StorageLevelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("ItemId");

                    b.HasIndex("StorageLevelId");

                    b.ToTable("Inventory", (string)null);
                });

            modelBuilder.Entity("NetGroupInventory.Domain.Stoarge.StorageLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTimeOffset>("CreatedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasMaxLength(5000)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<DateTimeOffset?>("ModifiedDateTime")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.ToTable("StorageLevel", (string)null);
                });

            modelBuilder.Entity("NetGroupInventory.Domain.Items.Item", b =>
                {
                    b.HasOne("NetGroupInventory.Domain.Items.ItemCategory", "ItemCategory")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ItemCategory");
                });

            modelBuilder.Entity("NetGroupInventory.Domain.Stoarge.Inventory", b =>
                {
                    b.HasOne("NetGroupInventory.Domain.Items.Item", "Item")
                        .WithMany("InventoryItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NetGroupInventory.Domain.Stoarge.StorageLevel", "StorageLevel")
                        .WithMany("InventoryItems")
                        .HasForeignKey("StorageLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("StorageLevel");
                });

            modelBuilder.Entity("NetGroupInventory.Domain.Items.Item", b =>
                {
                    b.Navigation("InventoryItems");
                });

            modelBuilder.Entity("NetGroupInventory.Domain.Items.ItemCategory", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("NetGroupInventory.Domain.Stoarge.StorageLevel", b =>
                {
                    b.Navigation("InventoryItems");
                });
#pragma warning restore 612, 618
        }
    }
}
