

namespace GitProject.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using GitProject.Models;
    using System.Data.Entity.Infrastructure;
    using System.Data.Common;
    using System.Data.SqlServerCe;

    public class ProjectService : IProjectService
    {
        private readonly IDbConnectionFactory connectionFactory;

        public ProjectService(IDbConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }

        public IEnumerable<Models.Project> Projects
        {
            get 
            {
                DbConnection connection = this.connectionFactory.CreateConnection(@"Data Source=|DataDirectory|\Database1.sdf; Persist Security Info=False");
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT ProjectId, Name FROM Project";
                connection.Open();
                DbDataReader reader = command.ExecuteReader();

                List<Project> models = new List<Project>();
                while (reader.Read())
                {
                    models.Add(new Project
                    {
                        ProjectId = (int)reader[0],
                        Name = (string)reader[1]
                    });
                }

                connection.Close();

                return models;
            }
        }

        public IEnumerable<ProjectMember> ProjectMembers
        {
            get
            {
                DbConnection connection = this.connectionFactory.CreateConnection(@"Data Source=|DataDirectory|\Database1.sdf; Persist Security Info=False");
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT ProjectMemberId, MemberId, ProjectId FROM ProjectMembers";
                connection.Open();
                DbDataReader reader = command.ExecuteReader();

                List<ProjectMember> models = new List<ProjectMember>();
                while (reader.Read())
                {
                    models.Add(new ProjectMember
                    {
                        ProjectMemberId = (int)reader[0],
                        MemberId = (int)reader[1],
                        ProjectId = (int)reader[2]
                    });
                }

                connection.Close();

                return models;
            }
        }

        public IEnumerable<Member> Members
        {
            get
            {
                DbConnection connection = this.connectionFactory.CreateConnection(@"Data Source=|DataDirectory|\Database1.sdf; Persist Security Info=False");
                DbCommand command = connection.CreateCommand();
                command.CommandText = "SELECT MemberId, Name FROM Members";
                connection.Open();
                DbDataReader reader = command.ExecuteReader();

                List<Member> models = new List<Member>();
                while (reader.Read())
                {
                    models.Add(new Member
                    {
                        MemberId = (int)reader[0],
                        Name = (string)reader[1]
                    });
                }

                connection.Close();

                return models;
            }
        }

        public void AddMemberToProject(ProjectMember member, int projectId)
        {
            DbConnection connection = this.connectionFactory.CreateConnection(@"Data Source=|DataDirectory|\Database1.sdf; Persist Security Info=False");
            DbCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO ProjectMembers (ProjectId, MemberId) VALUES (@projectId, @memberId)";
            command.Parameters.Add(new SqlCeParameter("@projectId", projectId));
            command.Parameters.Add(new SqlCeParameter("@memberId", member.MemberId));
            connection.Open();

            command.ExecuteNonQuery();
        }

        public void RemoveMemberFromProject(ProjectMember member, int projectId)
        {
            DbConnection connection = this.connectionFactory.CreateConnection(@"Data Source=|DataDirectory|\Database1.sdf; Persist Security Info=False");
            DbCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM ProjectMembers WHERE (@projectId = ProjectId) AND (@memberId = MemberId)";
            command.Parameters.Add(new SqlCeParameter("@projectId", projectId));
            command.Parameters.Add(new SqlCeParameter("@memberId", member.MemberId));
            connection.Open();

            command.ExecuteNonQuery();
        }

        public void UpdateProject(Project project)
        {
            DbConnection connection = this.connectionFactory.CreateConnection(@"Data Source=|DataDirectory|\Database1.sdf; Persist Security Info=False");
            DbCommand command = connection.CreateCommand();
            command.CommandText = "UPDATE Project SET Name = @projectName WHERE ProjectId = @projectId";
            command.Parameters.Add(new SqlCeParameter("@projectName", project.Name));
            command.Parameters.Add(new SqlCeParameter("@projectId", project.ProjectId));
            connection.Open();

            command.ExecuteNonQuery();
        }
    }
}