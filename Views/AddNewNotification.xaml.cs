using Librarius_DL.ViewModels;
using System.Windows.Controls;
using System.Windows;

namespace Librarius_DL.Views
{
    /// <summary>
    /// Interaction logic for AddNewNotification.xaml
    /// </summary>
    public partial class AddNewNotification : AddNewItemViewBase
    {
        public AddNewNotification()
        {
            InitializeComponent();
            var viewModel = new AddNewNotificationVM();
            viewModel.CloseAction = () => this.Close();
            DataContext = viewModel;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.DataContext is AddNewNotificationVM viewModel)
            {
                switch (textBox.Name)
                {
                    case "tbNotificationMessage":
                        viewModel.Message = string.Empty;
                        break;


                    default:
                        textBox.Clear();
                        break;
                }
            }
        }
    }
}
