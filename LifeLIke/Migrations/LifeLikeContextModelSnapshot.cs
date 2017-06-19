using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LifeLike.Models;
using LifeLike.Models.Enums;

namespace LifeLIke.Migrations
{
    [DbContext(typeof(LifeLikeContext))]
    partial class LifeLikeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LifeLike.Models.ChangelogDataModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Link");

                    b.Property<string>("Name");

                    b.Property<DateTime>("Published");

                    b.HasKey("Id");

                    b.ToTable("Changelogs");
                });

            modelBuilder.Entity("LifeLike.Models.EventLogDataModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EventTime");

                    b.Property<string>("Messages");

                    b.Property<string>("StackTrace");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("EventLogs");
                });

            modelBuilder.Entity("LifeLike.Models.LinkDataModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Action");

                    b.Property<int>("Category");

                    b.Property<string>("Controller");

                    b.Property<string>("IconName");

                    b.Property<string>("Link");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Links");
                });
        }
    }
}
