﻿// <auto-generated />
using BS_Test.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BrainStation23.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20201022125104_BrainStationDB4")]
    partial class BrainStationDB4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BS_Test.Data.Comment", b =>
                {
                    b.Property<int>("comId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment_Data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PID")
                        .HasColumnType("int");

                    b.Property<string>("date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("comId");

                    b.HasIndex("PID");

                    b.ToTable("comment");
                });

            modelBuilder.Entity("BS_Test.Data.Post", b =>
                {
                    b.Property<int>("PID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("active")
                        .HasColumnType("int");

                    b.Property<string>("date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("post_data")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("PID");

                    b.ToTable("post");
                });

            modelBuilder.Entity("BS_Test.Data.Comment", b =>
                {
                    b.HasOne("BS_Test.Data.Post", "Post")
                        .WithMany("Comment_List")
                        .HasForeignKey("PID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
