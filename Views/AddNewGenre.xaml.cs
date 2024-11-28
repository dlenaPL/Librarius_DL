using Librarius_DL.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Librarius_DL.Views
{
    /// <summary>
    /// Interaction logic for AddNewGenre.xaml
    /// </summary>
    public partial class AddNewGenre : AddNewItemViewBase
    {
        public AddNewGenre()
        {
            InitializeComponent();
            var viewModel = new AddNewGenreVM();
            viewModel.CloseAction = () => this.Close();
            DataContext = viewModel;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.DataContext is AddNewGenreVM viewModel)
            {
                switch (textBox.Name)
                {
                    case "tbGenreName":
                        viewModel.GenreName = string.Empty;
                        break;
                    default:
                        textBox.Clear();
                        break;
                }
            }
        }
    }
}
