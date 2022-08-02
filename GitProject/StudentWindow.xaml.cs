using GitProject.Controller;
using System;
using System.Windows;

namespace GitProject
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        Student_Controller ctrl_students = new Student_Controller();
        public StudentWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnSave)
            {
                ctrl_students.Firstname = txtFirstname.Text;
                ctrl_students.Middlename = txtMiddlename.Text;
                ctrl_students.Lastname = txtLastname.Text;
                ctrl_students.Birthdate = Convert.ToDateTime(dtpBirthday.Text);
                if (ctrl_students.Insert(ctrl_students) == true)
                {
                    MessageBox.Show("Successfully Added!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
                else
                    MessageBox.Show("Unable to save! Please contact the administrator", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (sender == btnCancel)
            {
                if (MessageBox.Show("Are you sure to cancel?", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    this.Close();
                }
            }
        }


    }
}
