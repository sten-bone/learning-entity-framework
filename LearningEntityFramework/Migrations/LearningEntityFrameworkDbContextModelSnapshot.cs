﻿// <auto-generated />
using LearningEntityFramework.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LearningEntityFramework.Migrations
{
    [DbContext(typeof(LearningEntityFrameworkDbContext))]
    partial class LearningEntityFrameworkDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("LearningEntityFramework.Models.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Blogs", "dbo");
                });
#pragma warning restore 612, 618
        }
    }
}