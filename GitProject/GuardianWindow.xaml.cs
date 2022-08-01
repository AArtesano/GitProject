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
using GitProject.Controller;

namespace GitProject
{
    /// <summary>
    /// Interaction logic for GuardianWindow.xaml
    /// </summary>
    public partial class GuardianWindow : Window
    {
        Student_Controller ctrl_Students = new Student_Controller();
        Guardian_Controller ctrl_guardians = new Guardian_Controller();
        public GuardianWindow(Student_Controller ctrl_Students)
        {
            InitializeComponent();
            this.ctrl_Students = ctrl_Students;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnSave)
            {
                ctrl_guardians.Firstname = txtFirstname.Text;
                ctrl_guardians.Middlename = txtMiddlename.Text;
                ctrl_guardians.Lastname = txtLastname.Text;
                ctrl_guardians.Relationship = txtRelationship.Text;
                ctrl_guardians.Birthdate = Convert.ToDateTime(dtpBirthday.Text);

                if (ctrl_guardians.Insert(ctrl_guardians, ctrl_Students) == true)
                {
                    //MessageBox.Show("Save Successfully!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                    MessageBox.Show("Saved Successfuly!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Unable to save");
                }
            }

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //Hindi na butangan message
            if (MessageBox.Show("Cancel?", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.OK)
            {
                this.Close();
            }
        }
    }
}
