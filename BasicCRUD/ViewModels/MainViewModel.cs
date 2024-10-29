using BasicCRUD.Contexts;
using BasicCRUD.Models;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BasicCRUD.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        private GamerContext GamerContext;

        private List<Gamer> _gamers;
        public List<Gamer> Gamers
        {
            get { return _gamers; }
            set
            {
                _gamers = value;
                OnPropertyChanged(nameof(Gamers));
            }
        } 

        // button commands //

        private RelayCommand _getGamersCommand;

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public RelayCommand GetGamersCommand
        {
            get
            {
                return _getGamersCommand ?? (_getGamersCommand = new RelayCommand(GetGamers));
            }
        }

        public MainViewModel()
        {
            //GamerContext = new GamerContext();
            //Gamers = new List<Gamer>(GamerContext.Gamers.ToList());
        }

        public void GetGamers() {

            using (var context = new GamerContext())
            {
                Gamers = new List<Gamer>(context.Gamers.ToList());
            }

        }
    }
}
