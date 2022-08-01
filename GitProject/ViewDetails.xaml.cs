using GitProject.Controller;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for ViewDetails.xaml
    /// </summary>
    public partial class ViewDetails : Window
    {
        Student_Controller ctrl_Students = new Student_Controller();
        Guardian_Controller ctrl_Guardians = new Guardian_Controller();
        public ViewDetails(Student_Controller ctrl_Students)
        {
            InitializeComponent();
            this.ctrl_Students = ctrl_Students;
            dgDetails.ItemsSource = ctrl_Guardians.Reload_Data(ctrl_Students).DefaultView;
            ButtonVisibility(false, false, true, false, false, false, false, false);
            ShowInfo(ctrl_Students.Firstname, ctrl_Students.Middlename, ctrl_Students.Lastname, ctrl_Students.Birthdate);

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnSave)//UPDATE
            {
                if (txtFirstname.Text == "" || txtLastname.Text == "" || dtpBirthday.Text == "")
                {
                    MessageBox.Show("Please fill the information box.", "Warning!", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    if (MessageBox.Show("The data will be change. Will you proceed?", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        ctrl_Students.StudentID = ctrl_Students.StudentID;
                        ctrl_Students.Firstname = txtFirstname.Text;
                        ctrl_Students.Middlename = txtMiddlename.Text;
                        ctrl_Students.Lastname = txtLastname.Text;
                        ctrl_Students.Birthdate = Convert.ToDateTime(dtpBirthday.Text);
                        if (ctrl_Students.Update(ctrl_Students) == true)
                        {
                            ButtonVisibility(false, false, true, false, false, false, false, true);
                            ShowInfo(ctrl_Students.Firstname, ctrl_Students.Middlename, ctrl_Students.Lastname, ctrl_Students.Birthdate);
                            dgDetails.ItemsSource = ctrl_Guardians.Reload_Data(ctrl_Students).DefaultView;
                            MessageBox.Show("Change Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Unable to change. Please contact the administrator.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
            else if (sender == btnEdit)//EDIT
            {
                ButtonVisibility(true, true, false, true, true, true, true, false);
                txtFirstname.Text = ctrl_Students.Firstname;
                txtMiddlename.Text = ctrl_Students.Middlename;
                txtLastname.Text = ctrl_Students.Lastname;
                dtpBirthday.Text = ctrl_Students.Birthdate.ToString();
            }
            else if (sender == btnDelete)//DELETE
            {
                if (MessageBox.Show("This data will be remove. Will you proceed?", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    if (ctrl_Students.Delete(ctrl_Students) == true)
                    {
                        MessageBox.Show("Deleted Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Unable to delete. Please contact the administrator.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else if (sender == btnExit)//EXIT
            {
                this.Close();
            }
            else if (sender == btnCancel)//CANCEL
            {
                ButtonVisibility(false, false, true, false, false, false, false, true);
            }
        }
        private void btnRemove_Click(object sender, RoutedEventArgs e)//REMOVE GUARDIAN
        {
            DataRowView drv = dgDetails.SelectedItem as DataRowView;
            if (MessageBox.Show("The data will be remove. Will you proceed?", "Warning!", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                ctrl_Guardians.GuardianID = Convert.ToInt32(drv.Row["GuardianID"]);
                if (ctrl_Guardians.Delete(ctrl_Guardians) == true)
                {
                    dgDetails.ItemsSource = ctrl_Guardians.Reload_Data(ctrl_Students).DefaultView;
                    MessageBox.Show("Deleted Successfully", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Unable to delete", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
        private void btnChange_Click(object sender, RoutedEventArgs e)//CHANGE GUARDIAN
        {
            //DataRowView drv = dgDetails.SelectedItem as DataRowView;

            //ctrl_Guardians.GuardianID = Convert.ToInt32(drv.Row["GuardianID"].ToString());
            //ctrl_Guardians.Firstname = drv.Row["Firstname"].ToString();
            //ctrl_Guardians.Middlename = drv.Row["MiddleIntial"].ToString();
            //ctrl_Guardians.Lastname = drv.Row["Lastname"].ToString();
            //ctrl_Guardians.Birthdate = Convert.ToDateTime(drv.Row["Birthdate"]);
            //ctrl_Guardians.Relationship = drv.Row["Relationship"].ToString();
            //Window form = new GuardianWindow(false, ctrl_Guardians, ctrl_Students);
            //form.ShowDialog();
            //dgDetails.ItemsSource = ctrl_Guardians.Reload_Data(ctrl_Students).DefaultView;
        }
        //////////////////////////////////////// METHODS TO CALL ///////////////////////////////////////////////////////////////////////////////////////////////////////
        private void ButtonVisibility(Boolean Save, Boolean Cancel, Boolean Edit, Boolean Firstname, Boolean Middlename, Boolean Lastname, Boolean Birthday, Boolean ClearValue)
        {
            btnSave.IsEnabled = Save;
            btnCancel.IsEnabled = Cancel;
            btnEdit.IsEnabled = Edit;
            txtFirstname.IsEnabled = Firstname;
            txtMiddlename.IsEnabled = Middlename;
            txtLastname.IsEnabled = Lastname;
            dtpBirthday.IsEnabled = Birthday;

            if (ClearValue == true)
            {
                txtFirstname.Clear();
                txtMiddlename.Clear();
                txtLastname.Clear();
                dtpBirthday.Text = "";
            }
        }
        private void ShowInfo(string Firstname, string Middlename, string Lastname, DateTime Birthday)
        {
            int age = DateTime.Now.Year - ctrl_Students.Birthdate.Year;//Age
            Birthday.ToLongDateString();//Birthdate
            tbName.Text = "";
            tbAge.Text = "";
            tbBirthday.Text = "";
            this.tbName.Inlines.Add(new Run(" Name: ") { FontWeight = FontWeights.Bold });
            this.tbName.Inlines.Add(new Run(Firstname + " " + Middlename + " " + Lastname) { FontWeight = FontWeights.Regular });
            this.tbAge.Inlines.Add(new Run(" Age: ") { FontWeight = FontWeights.Bold });
            this.tbAge.Inlines.Add(new Run(age.ToString() + " years old") { FontWeight = FontWeights.Regular });
            this.tbBirthday.Inlines.Add(new Run(" Birthday: ") { FontWeight = FontWeights.Bold });
            this.tbBirthday.Inlines.Add(new Run(Birthday.ToString()) { FontWeight = FontWeights.Regular });
        }
    }
}
