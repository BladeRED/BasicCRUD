using BasicCRUD.Contexts;
using BasicCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCRUD.ViewModels
{
    public class MainViewModel
    {
        private GamerContext GamerContext;
        public List<Gamer> Gamers { get; set; }

        public MainViewModel()
        {
            GamerContext = new GamerContext();
            Gamers = new List<Gamer>(GamerContext.Gamers.ToList());
        }
    }
}
