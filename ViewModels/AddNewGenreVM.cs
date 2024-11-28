using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities;
using System;

namespace Librarius_DL.ViewModels
{
    class AddNewGenreVM : AddNewItemVM<Genres>
    {


        public AddNewGenreVM()
        {
            item = new Genres();
            item.GenreName = "Nazwa gatunku...";
        }

        public string GenreName
        {
            get => item.GenreName;
            set
            {
                item.GenreName = value;
                OnPropertyChanged(nameof(GenreName));
            }
        }


        public Action CloseAction { get; set; }

        public override void Add()
        {
            if (string.IsNullOrWhiteSpace(item.GenreName)) item.GenreName = "Tymczasowa nazwa gatunku";
            libraryEntities.Genres.Add(item);
            libraryEntities.SaveChanges();

            CloseAction?.Invoke();
        }

        public override void Cancel()
        {
            CloseAction?.Invoke();
        }
    }
}
