using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using IdentityTest.DbContexes;

namespace IdentityTest.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    [Migration("20180218153414_aname")]
    partial class aname
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IdentityTest.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("brand");

                    b.Property<int>("numOfDoors");

                    b.HasKey("Id");

                    b.ToTable("Cars");
                });
        }
    }
}
