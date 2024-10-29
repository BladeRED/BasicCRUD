using BasicCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCRUD.Contexts
{
    public class GamerContext: DbContext
    {
        public DbSet<Gamer> Gamers { get; set; }

        public GamerContext()
        {
        }

        public GamerContext(DbSet<Gamer> gamers)
        {
            Gamers = gamers;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=GamersBDD;Integrated Security=True");
                //optionsBuilder.LogTo(Console.WriteLine);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var Gamer1 = new Gamer(1, "BladeRED", 32, "Metaphor Re:Fantazio");
            var Gamer2 = new Gamer(2, "Eurons", 26, "Légendes Pokémon: Arceus");
            var Gamer3 = new Gamer(3, "Katsuki", 33, "Octopath Traveler 2");

            modelBuilder.Entity<Gamer>().HasData(Gamer1, Gamer2, Gamer3);

            base.OnModelCreating(modelBuilder);
        }


        }
}
