using System.Data;
using System.Data.SqlClient;
using System.Windows;
using GitProject.Model;

namespace GitProject.Controller
{
    public class Student_Controller : Student_Model
    {
        bool result = false;
        SqlCommand cmd = new SqlCommand();
        public bool Insert(Student_Controller ctrl)
        {
            cmd = new SqlCommand("INSERT INTO Students (Firstname, Middlename, Lastname, Birthdate) VALUES (@Firstname, @Middlename, @Lastname, @Birthday)");
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Firstname", ctrl.Firstname);
            cmd.Parameters.AddWithValue("@Middlename", ctrl.Middlename);
            cmd.Parameters.AddWithValue("@Lastname", ctrl.Lastname);
            cmd.Parameters.AddWithValue("@Birthday", ctrl.Birthdate.ToString());
            result = Queries_Controller.ExecNonQuery(cmd);
            return result;
        }

        public bool Update(Student_Controller ctrl)
        {
            cmd = new SqlCommand("UPDATE Students SET Firstname = @Firstname, Middlename = @Middlename, Lastname = @Lastname, Birthdate = @Birthday WHERE StudentID = @StudentID");
            //cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@StudentID", ctrl.StudentID);
            cmd.Parameters.AddWithValue("@Firstname", ctrl.Firstname);
            cmd.Parameters.AddWithValue("@Middlename", ctrl.Middlename);
            cmd.Parameters.AddWithValue("@Lastname", ctrl.Lastname);
            cmd.Parameters.AddWithValue("@Birthday", ctrl.Birthdate.ToString());
            result = Queries_Controller.ExecNonQuery(cmd);
            return result;
        }
        public DataTable Reload_Data()
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand("SELECT Students.StudentID, Students.Firstname, Students.Middlename, Students.Lastname, CONVERT(char(10), Students.Birthdate, 126) AS Birthdate, COUNT(Guardians.GuardianID) AS 'Number of Guardians' FROM Students LEFT JOIN Guardians ON Students.StudentID = Guardians.StudentID GROUP BY Students.StudentID, Students.Firstname, Students.Middlename, Students.Lastname, Students.Birthdate");
            dt = Queries_Controller.LoadData(cmd);
            return dt;
        }
        public bool Delete(Student_Controller ctrl)
        {
            cmd = new SqlCommand("DELETE FROM Guardians WHERE StudentID = @StudentID ; DELETE FROM Students WHERE StudentID = @StudentID");
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StudentID", ctrl.StudentID);
            result = Queries_Controller.ExecNonQuery(cmd);
            return result;
        }
        public DataTable Search(string Name)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd = new SqlCommand("SELECT StudentID, Firstname, Middlename, Lastname, CONVERT(char(10), Students.Birthdate, 126) AS Birthdate FROM Students WHERE Firstname LIKE '%" + Name + "%' OR Middlename LIKE '%" + Name + "%' OR Lastname LIKE '%" + Name + "%'");
                dt = Queries_Controller.LoadData(cmd);
                return dt;
            }
            catch
            {
                MessageBox.Show("Unable to search. Please contact the administrator", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }
    }
}
