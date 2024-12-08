using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities;
using System;

namespace Librarius_DL.ViewModels
{
    public class AddNewPermissionVM : AddNewItemVM<Permissions>
    {
        public AddNewPermissionVM()
        {
            item = new Permissions();
            item.PermissionName = "Tymczasowa nazwa";
            item.PermissionDescription = "Krotki opis";
        }

        public string PermissionName
        {
            get => item.PermissionName;
            set
            {
                item.PermissionName = value;
                OnPropertyChanged(nameof(PermissionName));
            }
        }

        public string PermissionDescription
        {
            get => item.PermissionDescription;
            set
            {
                item.PermissionDescription = value;
                OnPropertyChanged(nameof(PermissionDescription));
            }
        }

        public Action CloseAction { get; set; }

        public override void Add()
        {
            if (string.IsNullOrWhiteSpace(item.PermissionName)) item.PermissionName = "Tymczasowa nazwa";
            if (string.IsNullOrWhiteSpace(item.PermissionDescription)) item.PermissionDescription = "Tymczasowa opis";

            libraryEntities.Permissions.Add(item);
            libraryEntities.SaveChanges();

            CloseAction?.Invoke();
        }

        public override void Cancel()
        {
            CloseAction?.Invoke();
        }
    }
}
