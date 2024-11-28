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
    /// Interaction logic for AddNewMember.xaml
    /// </summary>
    public partial class AddNewMember : AddNewItemViewBase
    {
        public AddNewMember()
        {
            InitializeComponent();
            var viewModel = new AddNewMemberVM();
            viewModel.CloseAction = () => this.Close();
            DataContext = viewModel;
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.DataContext is AddNewMemberVM viewModel)
            {
                switch (textBox.Name)
                {
                    case "tbMemberName":
                        viewModel.FirstName = string.Empty;
                        break;
                    case "tbMemberLastName":
                        viewModel.LastName = string.Empty;
                        break;
                    case "tbMemberContactInfo":
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
