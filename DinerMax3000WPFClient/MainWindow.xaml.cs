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

namespace DinerMax3000WPFClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /// Access Data Context we are working in to get created instance of ViewModel
            DinerMax3000.WPFClient.DinerMax3000ViewModel currentViewModel =
                (DinerMax3000.WPFClient.DinerMax3000ViewModel)DataContext;

            foreach (var currentMenuItem in currentViewModel.NewMenuItems)
            {
                currentViewModel.SelectedMenu.SaveNewMenuItem(currentMenuItem.Title, currentMenuItem.Description, currentMenuItem.Price);
            }
            
            /// From when we used text boxes -- start
            /// Set variable to hold new menu item object
            /// DinerMax3000.Business.MenuItem newMenuItem = currentViewModel.NewMenuItem;
            /// Call SaveNewMenuItem
            ///currentViewModel.SelectedMenu.SaveNewMenuItem(newMenuItem.Title, newMenuItem.Description, newMenuItem.Price);
            /// -- end 

            /// Update ComboBox
            BindingOperations.GetBindingExpressionBase(cboAllMenus, ComboBox.ItemsSourceProperty).UpdateTarget();

            // GBru test: Clear text boxes and disable save button
            //newMenuItem.Title = "";
            //newMenuItem.Price = 0;
            //newMenuItem.Description = "";
            //btnSave.IsEnabled = false;
        }

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            DinerMax3000.Business.MenuItem newMenuItem = e.Row.Item as DinerMax3000.Business.MenuItem;
            if (newMenuItem != null && e.EditAction == DataGridEditAction.Commit && e.Row.IsNewItem)
            {
                DinerMax3000.WPFClient.DinerMax3000ViewModel currentViewModel =
                    (DinerMax3000.WPFClient.DinerMax3000ViewModel)DataContext;
                currentViewModel.NewMenuItems.Add(newMenuItem);
            }

        }
    }
}
