using Librarius_DL.ViewModels;
using System.Windows.Controls;
using System.Windows;

namespace Librarius_DL.Views
{
    /// <summary>
    /// Interaction logic for AddNewStatus.xaml
    /// </summary>
    public partial class AddNewStatus : AddNewItemViewBase
    {
        public AddNewStatus()
        {
            InitializeComponent();
            var viewModel = new AddNewStatusVM();
            viewModel.CloseAction = () => this.Close();
            DataContext = viewModel;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.DataContext is AddNewStatusVM viewModel)
            {
                switch (textBox.Name)
                {
                    case "tbStatusName":
                        viewModel.StatusName = string.Empty;
                        break;
                    case "tbStatusDescription":
                        viewModel.StatusDescription = string.Empty;
                        break;
                    default:
                        textBox.Clear();
                        break;
                }
            }
        }
    }
}
