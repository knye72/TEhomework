using EmployeeProjects.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeProjects.DAO
{
    public class EmployeeSqlDao : IEmployeeDao
    {
        private readonly string connectionString;

        public EmployeeSqlDao(string connString)
        {
            connectionString = connString;
        }

        public IList<Employee> GetAllEmployees()
        {
            IList<Employee> employees = new List<Employee>(); 

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM employee", conn);

                SqlDataReader reader = cmd.ExecuteReader(); 
                while (reader.Read())
                {
                    Employee employee = CreateEmployeeFromReader(reader);
                    employees.Add(employee);
                }

            }
            return employees;
        }

        public IList<Employee> SearchEmployeesByName(string firstNameSearch, string lastNameSearch)
        {
            IList<Employee> employees = new List<Employee>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd;
                if((firstNameSearch == "" || firstNameSearch == null) && (lastNameSearch == "" || lastNameSearch == null) )
                {
                    cmd = new SqlCommand("SELECT * FROM employee", conn);
                    
                }
                if((firstNameSearch == "" || firstNameSearch == null))
                {
                    cmd = new SqlCommand("SELECT * FROM employee WHERE last_name LIKE @lastNameSearch", conn);
                    string searchLastName = ("%" + lastNameSearch + "%");
                    cmd.Parameters.AddWithValue("@lastNameSearch", searchLastName);
                }
                if((lastNameSearch == "" || lastNameSearch == null))
                {
                    cmd = new SqlCommand("SELECT * FROM employee WHERE first_name LIKE @firstNameSearch", conn);
                    string searchFirstName = ("%" + firstNameSearch + "%");
                    cmd.Parameters.AddWithValue("@firstNameSearch", searchFirstName);
                }
                else
                {
                    cmd = new SqlCommand("SELECT * FROM employee WHERE first_name LIKE @firstNameSearch AND last_name LIKE @lastNameSearch", conn);
                    string searchFirstName = ("%" + firstNameSearch + "%");
                    cmd.Parameters.AddWithValue("@firstNameSearch", searchFirstName);
                    string searchLastName = ("%" + lastNameSearch + "%");
                    cmd.Parameters.AddWithValue("@lastNameSearch", searchLastName);
                    
                    
                }

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = CreateEmployeeFromReader(reader);
                    employees.Add(employee);
                }
            }

                return employees;
        }

        public IList<Employee> GetEmployeesByProjectId(int projectId)
        {
            IList<Employee> employees = new List<Employee>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT first_name, last_name FROM employee JOIN project_employee ON project_employee.employee_id = employee.employee_id WHERE project_id = @project_id", conn);
                cmd.Parameters.AddWithValue("@project_id", projectId);
                SqlDataReader reader = cmd.ExecuteReader(); //executes the select query

                while (reader.Read())
                {
                    Employee employee = CreateEmployeeFromReader(reader);
                    employees.Add(employee);
                }

            }
            return employees;
        }

        public void AddEmployeeToProject(int projectId, int employeeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO project_employee(project_id, employee_id " +
                    "VALUES(@project_id, @employee_id", conn);
                cmd.Parameters.AddWithValue("@project_id", projectId);
                cmd.Parameters.AddWithValue("@employee_id", employeeId);

                cmd.ExecuteNonQuery();
            }
        }

        public void RemoveEmployeeFromProject(int projectId, int employeeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE FROM project_employee WHERE project_id = @project_id AND employee_id = @employee_id", conn);
                cmd.Parameters.AddWithValue("@project_id", projectId);
                cmd.Parameters.AddWithValue("@employee_id", employeeId);

                cmd.ExecuteNonQuery();

                /*SqlCommand cmdTwo = new SqlCommand("DELETE FROM timesheet WHERE project_id = @project_id AND employee_id = @employee_id", conn);
                cmdTwo.Parameters.AddWithValue("@project_id", projectId);
                cmdTwo.Parameters.AddWithValue("@employee_id", employeeId);

                cmdTwo.ExecuteNonQuery();

                SqlCommand cmdThree = new SqlCommand("DELETE FROM project WHERE project_id = @project_id AND employee_id = @employee_id", conn);
                cmdThree.Parameters.AddWithValue("@project_id", projectId);
                cmdThree.Parameters.AddWithValue("@employee_id", employeeId);

                cmdThree.ExecuteNonQuery();*/
            }
        }

        public IList<Employee> GetEmployeesWithoutProjects()
        {
            IList<Employee> employees = new List<Employee>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM employee JOIN project_employee ON employee.employee_id = project_employee.employee_id WHERE project_id IS NULL", conn);

            }    
                
                return new List<Employee>();
        }

        private Employee CreateEmployeeFromReader(SqlDataReader reader)
        {
            Employee employee = new Employee();
            employee.EmployeeId = Convert.ToInt32(reader["employee_id"]);
            employee.DepartmentId = Convert.ToInt32(reader["department_id"]);
            employee.FirstName = Convert.ToString(reader["first_name"]);
            employee.LastName = Convert.ToString(reader["last_name"]);
            employee.BirthDate = Convert.ToDateTime(reader["birth_date"]);
            employee.HireDate = Convert.ToDateTime(reader["hire_date"]);

            return employee;

        }
    }
}
