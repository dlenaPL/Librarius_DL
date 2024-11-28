using Librarius_DL.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Librarius_DL.Views
{
    /// <summary>
    /// Interaction logic for AddNewFineStatus.xaml
    /// </summary>
    public partial class AddNewFineStatus : AddNewItemViewBase
    {
        public AddNewFineStatus()
        {
            InitializeComponent();
            var viewModel = new AddNewFineStatusVM();
            viewModel.CloseAction = () => this.Close();
            DataContext = viewModel;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.DataContext is AddNewFineStatusVM viewModel)
            {
                switch (textBox.Name)
                {
                    case "tbFineStatusName":
                        viewModel.FineStatusName = string.Empty;
                        break;
                    case "tbFineStatusDescription":
                        viewModel.FineStatusDescription = string.Empty;
                        break;
                    default:
                        textBox.Clear();
                        break;
                }
            }
        }
    }
}
