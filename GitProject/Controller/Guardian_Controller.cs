using GitProject.Model;
using System.Data;
using System.Data.SqlClient;

namespace GitProject.Controller
{
    public class Guardian_Controller : Guardian_Model
    {
        bool result = false;
        SqlCommand cmd = new SqlCommand();
        public bool Insert(Guardian_Controller ctrl_Guardians, Student_Controller ctrl_Students)
        {
            cmd = new SqlCommand("INSERT INTO Guardians (StudentID, Firstname, MiddleIntial, Lastname, Birthdate, Relationship) VALUES (@StudentID, @Firstname, @Middlename, @Lastname, @Birthday, @Relationship)");
            //cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StudentID", ctrl_Students.StudentID);
            cmd.Parameters.AddWithValue("@Firstname", ctrl_Guardians.Firstname);
            cmd.Parameters.AddWithValue("@Middlename", ctrl_Guardians.Middlename);
            cmd.Parameters.AddWithValue("@Lastname", ctrl_Guardians.Lastname);
            cmd.Parameters.AddWithValue("@Birthday", ctrl_Guardians.Birthdate.ToString());
            cmd.Parameters.AddWithValue("@Relationship", ctrl_Guardians.Relationship);
            result = Queries_Controller.ExecNonQuery(cmd);
            return result;
        }
        public bool Update(Guardian_Controller ctrl_Guardians)
        {
            cmd = new SqlCommand("UPDATE Guardians SET Firstname = @Firstname, MiddleIntial = @Middlename, Lastname = @Lastname, Birthdate = @Birthday, Relationship = @Relationship WHERE GuardianID = @GuardianID ");
            //cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@GuardianID", ctrl_Guardians.GuardianID);
            cmd.Parameters.AddWithValue("@Firstname", ctrl_Guardians.Firstname);
            cmd.Parameters.AddWithValue("@Middlename", ctrl_Guardians.Middlename);
            cmd.Parameters.AddWithValue("@Lastname", ctrl_Guardians.Lastname);
            cmd.Parameters.AddWithValue("@Birthday", ctrl_Guardians.Birthdate.ToString());
            cmd.Parameters.AddWithValue("@Relationship", ctrl_Guardians.Relationship);
            result = Queries_Controller.ExecNonQuery(cmd);
            return result;
        }
        public DataTable Reload_Data(Student_Controller ctrl_Students)
        {
            DataTable dt = new DataTable();
            cmd = new SqlCommand("SELECT GuardianID, Firstname, MiddleIntial, Lastname, CONVERT(char(10), Guardians.Birthdate, 126) AS Birthdate, Relationship FROM Guardians WHERE StudentID = @StudentID");
            cmd.Parameters.AddWithValue("@StudentID", ctrl_Students.StudentID);
            dt = Queries_Controller.LoadData(cmd);
            return dt;
        }
        public bool Delete(Guardian_Controller ctrl)
        {
            cmd = new SqlCommand("DELETE FROM Guardians WHERE GuardianID = @GuardianID");
            cmd.Parameters.AddWithValue("@GuardianID", ctrl.GuardianID);
            result = Queries_Controller.ExecNonQuery(cmd);
            return result;
        }
    }
}
