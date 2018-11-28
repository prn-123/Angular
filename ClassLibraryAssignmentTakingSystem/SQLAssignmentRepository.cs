using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ClassLibraryAssignmentTakingSystem
{
    public class SQLAssignmentRepository : IAssignmentRepository
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=AssignmentTakingSystem;Integrated Security=True");
        public Assignment FindAssignment(int AssignmentId)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Assignment where AssignmentId = " + AssignmentId, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            Assignment a = new Assignment();
            while(dr.Read())
            {
                a.AssignmentId = Int32.Parse(dr["AssignmentId"].ToString());
                a.AssignmentName = dr["AssignmentName"].ToString();
                a.EmployeeName = dr["EmployeeName"].ToString();
                a.Date = DateTime.Parse(dr["Date"].ToString());
            }
            cn.Close();
            return a;
        }
        List<Assignment> glAssignment = new List<Assignment>();

        public List<Assignment> GetAssignment()
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("Select * from Assignment", cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                Assignment a = new Assignment
                {
                    AssignmentId = Int32.Parse(dr["AssignmentId"].ToString()),
                    AssignmentName = dr["AssignmentName"].ToString(),
                    EmployeeName = dr["EmployeeName"].ToString(),
                    Date = DateTime.Parse( dr["Date"].ToString())
                };
                glAssignment.Add(a);
            }
            cn.Close();
            return glAssignment;
        }

        public void Insert(Assignment a)
        {
            cn.Open();
            SqlCommand cmd = new SqlCommand("insert into Assignment values" +
                "('" + a.AssignmentName + "','" + a.EmployeeName + "','" +  DateTime.Parse( a.Date.ToString()) + "'", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }
}
