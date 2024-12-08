using Librarius_DL.ViewModels;
using System.Windows.Controls;
using System.Windows;

namespace Librarius_DL.Views
{
    /// <summary>
    /// Interaction logic for AddNewPermission.xaml
    /// </summary>
    public partial class AddNewPermission : AddNewItemViewBase
    {
        public AddNewPermission()
        {
            InitializeComponent();
            var viewModel = new AddNewPermissionVM();
            viewModel.CloseAction = () => this.Close();
            DataContext = viewModel;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.DataContext is AddNewPermissionVM viewModel)
            {
                switch (textBox.Name)
                {
                    case "tbPermissionName":
                        viewModel.PermissionName = string.Empty;
                        break;
                    case "tbPermissionDescription":
                        viewModel.PermissionDescription = string.Empty;
                        break;
                    default:
                        textBox.Clear();
                        break;
                }
            }
        }
    }
}
