using GitProject.Controller;
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
        Student_Controller ctrl_Students = new Student_Controller();
        Guardian_Controller ctrl_Guardians = new Guardian_Controller();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnSearch)
            {
                dgDetails.ItemsSource = ctrl_Students.Search(txtSearch.Text).DefaultView;//SEARCH
            }
            else if (sender == btnRefresh)
            {
                dgDetails.ItemsSource = ctrl_Students.Reload_Data().DefaultView;//RELOAD DATA
            }
            else if (sender == btnAddStudent)
            {
                Window form = new StudentWindow();
                form.ShowDialog();
                dgDetails.ItemsSource = ctrl_Students.Reload_Data().DefaultView;//RELOAD DATA
            }
        }

        private void btnViewDetail_Click(object sender, RoutedEventArgs e)
        {
            Window form = new ViewDetails();
            form.ShowDialog();
            dgDetails.ItemsSource = ctrl_Students.Reload_Data().DefaultView;//RELOAD DATA
        }

        private void btnAddGuardian_Click(object sender, RoutedEventArgs e)
        {
            Window form = new GuardianWindow();
            form.ShowDialog();
            dgDetails.ItemsSource = ctrl_Students.Reload_Data().DefaultView;//RELOAD DATA
        }
    }
}
