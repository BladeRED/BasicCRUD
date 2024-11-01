using BasicCRUD.Contexts;
using BasicCRUD.Models;
using CommunityToolkit.Mvvm.Input;
using MaterialDesignThemes.Wpf;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BasicCRUD.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        private GamerContext GamerContext;
        SnackbarMessageQueue SnackbarMessageQueue = new SnackbarMessageQueue(TimeSpan.FromSeconds(5));


        private Gamer _gamer = new Gamer();
        public Gamer Gamer { get { return _gamer; }set {
                _gamer = value;
                OnPropertyChanged(nameof(Gamers));
            } }

        private string _gamerToDelete;
        public string GamerToDelete {
            get { return _gamerToDelete; }
            set {
                _gamerToDelete = value;
                OnPropertyChanged(nameof(GamerToDelete));
            }
        }

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
        private RelayCommand _addGamersCommand;
        private RelayCommand _deleteGamersCommand;

        // event of INotify which is called when a property change //

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            // The Invoke is used here for update one of the user interface from the thread ui //
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public RelayCommand GetGamersCommand
        {
            get
            {
                return _getGamersCommand ?? (_getGamersCommand = new RelayCommand(GetGamers));
            }
        }

        public RelayCommand AddGamersCommand
        {
            get
            {
                return _addGamersCommand ?? (_addGamersCommand = new RelayCommand(AddGamers));
            }
        }

        public RelayCommand DeleteGamersCommand
        {
            get
            {
                return _deleteGamersCommand ?? (_deleteGamersCommand = new RelayCommand(DeleteGamers));
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

        public void AddGamers()
        {

            using (var context = new GamerContext())
            {
                Gamer newGamer = new Gamer(Gamer.Name, Gamer.Age, Gamer.FavouriteGame);

                if (newGamer != null)
                {
                    context.Gamers.Add(newGamer);
                    context.SaveChanges();

                }
                else
                {
                    SnackbarMessageQueue.Enqueue("Une erreur s'est produite lors de l'enregistrement des données. Veuillez vérifier les informations saisies et réessayer.");
                }
                
            }

        }

        public void DeleteGamers()
        {

            using (var context = new GamerContext())
            {
                string deletedGamer = GamerToDelete;

                if (deletedGamer != null)
                {
                    Gamer? DeletedGamer = context.Gamers.FirstOrDefault(g => g.Name == deletedGamer);
                    context.Gamers.Remove(DeletedGamer!);
                    context.SaveChanges();

                }
                else
                {
                    SnackbarMessageQueue.Enqueue("Une erreur s'est produite lors de l'enregistrement des données. Veuillez vérifier les informations saisies et réessayer.");
                }

            }

        }
    }
}
