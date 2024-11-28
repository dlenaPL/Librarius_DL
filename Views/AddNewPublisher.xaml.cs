using Librarius_DL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Librarius_DL.Views
{
    /// <summary>
    /// Interaction logic for AddNewPublisher.xaml
    /// </summary>
    public partial class AddNewPublisher : AddNewItemViewBase
    {
        public AddNewPublisher()
        {
            InitializeComponent();
            var viewModel = new AddNewPublisherVM();
            viewModel.CloseAction = () => this.Close();
            DataContext = viewModel;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.DataContext is AddNewPublisherVM viewModel)
            {
                switch (textBox.Name)
                {
                    case "tbPublisherName":
                        viewModel.PublisherName = string.Empty;
                        break;
                    default:
                        textBox.Clear();
                        break;
                }
            }
        }
    }
}
