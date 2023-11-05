using MagicVilla_API.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Villa> Villas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                    new Villa()
                    {
                        Id=1,
                        Name="Villa Real",
                        Detail="Detalle de la Villa...",
                        ImageUrl="",
                        Occupants=5,
                        SquareMeter=50,
                        Fee=200,
                        Amenity="",
                        CrationDate= DateTime.Now,
                        UpdateDate= DateTime.Now,
                    },
                    new Villa()
                    {
                        Id = 2,
                        Name = "Premium Vista a la Piscina",
                        Detail = "Detalle de la Villa...",
                        ImageUrl = "",
                        Occupants = 4,
                        SquareMeter = 40,
                        Fee=150,
                        Amenity = "",
                        CrationDate = DateTime.Now,
                        UpdateDate = DateTime.Now,
                    }
                );
        }
    }
}
