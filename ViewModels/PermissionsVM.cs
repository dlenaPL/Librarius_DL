using Librarius_DL.Models.Entities;
using Librarius_DL.Utilities.BusinessLogic;
using Librarius_DL.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Permissions = Librarius_DL.Models.Entities.Permissions;

namespace Librarius_DL.ViewModels
{
    public class PermissionsVM : Utilities.AllViewModel<Permissions>
    {
        public override void Load()
        {
            List = new ObservableCollection<Permissions>(DataBaseClass.Instance.Permissions.ToList());

        }

        public override void Add()
        {

            var addNewPermissionWindow = new AddNewPermission();
            var addNewPermissionVM = (AddNewPermissionVM)addNewPermissionWindow.DataContext;

            addNewPermissionWindow.ShowDialog();

            Load();
        }
    }
}
