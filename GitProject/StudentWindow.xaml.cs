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
using System.Windows.Shapes;

namespace GitProject
{
    /// <summary>
    /// Interaction logic for StudentWindow.xaml
    /// </summary>
    public partial class StudentWindow : Window
    {
        Student_Controller ctrl_students = new Student_Controller();
        Guardian_Controller ctrl_guardians = new Guardian_Controller();
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
                    MessageBox.Show("Successfully Added!");
                    this.Close();
                }

                else
                    MessageBox.Show("Unable to save!");
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
