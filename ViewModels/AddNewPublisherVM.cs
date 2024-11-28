using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Librarius_DL.ViewModels
{
    class AddNewPublisherVM : AddNewItemVM<Publishers>
    {

        public AddNewPublisherVM()
        {
            item = new Publishers();
            item.PublisherName = "Nazwa wydawcy...";

        }

        public string PublisherName
        {
            get => item.PublisherName;
            set
            {
                item.PublisherName = value;
                OnPropertyChanged(nameof(PublisherName));
            }
        }

        public Action CloseAction { get; set; }
        public override void Add()
        {
            if (string.IsNullOrWhiteSpace(item.PublisherName)) item.PublisherName = "Tymczaasowa nazwa gatunku";
            libraryEntities.Publishers.Add(item);
            libraryEntities.SaveChanges();

            CloseAction?.Invoke();
        }

        public override void Cancel()
        {
            CloseAction?.Invoke();
        }
    }
}
