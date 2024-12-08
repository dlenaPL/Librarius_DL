using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

namespace Librarius_DL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            hideSubMenus();
      
        }

        private void toggleVisibility(StackPanel panel)
        {
            if (panel.Visibility == Visibility.Collapsed)
                panel.Visibility = Visibility.Visible;
            else if (panel.Visibility == Visibility.Visible)
                panel.Visibility = Visibility.Collapsed;
        }

        private void hideSubMenus()
        {
            edit_submenu.Visibility = Visibility.Collapsed;
            settings_submenu.Visibility = Visibility.Collapsed;
        }




        private void clearRadioBtnsIsChecked(StackPanel sp)
        {
            foreach (RadioButton r in sp.Children)
            {
                if (r.IsChecked == true) r.IsChecked = false;
            }
        }



        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            toggleVisibility(edit_submenu);
            btn_edit.IsChecked = false;
            clearRadioBtnsIsChecked(settings_submenu);

        }


        private void btn_settings_Click(object sender, RoutedEventArgs e)
        {
            toggleVisibility(settings_submenu);
            btn_settings.IsChecked = false;
            clearRadioBtnsIsChecked(edit_submenu);
        }
    }
}
