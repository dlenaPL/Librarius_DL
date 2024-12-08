using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities;
using Librarius_DL.Utilities.BusinessLogic;
using System;
using System.Linq;

namespace Librarius_DL.ViewModels
{
    public class AddNewBookVM : AddNewItemVM<Books>
    {

        public static int GenerateRandomNumber()
        {
            Random random = new Random();
            return random.Next(1, 1_000_001); // Górna granica jest wyłączna, więc ustawiamy 1_000_001
        }

        public AddNewBookVM()
        {
            
            item = new Books();
            item.Title = "Tytuł";
            item.ISBN = GenerateRandomNumber().ToString();
            item.PublishedYear = "Rok wydania";
            item.Description = "Opis książki";
            item.CoverImagePath = "Okładka";
            item.QRCode = null;

            item.PublisherID = 10000;
            item.StatusID = 101;
        }

        // book props

        public string Title
        {
            get => item.Title;
            set
            {
                item.Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string ISBN
        {
            get => item.ISBN;
            set
            {
                item.ISBN = value;
                OnPropertyChanged(nameof(ISBN));
            }
        }
        public string PublishedYear
        {
            get => item.PublishedYear;
            set
            {
                item.PublishedYear = value;
                OnPropertyChanged(nameof(PublishedYear));
            }
        }
        public string Description
        {
            get => item.Description;
            set
            {
                item.Description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        public string CoverImagePath
        {
            get => item.CoverImagePath;
            set
            {
                item.CoverImagePath = value;
                OnPropertyChanged(nameof(CoverImagePath));
            }
        }
        public byte[] QRCode
        {
            get => item.QRCode;
            set
            {
                item.QRCode = value;
                OnPropertyChanged(nameof(QRCode));
            }
        }
        public int? PublisherID
        {
            get => item.PublisherID;
            set
            {
                item.PublisherID = value;
                OnPropertyChanged(nameof(PublisherID));
            }
        }
        public int? StatusID
        {
            get => item.StatusID;
            set
            {
                item.StatusID = value;
                OnPropertyChanged(nameof(StatusID));
            }
        }




        //comboboxy
        public IQueryable<KeyAndValue> BookStatusesList
        {
            get
            {
                return DataBaseClass.GetAllStatuses();
            }
        }

        public IQueryable<KeyAndValue> PublishersList
        {
            get
            {
                return DataBaseClass.GetAllPublishers();
            }
        }



        public Action CloseAction { get; set; }
        public override void Add()
        {

            if (string.IsNullOrWhiteSpace(item.Title)) item.Title = "Tytuł...";
            if (string.IsNullOrWhiteSpace(item.PublishedYear)) item.PublishedYear = "Rok wydania...";
            if (string.IsNullOrWhiteSpace(item.Description)) item.Description = "Opis...";
            if (string.IsNullOrWhiteSpace(item.CoverImagePath)) item.CoverImagePath = "Okładka...";

            DataBaseClass.Instance.Books.Add(item);
            DataBaseClass.Instance.SaveChanges();

            CloseAction?.Invoke();
        }

        public override void Cancel()
        {
            CloseAction?.Invoke();
        }
    }
}
