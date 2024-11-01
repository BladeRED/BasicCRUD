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

        // Add properties //

        private Gamer _gamer = new Gamer();
        public Gamer Gamer { get { return _gamer; }set {
                _gamer = value;
                OnPropertyChanged(nameof(Gamers));
            } }

        // Delete properties //

        private string _gamerToDelete;
        public string GamerToDelete {
            get { return _gamerToDelete; }
            set {
                _gamerToDelete = value;
                OnPropertyChanged(nameof(GamerToDelete));
            }
        }

        // Get by name properties //
        private string _gamerToSearch;
        public string GamerToSearch
        {
            get { return _gamerToSearch; }
            set
            {
                _gamerToSearch = value;
                OnPropertyChanged(nameof(GamerToSearch));
            }
        }

        // Get all properties //
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

        // Update Properties //

        private string _nameContent;
        public string NameContent { 
            get { return _nameContent; }
            set 
            {
                _nameContent = value;
                OnPropertyChanged(nameof(NameContent)); 
            } 
        }

        private string _ageContent;
        public string AgeContent { get { return _ageContent; } 
            set {
                _ageContent = value;
                OnPropertyChanged(nameof(AgeContent));
            } 
        }
        private string _favContent;
        public string FavContent { get { return _favContent; }
            set {
            
                _favContent = value;
                OnPropertyChanged(nameof(FavContent));
            } 
        }

        // button commands //

        private RelayCommand _getGamersCommand;
        private RelayCommand _getByNameCommand;
        private RelayCommand _addGamersCommand;
        private RelayCommand _deleteGamersCommand;
        private RelayCommand _updateGamersCommand;

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

        public RelayCommand GetByNameCommand
        {
            get
            {
                return _getByNameCommand ?? (_getByNameCommand = new RelayCommand(GetByName));
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

        public RelayCommand UpdateGamersCommand
        {
            get
            {
                return _updateGamersCommand ?? (_updateGamersCommand = new RelayCommand(UpdateGamers));
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

        public void GetByName()
        {

            using (var context = new GamerContext())
            {
                Gamer? GamerSearched = context.Gamers.FirstOrDefault(g => g.Name == GamerToSearch);
                NameContent = GamerSearched!.Name;
                AgeContent = GamerSearched.Age.ToString();
                FavContent = GamerSearched.FavouriteGame;

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

        public void UpdateGamers()
        {

            using (var context = new GamerContext())
            {
                Gamer? updateGamer = context.Gamers.FirstOrDefault(g=>g.Name == GamerToSearch);
                int.TryParse(AgeContent, out int AgeContentInt);
                
                updateGamer!.Name = NameContent;
                updateGamer.Age = AgeContentInt;
                updateGamer.FavouriteGame = FavContent;

                if (updateGamer != null)
                {
                    context.Gamers.Update(updateGamer);
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
