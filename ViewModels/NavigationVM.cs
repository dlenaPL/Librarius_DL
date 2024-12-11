using Librarius_DL.Utilities;
using System.Windows.Input;

namespace Librarius_DL.ViewModels
{
    class NavigationVM : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }

        public ICommand NavigateHomeCommand { get; set; }
        public ICommand NavigateAuthorsCommand { get; set; }
        public ICommand NavigateGenresCommand { get; set; }
        public ICommand NavigatePublishersCommand { get; set; }
        public ICommand NavigateMembersCommand { get; set; }
        public ICommand NavigateStatusesCommand { get; set; }
        public ICommand NavigateRolesCommand { get; set; }
        public ICommand NavigateFineStatusesCommand { get; set; }
        public ICommand NavigateConditionsCommand { get; set; }
        public ICommand NavigateBooksCommand { get; set; }
        public ICommand NavigatePermissionsCommand { get; set; }
        public ICommand NavigateBookCopiesCommand { get; set; }
        public ICommand NavigateStaffCommand { get; set; }
        public ICommand NavigateTransactionsCommand { get; set; }
        public ICommand NavigateFinesCommand { get; set; }
        public ICommand NavigateNotificationsCommand { get; set; }
        public ICommand NavigateReservationsCommand { get; set; }

        

        private void Home(object obj) => CurrentView = new HomeVM();
        private void Authors(object obj) => CurrentView = new AuthorsVM();
        private void Genres(object obj) => CurrentView = new GenresVM();
        private void Publishers(object obj) => CurrentView = new PublishersVM();
        private void Members(object obj) => CurrentView = new MembersVM();
        private void Statuses(object obj) => CurrentView = new StatusesVM();
        private void Roles(object obj) => CurrentView = new RolesVM();
        private void FineStatuses(object obj) => CurrentView = new FineStatusesVM();
        private void Conditions(object obj) => CurrentView = new ConditionsVM();
        private void Books(object obj) => CurrentView = new BooksVM();
        private void Permissions(object obj) => CurrentView = new PermissionsVM();
        private void BookCopies(object obj) => CurrentView = new BookCopiesVM();
        private void Staff(object obj) => CurrentView = new StaffVM();
        private void Transaction(object obj) => CurrentView = new TransactionsVM();
        private void Fines(object obj) => CurrentView = new FinesVM();
        private void Notifications(object obj) => CurrentView = new NotificationsVM();
        private void Reservations(object obj) => CurrentView = new ReservationsVM();


        public NavigationVM() 
        {
            NavigateHomeCommand = new RelayCommand(Home);
            NavigateAuthorsCommand = new RelayCommand(Authors);
            NavigateGenresCommand = new RelayCommand(Genres);
            NavigatePublishersCommand = new RelayCommand(Publishers);
            NavigateMembersCommand = new RelayCommand(Members);
            NavigateStatusesCommand = new RelayCommand(Statuses);
            NavigateRolesCommand = new RelayCommand(Roles);
            NavigateFineStatusesCommand = new RelayCommand(FineStatuses);
            NavigateConditionsCommand = new RelayCommand(Conditions);
            NavigateBooksCommand = new RelayCommand(Books);
            NavigatePermissionsCommand = new RelayCommand(Permissions);
            NavigateBookCopiesCommand = new RelayCommand(BookCopies);
            NavigateStaffCommand = new RelayCommand(Staff);
            NavigateTransactionsCommand = new RelayCommand(Transaction);
            NavigateFinesCommand = new RelayCommand(Fines);
            NavigateNotificationsCommand = new RelayCommand(Notifications);
            NavigateReservationsCommand = new RelayCommand(Reservations);


            CurrentView = new HomeVM();
        }

    }
}
