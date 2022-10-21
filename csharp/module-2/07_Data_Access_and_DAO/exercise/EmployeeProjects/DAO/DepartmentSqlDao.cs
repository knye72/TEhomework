using EmployeeProjects.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeProjects.DAO
{
    public class DepartmentSqlDao : IDepartmentDao
    {
        private readonly string connectionString;

        public DepartmentSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Department GetDepartment(int departmentId)
        {
            Department dept = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM department WHERE department_id = @department_id", conn);
                cmd.Parameters.AddWithValue("@department_id", departmentId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    dept = CreateDeptFromReader(reader);

                }
            }
            return dept;

        }



        public void UpdateDepartment(Department updatedDepartment) //name is the only parameter. 

        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("UPDATE department SET name = @name WHERE department_id = @dept_id;", conn);
                cmd.Parameters.AddWithValue("@name", updatedDepartment.Name);
                cmd.Parameters.AddWithValue("@dept_id", updatedDepartment.DepartmentId);


                cmd.ExecuteNonQuery();


            }
        }

        private Department CreateDeptFromReader(SqlDataReader reader)
        {
            Department dept = new Department();
            dept.DepartmentId = Convert.ToInt32(reader["department_id"]);
            dept.Name = Convert.ToString(reader["name"]);

            return dept;
        }

        public IList<Department> GetAllDepartments()
        {
            IList<Department> departments = new List<Department>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM department", conn);
                

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Department department = CreateDeptFromReader(reader);
                    departments.Add(department);
                }
            }
            return departments;
        }

       
    }
}
