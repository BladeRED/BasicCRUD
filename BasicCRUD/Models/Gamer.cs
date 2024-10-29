using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCRUD.Models
{
    public class Gamer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }

        public string FavouriteGame { get; set; }

        public Gamer()
        {
        }

        public Gamer(int id, string name, int age, string favouriteGame)
        {
            Id = id;
            Name = name;
            Age = age;
            FavouriteGame = favouriteGame;
        }
    }
}
