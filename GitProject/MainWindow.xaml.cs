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

namespace GitProject
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
            if (sender == btnSearch)
            {
                MessageBox.Show("Search ni");
            }
            else if (sender == btnRefresh)
            {
                MessageBox.Show("Refresh ni");
            }
            else if (sender == btnAddStudent)
            {
                MessageBox.Show("Add Student ni");
            }
        }

        private void btnViewDetail_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnAddGuardian_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
