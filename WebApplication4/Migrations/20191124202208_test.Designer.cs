﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication4.Models;

namespace WebApplication4.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20191124202208_test")]
    partial class test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication4.Models.Country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("country_name");

                    b.HasKey("id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("WebApplication4.Models.Recall", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("address_1");

                    b.Property<string>("center_classification_date");

                    b.Property<string>("city");

                    b.Property<string>("code_info");

                    b.Property<string>("country");

                    b.Property<string>("distribution_pattern");

                    b.Property<string>("product_description");

                    b.Property<string>("product_quantity");

                    b.Property<string>("reason_for_recall");

                    b.Property<string>("report_date");

                    b.Property<string>("state");

                    b.HasKey("id");

                    b.ToTable("Recalls");
                });
#pragma warning restore 612, 618
        }
    }
}
