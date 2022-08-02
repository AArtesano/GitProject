using System;
using System.Windows;
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
        Boolean FromMainWindow;
        public GuardianWindow(Student_Controller ctrl_Students, Guardian_Controller ctrl_guardians, Boolean FromMainWindow)
        {
            InitializeComponent();
            this.ctrl_Students = ctrl_Students;
            this.ctrl_guardians = ctrl_guardians;
            this.FromMainWindow = FromMainWindow;
            if (FromMainWindow == false)
            {
                txtFirstname.Text = ctrl_guardians.Firstname;
                txtMiddlename.Text = ctrl_guardians.Middlename;
                txtLastname.Text = ctrl_guardians.Lastname;
                dtpBirthday.Text = ctrl_guardians.Birthdate.ToString();
                txtRelationship.Text = ctrl_guardians.Relationship;
            }
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
                if (FromMainWindow == true)//Halin sa Main Window
                {
                    if (txtFirstname.Text == "" || txtLastname.Text == "" || dtpBirthday.Text == "")
                    {
                        MessageBox.Show("Please fill the information box.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        ctrl_guardians.Firstname = txtFirstname.Text;
                        ctrl_guardians.Middlename = txtMiddlename.Text;
                        ctrl_guardians.Lastname = txtLastname.Text;
                        ctrl_guardians.Birthdate = Convert.ToDateTime(dtpBirthday.Text);
                        ctrl_guardians.Relationship = txtRelationship.Text;

                        if (ctrl_guardians.Insert(ctrl_guardians, ctrl_Students) == true)
                        {
                            MessageBox.Show("Saved Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Unable to saved. Please contact the administrator", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else//Halin sa View Details
                {
                    if (txtFirstname.Text == "" || txtLastname.Text == "" || txtRelationship.Text == "")
                    {
                        MessageBox.Show("Please fill the information box.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    else
                    {
                        if (MessageBox.Show("The data will be change. Will you proceed?", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                        {
                            ctrl_guardians.Firstname = txtFirstname.Text;
                            ctrl_guardians.Middlename = txtMiddlename.Text;
                            ctrl_guardians.Lastname = txtLastname.Text;
                            ctrl_guardians.Birthdate = Convert.ToDateTime(dtpBirthday.Text);
                            ctrl_guardians.Relationship = txtRelationship.Text;

                            if (ctrl_guardians.Update(ctrl_guardians) == true)
                            {
                                MessageBox.Show("Changed Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Unable to change. Please contact the administrator", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                }
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure to cancel?", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
