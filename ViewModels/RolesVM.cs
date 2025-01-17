using Librarius_DL.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Roles = Librarius_DL.Models.Entities.Roles;

namespace Librarius_DL.ViewModels
{
    public class RolesVM : Utilities.AllViewModel<Roles>
    {
        public override void Load()
        {
            List = new ObservableCollection<Roles>(libraryEntities.Roles.ToList());

        }

        public override void Add()
        {

            var addNewRoleWindow = new AddNewRole();
            var addNewRoleVM = (AddNewRoleVM)addNewRoleWindow.DataContext;

            addNewRoleWindow.ShowDialog();

            Load();
        }

        public override List<string> GetComboboxSortList()
        {
            return new List<string> { "Nazwa" };
        }

        public override void Sort()
        {
            if (SortField == "Nazwa") List = new ObservableCollection<Roles>(List.OrderBy(item => item.RoleName));
        }

        public override List<string> GetComboboxFindList()
        {
            return new List<string> { "Nazwa" };
        }

        public override void Find()
        {
            Load();
            if (FindField == "Nazwa")
                List = new ObservableCollection<Roles>(List.Where(item => item.RoleName != null && item.RoleName.StartsWith(FindTextBox)));
        }
    }
}
