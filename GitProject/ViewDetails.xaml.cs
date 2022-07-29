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
    /// Interaction logic for ViewDetails.xaml
    /// </summary>
    public partial class ViewDetails : Window
    {
        public ViewDetails()
        {
            InitializeComponent();
            btnSave.IsEnabled = false;
            btnCancel.IsEnabled = false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnSave)
            {
                MessageBox.Show("Saved Successfully");
                btnSave.IsEnabled = false;
                btnCancel.IsEnabled = false;
                btnEdit.IsEnabled = true;
            }
            else if (sender == btnCancel)
            {
                btnSave.IsEnabled = false;
                btnCancel.IsEnabled = false;
                btnEdit.IsEnabled = true;
            }
            else if (sender == btnEdit)
            {
                btnSave.IsEnabled = true;
                btnCancel.IsEnabled = true;
                btnEdit.IsEnabled = false;
            }
            else if (sender == btnDelete)
            {
                MessageBox.Show("Deleted Successfully");
            }
            else if (sender == btnExit)
            {
                this.Close();
            }
        }
        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            Window form = new StudentWindow();
            form.ShowDialog();
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Deleted Successfully");
        }
    }
}
