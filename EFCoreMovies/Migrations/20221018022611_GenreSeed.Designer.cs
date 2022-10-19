﻿// <auto-generated />
using System;
using EFCoreMovies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

#nullable disable

namespace EFCoreMovies.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221018022611_GenreSeed")]
    partial class GenreSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CinemaHallMovie", b =>
                {
                    b.Property<Guid>("CinemaHallsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MoviesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CinemaHallsId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("CinemaHallMovie");

                    b.HasData(
                        new
                        {
                            CinemaHallsId = new Guid("4fb60000-a64a-9828-8070-08daaa0901d0"),
                            MoviesId = new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff")
                        },
                        new
                        {
                            CinemaHallsId = new Guid("4fb60000-a64a-9828-860c-08daaa0901d0"),
                            MoviesId = new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff")
                        },
                        new
                        {
                            CinemaHallsId = new Guid("4fb60000-a64a-9828-2621-08daaa0901d0"),
                            MoviesId = new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff")
                        },
                        new
                        {
                            CinemaHallsId = new Guid("4fb60000-a64a-9828-697e-08daaa0901d0"),
                            MoviesId = new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff")
                        },
                        new
                        {
                            CinemaHallsId = new Guid("4fb60000-a64a-9828-7570-08daaa0901d0"),
                            MoviesId = new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff")
                        },
                        new
                        {
                            CinemaHallsId = new Guid("4fb60000-a64a-9828-7570-08daaa0901d0"),
                            MoviesId = new Guid("4fb60000-a64a-9828-f435-08daaa0857ff")
                        },
                        new
                        {
                            CinemaHallsId = new Guid("4fb60000-a64a-9828-860c-08daaa0901d0"),
                            MoviesId = new Guid("4fb60000-a64a-9828-f435-08daaa0857ff")
                        },
                        new
                        {
                            CinemaHallsId = new Guid("4fb60000-a64a-9828-697e-08daaa0901d0"),
                            MoviesId = new Guid("4fb60000-a64a-9828-f435-08daaa0857ff")
                        },
                        new
                        {
                            CinemaHallsId = new Guid("4fb60000-a64a-9828-7b22-08daaa0901d0"),
                            MoviesId = new Guid("4fb60000-a64a-9828-f435-08daaa0857ff")
                        });
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Actor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Biography")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Actors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-ea48-08daaa06a9cb"),
                            Biography = "Thomas Stanley Holland (born 1 June 1996) is an English actor. He is recipient of several accolades, including the 2017 BAFTA Rising Star Award. Holland began his acting career as a child actor on the West End stage in Billy Elliot the Musical at the Victoria Palace Theater in 2008, playing a supporting part",
                            DateOfBirth = new DateTime(1996, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tom Holland"
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-fc0c-08daaa06a9cb"),
                            DateOfBirth = new DateTime(2000, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Auli'i Cravalho"
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-f6bf-08daaa06a9cb"),
                            DateOfBirth = new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Chris Evans"
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-0235-08daaa06a9cc"),
                            DateOfBirth = new DateTime(1964, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Keanu Reeves"
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-f97f-08daaa06a9cb"),
                            DateOfBirth = new DateTime(1972, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Dwayne Johnson"
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-f42a-08daaa06a9cb"),
                            Biography = "Robert John Downey Jr. (born April 4, 1965) is an American actor and producer. His career has been characterized by critical and popular success in his youth, followed by a period of substance abuse and legal troubles, before a resurgence of commercial success later in his career.",
                            DateOfBirth = new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Robert Downey Jr."
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-f090-08daaa06a9cb"),
                            Biography = "Samuel Leroy Jackson (born December 21, 1948) is an American actor and producer. One of the most widely recognized actors of his generation, the films in which he has appeared have collectively grossed over $27 billion worldwide, making him the highest-grossing actor of all time (excluding cameo appearances and voice roles).",
                            DateOfBirth = new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Samuel L. Jackson"
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-ff1f-08daaa06a9cb"),
                            DateOfBirth = new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Scarlett Johansson"
                        });
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Cinema", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Point>("Location")
                        .IsRequired()
                        .HasColumnType("geography");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Cinemas");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-04f7-08daaa06a9cc"),
                            Location = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (27.6772126 85.317018)"),
                            Name = "Labim Mall"
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-09ed-08daaa06a9cc"),
                            Location = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (27.6751519 85.3968551)"),
                            Name = "Bhaktapur Mall"
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-07a5-08daaa06a9cc"),
                            Location = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (27.6992707 85.3084962)"),
                            Name = "Civil Mall"
                        });
                });

            modelBuilder.Entity("EFCoreMovies.Entities.CinemaHall", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CinemaHallType")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasDefaultValue("TwoDimension");

                    b.Property<Guid>("CinemaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Cost")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("Currency")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId");

                    b.ToTable("CinemaHalls");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-2621-08daaa0901d0"),
                            CinemaHallType = "TwoDimension",
                            CinemaId = new Guid("4fb60000-a64a-9828-04f7-08daaa06a9cc"),
                            Cost = 150m,
                            Currency = ""
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-697e-08daaa0901d0"),
                            CinemaHallType = "ThreeDimension",
                            CinemaId = new Guid("4fb60000-a64a-9828-04f7-08daaa06a9cc"),
                            Cost = 250m,
                            Currency = ""
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-7570-08daaa0901d0"),
                            CinemaHallType = "ThreeDimension",
                            CinemaId = new Guid("4fb60000-a64a-9828-09ed-08daaa06a9cc"),
                            Cost = 250m,
                            Currency = ""
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-7b22-08daaa0901d0"),
                            CinemaHallType = "Cxc",
                            CinemaId = new Guid("4fb60000-a64a-9828-09ed-08daaa06a9cc"),
                            Cost = 500m,
                            Currency = ""
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-8070-08daaa0901d0"),
                            CinemaHallType = "TwoDimension",
                            CinemaId = new Guid("4fb60000-a64a-9828-07a5-08daaa06a9cc"),
                            Cost = 150m,
                            Currency = ""
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-860c-08daaa0901d0"),
                            CinemaHallType = "ThreeDimension",
                            CinemaId = new Guid("4fb60000-a64a-9828-07a5-08daaa06a9cc"),
                            Cost = 250m,
                            Currency = ""
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-8b7e-08daaa0901d0"),
                            CinemaHallType = "Cxc",
                            CinemaId = new Guid("4fb60000-a64a-9828-07a5-08daaa06a9cc"),
                            Cost = 550m,
                            Currency = ""
                        });
                });

            modelBuilder.Entity("EFCoreMovies.Entities.CinemaOffer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Begin")
                        .HasColumnType("date");

                    b.Property<Guid>("CinemaId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("DecimalPercentage")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.Property<DateTime>("End")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("CinemaId")
                        .IsUnique();

                    b.ToTable("CinemaOffers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-d903-08daaa073920"),
                            Begin = new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CinemaId = new Guid("4fb60000-a64a-9828-04f7-08daaa06a9cc"),
                            DecimalPercentage = 10m,
                            End = new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-dc4a-08daaa073920"),
                            Begin = new DateTime(2022, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            CinemaId = new Guid("4fb60000-a64a-9828-09ed-08daaa06a9cc"),
                            DecimalPercentage = 13m,
                            End = new DateTime(2022, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GetDate()");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("IsDeleted = 'false'");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-cdff-08daaa06a9cb"),
                            IsDeleted = false,
                            Name = "Animation"
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-0da5-08daaa06a9ca"),
                            IsDeleted = false,
                            Name = "Action"
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-dd58-08daaa06a9cb"),
                            IsDeleted = false,
                            Name = "Comedy"
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-e0dd-08daaa06a9cb"),
                            IsDeleted = false,
                            Name = "Science Friction"
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-e3c4-08daaa06a9cb"),
                            IsDeleted = false,
                            Name = "Drama"
                        });
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Keyless.CinemaWithoutLocation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToView(null);

                    b.ToSqlQuery("SELECT Id, Name FROM Cinemas");
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Keyless.MovieWithCounts", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AmountActor")
                        .HasColumnType("int");

                    b.Property<int>("AmountCinemas")
                        .HasColumnType("int");

                    b.Property<int>("AmountGenre")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToView("MoviesWithCounts");
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("InCinema")
                        .HasColumnType("bit");

                    b.Property<string>("PosterUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Movies");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-f914-08daaa0857ff"),
                            InCinema = false,
                            PosterUrl = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
                            ReleaseDate = new DateTime(2012, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Avengers"
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-e5a1-08daaa0857ff"),
                            InCinema = false,
                            PosterUrl = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg",
                            ReleaseDate = new DateTime(2022, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Spider-Man: No Way Home"
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-a079-08daaa0857ff"),
                            InCinema = false,
                            PosterUrl = "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg",
                            ReleaseDate = new DateTime(2017, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Coco"
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff"),
                            InCinema = true,
                            PosterUrl = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg",
                            ReleaseDate = new DateTime(2019, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Spider-Man: Far From Home"
                        },
                        new
                        {
                            Id = new Guid("4fb60000-a64a-9828-f435-08daaa0857ff"),
                            InCinema = true,
                            PosterUrl = "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg",
                            ReleaseDate = new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Matrix"
                        });
                });

            modelBuilder.Entity("EFCoreMovies.Entities.MovieActor", b =>
                {
                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ActorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Character")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Order")
                        .HasMaxLength(150)
                        .HasColumnType("int");

                    b.HasKey("MovieId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("MovieActors");

                    b.HasData(
                        new
                        {
                            MovieId = new Guid("4fb60000-a64a-9828-f435-08daaa0857ff"),
                            ActorId = new Guid("4fb60000-a64a-9828-0235-08daaa06a9cc"),
                            Character = "Neo",
                            Order = 1
                        },
                        new
                        {
                            MovieId = new Guid("4fb60000-a64a-9828-f914-08daaa0857ff"),
                            ActorId = new Guid("4fb60000-a64a-9828-f6bf-08daaa06a9cb"),
                            Character = "Captain America",
                            Order = 1
                        },
                        new
                        {
                            MovieId = new Guid("4fb60000-a64a-9828-f914-08daaa0857ff"),
                            ActorId = new Guid("4fb60000-a64a-9828-f42a-08daaa06a9cb"),
                            Character = "Iron Man",
                            Order = 2
                        },
                        new
                        {
                            MovieId = new Guid("4fb60000-a64a-9828-f914-08daaa0857ff"),
                            ActorId = new Guid("4fb60000-a64a-9828-ff1f-08daaa06a9cb"),
                            Character = "Black Widow",
                            Order = 3
                        },
                        new
                        {
                            MovieId = new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff"),
                            ActorId = new Guid("4fb60000-a64a-9828-ea48-08daaa06a9cb"),
                            Character = "Peter Parker",
                            Order = 2
                        },
                        new
                        {
                            MovieId = new Guid("4fb60000-a64a-9828-e5a1-08daaa0857ff"),
                            ActorId = new Guid("4fb60000-a64a-9828-ea48-08daaa06a9cb"),
                            Character = "Peter Parker",
                            Order = 1
                        },
                        new
                        {
                            MovieId = new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff"),
                            ActorId = new Guid("4fb60000-a64a-9828-f090-08daaa06a9cb"),
                            Character = "Nick Fury",
                            Order = 2
                        });
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.Property<Guid>("GenresId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MoviesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("GenresId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("GenreMovie");

                    b.HasData(
                        new
                        {
                            GenresId = new Guid("4fb60000-a64a-9828-e0dd-08daaa06a9cb"),
                            MoviesId = new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff")
                        },
                        new
                        {
                            GenresId = new Guid("4fb60000-a64a-9828-0da5-08daaa06a9ca"),
                            MoviesId = new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff")
                        },
                        new
                        {
                            GenresId = new Guid("4fb60000-a64a-9828-dd58-08daaa06a9cb"),
                            MoviesId = new Guid("4fb60000-a64a-9828-ef3e-08daaa0857ff")
                        },
                        new
                        {
                            GenresId = new Guid("4fb60000-a64a-9828-e0dd-08daaa06a9cb"),
                            MoviesId = new Guid("4fb60000-a64a-9828-e5a1-08daaa0857ff")
                        },
                        new
                        {
                            GenresId = new Guid("4fb60000-a64a-9828-0da5-08daaa06a9ca"),
                            MoviesId = new Guid("4fb60000-a64a-9828-e5a1-08daaa0857ff")
                        },
                        new
                        {
                            GenresId = new Guid("4fb60000-a64a-9828-dd58-08daaa06a9cb"),
                            MoviesId = new Guid("4fb60000-a64a-9828-e5a1-08daaa0857ff")
                        },
                        new
                        {
                            GenresId = new Guid("4fb60000-a64a-9828-cdff-08daaa06a9cb"),
                            MoviesId = new Guid("4fb60000-a64a-9828-a079-08daaa0857ff")
                        },
                        new
                        {
                            GenresId = new Guid("4fb60000-a64a-9828-0da5-08daaa06a9ca"),
                            MoviesId = new Guid("4fb60000-a64a-9828-f914-08daaa0857ff")
                        },
                        new
                        {
                            GenresId = new Guid("4fb60000-a64a-9828-e0dd-08daaa06a9cb"),
                            MoviesId = new Guid("4fb60000-a64a-9828-f914-08daaa0857ff")
                        });
                });

            modelBuilder.Entity("CinemaHallMovie", b =>
                {
                    b.HasOne("EFCoreMovies.Entities.CinemaHall", null)
                        .WithMany()
                        .HasForeignKey("CinemaHallsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreMovies.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreMovies.Entities.CinemaHall", b =>
                {
                    b.HasOne("EFCoreMovies.Entities.Cinema", "Cinema")
                        .WithMany("CinemaHalls")
                        .HasForeignKey("CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinema");
                });

            modelBuilder.Entity("EFCoreMovies.Entities.CinemaOffer", b =>
                {
                    b.HasOne("EFCoreMovies.Entities.Cinema", null)
                        .WithOne("CinemaOffer")
                        .HasForeignKey("EFCoreMovies.Entities.CinemaOffer", "CinemaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreMovies.Entities.MovieActor", b =>
                {
                    b.HasOne("EFCoreMovies.Entities.Actor", "Actor")
                        .WithMany("MovieActors")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreMovies.Entities.Movie", "Movie")
                        .WithMany("MovieActors")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("GenreMovie", b =>
                {
                    b.HasOne("EFCoreMovies.Entities.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCoreMovies.Entities.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Actor", b =>
                {
                    b.Navigation("MovieActors");
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Cinema", b =>
                {
                    b.Navigation("CinemaHalls");

                    b.Navigation("CinemaOffer")
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreMovies.Entities.Movie", b =>
                {
                    b.Navigation("MovieActors");
                });
#pragma warning restore 612, 618
        }
    }
}
