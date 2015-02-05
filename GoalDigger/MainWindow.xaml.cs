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

namespace GoalDigger
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

        private void NavStateTransfer(string NavTransfer)
        {
            NavStateTextBox.IsReadOnly = false;
            NavStateTextBox.Text = NavTransfer;
            NavStateTextBox.IsReadOnly = true;
            if (NavTransfer == "DashBoard")
            {
                BackNavButton.IsEnabled = false;
                EnableMainFeatureButtons();
            }
            else
            {
                BackNavButton.IsEnabled = true;
                DisableMainFeatureButtons();
            }   
        }

        private void DisableMainFeatureButtons()
        {
            Budget.IsEnabled = false;
            Profile.IsEnabled = false;
            Update.IsEnabled = false;
            WishList.IsEnabled = false;
        }

        private void EnableMainFeatureButtons()
        {
            Budget.IsEnabled = true;
            Profile.IsEnabled = true;
            Update.IsEnabled = true;
            WishList.IsEnabled = true;
        }

        private void BudgetButton_Click(object sender, RoutedEventArgs e)
        {
            NavStateTransfer("Budget");
            BackNavButton.IsEnabled = true;
        }

        private void BackNav_Click(object sender, RoutedEventArgs e)
        {
            NavStateTransfer("DashBoard");
        }

        private void    ProfileButton_Click(object sender, RoutedEventArgs e)
        {
            NavStateTransfer("Profile");
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            NavStateTransfer("Update");
        }

        private void WishListButton_Click(object sender, RoutedEventArgs e)
        {
            NavStateTransfer("Wish List");
        }

    }
}
