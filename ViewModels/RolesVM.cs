using Librarius_DL.Views;
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
    }
}
