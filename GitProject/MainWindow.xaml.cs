using GitProject.Controller;
using System;
using System.Data;
using System.Windows;

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
            dgDetails.ItemsSource = ctrl_Students.Reload_Data().DefaultView;//INITIALIZE TABLES
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnSearch)
            {
                dgDetails.ItemsSource = ctrl_Students.Search(txtSearch.Text).DefaultView;//SEARCH
            }
            else if (sender == btnRefresh)
            {
                txtSearch.Clear();
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
            DataRowView drv = dgDetails.SelectedItem as DataRowView;
            ctrl_Students.StudentID = Convert.ToInt32(drv.Row["StudentID"].ToString());
            ctrl_Students.Firstname = drv.Row["Firstname"].ToString();
            ctrl_Students.Middlename = drv.Row["Middlename"].ToString();
            ctrl_Students.Lastname = drv.Row["Lastname"].ToString();
            ctrl_Students.Birthdate = Convert.ToDateTime(drv.Row["Birthdate"]);

            Window form = new ViewDetails(ctrl_Students);
            this.Hide();
            form.ShowDialog();
            dgDetails.ItemsSource = ctrl_Students.Reload_Data().DefaultView;//RELOAD DATA
            this.ShowDialog();
        }

        private void btnAddGuardian_Click(object sender, RoutedEventArgs e)
        {
            DataRowView drv = dgDetails.SelectedItem as DataRowView;
            ctrl_Students.StudentID = Convert.ToInt32(drv.Row["StudentID"].ToString());
            Window form = new GuardianWindow(ctrl_Students, ctrl_Guardians, true);
            form.ShowDialog();
            dgDetails.ItemsSource = ctrl_Students.Reload_Data().DefaultView;//RELOAD DATA
        }
    }
}
