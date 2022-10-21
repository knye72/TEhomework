using EmployeeProjects.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EmployeeProjects.DAO
{
    public class ProjectSqlDao : IProjectDao
    {
        private readonly string connectionString;

        public ProjectSqlDao(string connString)
        {
            connectionString = connString;
        }

        public Project GetProject(int projectId)
        {
            Project proj = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM project WHERE project_id = @project_id", conn);
                cmd.Parameters.AddWithValue("@project_id", projectId);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    proj = CreateProjectFromReader(reader);

                }
            }
            return proj;
            //return new Project(0, "Not Implemented Yet", DateTime.Now, DateTime.Now.AddDays(1));
        }

        public IList<Project> GetAllProjects()
        {
            IList<Project> projects = new List<Project>(); //not entirely sure why IList instead of List but the former works here due to the thing above it

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM project", conn);

                SqlDataReader reader = cmd.ExecuteReader(); //executes the select query

                //create park object(s) from the data we grabbed from the reader.
                while (reader.Read())
                {
                    Project project = CreateProjectFromReader(reader);
                    projects.Add(project);
                }

            }
            return projects;
            //return new List<Project>();
        }

        public Project CreateProject(Project newProject)
        {
            int project;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO project(name, from_date, to_date) " +
                    "OUTPUT INSERTED.project_id VALUES(@name, @from_date, @to_date);", conn);
                //cmd.Parameters.AddWithValue()
                cmd.Parameters.AddWithValue("@name", newProject.Name);
                cmd.Parameters.AddWithValue("@from_date", newProject.FromDate);
                cmd.Parameters.AddWithValue("@to_date", newProject.ToDate);

                project = Convert.ToInt32(cmd.ExecuteScalar());
                //Project anotherProjectTwo = GetProject(anotherProject);
                               

            }
            return GetProject(project);
        }

        public void DeleteProject(int projectId)
        {
            {
                //DeleteProjectFromOtherTable(projectId);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("DELETE FROM project_employee WHERE project_id = @project_id ", conn);
                    cmd.Parameters.AddWithValue("@project_id", projectId);

                    cmd.ExecuteNonQuery();

                    SqlCommand cmdtwo = new SqlCommand("DELETE FROM timesheet WHERE project_id = @project_id ", conn);
                    cmdtwo.Parameters.AddWithValue("@project_id", projectId);

                    cmdtwo.ExecuteNonQuery();

                    SqlCommand cmdthree = new SqlCommand("DELETE FROM project WHERE project_id = @project_id ", conn);
                    cmdthree.Parameters.AddWithValue("@project_id", projectId);

                    cmdthree.ExecuteNonQuery(); //no results needed.
                }
            }
        }
        /*public void DeleteProjectFromOtherTable (int project_id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("DELETE * FROM project_employee WHERE project_id = @project_id ", conn);
                cmd.Parameters.AddWithValue("@project_id", project_id);
                //cmd.Parameters.AddWithValue("state_abbreviation", state_abbreviation);

                cmd.ExecuteNonQuery();

            }
        }*/

        private Project CreateProjectFromReader(SqlDataReader reader)
        {
            Project project = new Project();
            project.ProjectId = Convert.ToInt32(reader["project_id"]);
            project.Name = Convert.ToString(reader["name"]);
            project.FromDate = Convert.ToDateTime(reader["from_date"]);
            project.ToDate = Convert.ToDateTime(reader["to_date"]);

            return project;

        }
    }
}
