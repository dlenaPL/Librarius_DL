using Librarius_DL.ViewModels;
using System.Windows.Controls;
using System.Windows;

namespace Librarius_DL.Views
{
    /// <summary>
    /// Interaction logic for AddNewRole.xaml
    /// </summary>
    public partial class AddNewRole : AddNewItemViewBase
    {
        public AddNewRole()
        {
            InitializeComponent();
            var viewModel = new AddNewRoleVM();
            viewModel.CloseAction = () => this.Close();
            DataContext = viewModel;
        }


        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.DataContext is AddNewRoleVM viewModel)
            {
                switch (textBox.Name)
                {
                    case "tbRoleName":
                        viewModel.RoleName = string.Empty;
                        break;
                    case "tbRoleDescription":
                        viewModel.RoleDescription = string.Empty;
                        break;
                    default:
                        textBox.Clear();
                        break;
                }
            }
        }

    }
}
