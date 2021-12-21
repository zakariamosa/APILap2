
using Microsoft.EntityFrameworkCore;

namespace Animal.Entities
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Animal> Animals { get; set; }
        public DbSet<Artist> Artists { get; set; }



        private string _connectionString = @"server=DESKTOP-B31UQDI; database=AnimalDB;uid=sa;pwd=123;integrated Security=false";
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Artist>().HasData(
                new Artist
                {
                    Name = "Amr Diab",
                    Created = DateTime.Now,
                    FavoriteCar = "BMW",
                    Id = 1
                },
                 new Artist
                 {
                     Name = "mohammed fouad",
                     Created = DateTime.Now,
                     FavoriteCar = "Mercedes",
                     Id = 2
                 },
                  new Artist
                  {
                      Name = "Mostafa amar",
                      Created = DateTime.Now,
                      FavoriteCar = "Tesla",
                      Id = 3
                  },
                   new Artist
                   {
                       Name = "Hamaky",
                       Created = DateTime.Now,
                       FavoriteCar = "Rols",
                       Id = 4
                   }
            );
            builder.Entity<Vinyl>().HasData(
                new Vinyl { Id = 1, ArtistID = 1, Created = DateTime.Now, Title = "tammaly maaaak" },
                new Vinyl { Id = 2, ArtistID = 1, Created = DateTime.Now, Title = "esmaaaa" },
                new Vinyl { Id = 3, ArtistID = 2, Created = DateTime.Now, Title = "ahkilak" },
                new Vinyl { Id = 4, ArtistID = 3, Created = DateTime.Now, Title = "vinyl3" },
                new Vinyl { Id = 5, ArtistID = 3, Created = DateTime.Now, Title = "ya habibi" },
                new Vinyl { Id = 6, ArtistID = 4, Created = DateTime.Now, Title = "ellylady" }
                );
        }
    }
}
