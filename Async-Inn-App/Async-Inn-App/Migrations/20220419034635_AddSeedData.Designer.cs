// <auto-generated />
using Async_Inn_App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Async_Inn_App.Migrations
{
    [DbContext(typeof(AsyncInnDbContext))]
    [Migration("20220419034635_AddSeedData")]
    partial class AddSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Async_Inn_App.Models.Amenity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            ID = 2,
                            Name = "Air Conditioner"
                        },
                        new
                        {
                            ID = 1,
                            Name = "Coffee Machine"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Sea View"
                        });
                });

            modelBuilder.Entity("Async_Inn_App.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            City = "Amman",
                            Country = "Jordan",
                            Name = "AsyncInn Amman",
                            Phone = "+962775777777",
                            State = "",
                            StreetAddress = "St1-2"
                        },
                        new
                        {
                            ID = 2,
                            City = "Irbid",
                            Country = "Jordan",
                            Name = "AsyncInn Irbid",
                            Phone = "+962775777778",
                            State = "",
                            StreetAddress = "St3-4"
                        },
                        new
                        {
                            ID = 3,
                            City = "Jerash",
                            Country = "Jordan",
                            Name = "AsyncInn Jerash",
                            Phone = "+962775777779",
                            State = "",
                            StreetAddress = "St5-6"
                        });
                });

            modelBuilder.Entity("Async_Inn_App.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Layout")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Layout = 0,
                            Name = "FirstStudio"
                        },
                        new
                        {
                            ID = 2,
                            Layout = 1,
                            Name = "FirstOneBedroom"
                        },
                        new
                        {
                            ID = 3,
                            Layout = 2,
                            Name = "FirstTwoBedroom"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
