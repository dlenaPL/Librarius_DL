using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities;
using System;

namespace Librarius_DL.ViewModels
{
    class AddNewRoleVM : AddNewItemVM<Roles>
    {
        public AddNewRoleVM()
        {
            item = new Roles();
            item.RoleName = "Tymczasowa nazwa";
            item.RoleDescription = "Krotki opis";
        }

        public string RoleName
        {
            get => item.RoleName;
            set
            {
                item.RoleName = value;
                OnPropertyChanged(nameof(RoleName));
            }
        }

        public string RoleDescription
        {
            get => item.RoleDescription;
            set
            {
                item.RoleDescription = value;
                OnPropertyChanged(nameof(RoleDescription));
            }
        }


        public Action CloseAction { get; set; }

        public override void Add()
        {
            if (string.IsNullOrWhiteSpace(item.RoleName)) item.RoleName = "Tymczasowa nazwa roli";
            if (string.IsNullOrWhiteSpace(item.RoleDescription)) item.RoleDescription = "Tymczasowa opis";
            libraryEntities.Roles.Add(item);
            libraryEntities.SaveChanges();

            CloseAction?.Invoke();
        }

        public override void Cancel()
        {
            CloseAction?.Invoke();
        }
    }
}
