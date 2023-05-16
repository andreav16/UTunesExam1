﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UTunes.Infrastructure.Database;

#nullable disable

namespace UTunes.Infrastructure.Database.Migrations
{
    [DbContext(typeof(UTunesContext))]
    partial class UTunesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("UTunes.Core.Entities.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Dislikes")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Likes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Votes")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Album");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Artist = "Backstreet Boys",
                            Dislikes = 0,
                            Likes = 0,
                            Name = "DNA",
                            Review = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Aenean sed leo elit. Nullam tellus ipsum, fringilla quis ex vitae, mattis rutrum felis. Duis venenatis faucibus turpis, at tincidunt arcu bibendum ac. Vestibulum eget placerat libero, nec tempus ipsum. Sed elit libero, luctus non dapibus et, sagittis a tellus. Ut suscipit porta vestibulum. Mauris justo velit, pretium at efficitur nec, posuere non massa. Proin quis aliquet quam. Maecenas malesuada mauris ex, eu sollicitudin quam laoreet ut. Sed mollis enim dolor, eu malesuada dui aliquet ut. Quisque rhoncus augue urna, at volutpat justo ultrices et. Vivamus maximus quam non nisl placerat varius. Nam mollis erat ullamcorper diam efficitur, molestie feugiat urna finibus. Phasellus dignissim interdum neque sed dictum.",
                            Votes = 0
                        },
                        new
                        {
                            Id = 2,
                            Artist = "One Direction",
                            Dislikes = 0,
                            Likes = 0,
                            Name = "Midnight Memories",
                            Review = "Lorem ipsum yes dolor sit amet, consectetur adipiscing elit. Aenean sed leo elit. Nullam tellus ipsum, fringilla quis ex vitae, mattis rutrum felis. Duis venenatis faucibus turpis, at tincidunt arcu bibendum ac. Vestibulum eget placerat libero, nec tempus ipsum. Sed elit libero, luctus non dapibus et, sagittis a tellus. Ut suscipit porta vestibulum. Mauris justo velit, pretium at efficitur nec, posuere non massa. Proin quis aliquet quam. Maecenas malesuada mauris ex, eu sollicitudin quam laoreet ut. Sed mollis enim dolor, eu malesuada dui aliquet ut. Quisque rhoncus augue urna, at volutpat justo ultrices et. Vivamus maximus quam non nisl placerat varius. Nam mollis erat ullamcorper diam efficitur, molestie feugiat urna finibus. Phasellus dignissim interdum neque sed dictum.",
                            Votes = 0
                        });
                });

            modelBuilder.Entity("UTunes.Core.Entities.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AlbumId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Artist")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("SongPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Song");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AlbumId = 1,
                            Artist = "Backstreet boys",
                            Name = "Don't go breaking my heart",
                            SongPrice = 100.0
                        },
                        new
                        {
                            Id = 2,
                            AlbumId = 1,
                            Artist = "Backstreet boys",
                            Name = "Nobody else",
                            SongPrice = 150.0
                        },
                        new
                        {
                            Id = 3,
                            AlbumId = 1,
                            Artist = "Backstreet boys",
                            Name = "Breathe",
                            SongPrice = 98.0
                        },
                        new
                        {
                            Id = 4,
                            AlbumId = 1,
                            Artist = "Backstreet boys",
                            Name = "New love",
                            SongPrice = 98.0
                        },
                        new
                        {
                            Id = 5,
                            AlbumId = 2,
                            Artist = "One Direction",
                            Name = "Rock Me",
                            SongPrice = 150.0
                        });
                });

            modelBuilder.Entity("UTunes.Core.Entities.Song", b =>
                {
                    b.HasOne("UTunes.Core.Entities.Album", "Album")
                        .WithMany("Songs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("UTunes.Core.Entities.Album", b =>
                {
                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
