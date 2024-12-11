using Librarius_DL.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Librarius_DL.Views
{
    /// <summary>
    /// Interaction logic for AddNewStaff.xaml
    /// </summary>
    public partial class AddNewStaff : AddNewItemViewBase
    {
        public AddNewStaff()
        {
            InitializeComponent();
            var viewModel = new AddNewStaffVM();
            viewModel.CloseAction = () => this.Close();
            DataContext = viewModel;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.DataContext is AddNewStaffVM viewModel)
            {
                switch (textBox.Name)
                {
                    case "tbStaffFirstName":
                        viewModel.FirstName = string.Empty;
                        break;
                    case "tbStaffLastName":
                        viewModel.LastName = string.Empty;
                        break;
                    case "tbContactInfo":
                        viewModel.ContactInfo = string.Empty;
                        break;
                    default:
                        textBox.Clear();
                        break;
                }
            }
        }
    }
}
