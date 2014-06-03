

namespace GitProject.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using GitProject.Models;

    public interface IProjectService
    {
        IEnumerable<Project> Projects { get; }

        IEnumerable<ProjectMember> ProjectMembers { get; }

        IEnumerable<Member> Members { get; }

        void AddMemberToProject(ProjectMember member, int projectId);

        void RemoveMemberFromProject(ProjectMember member, int projectId);

        void UpdateProject(Project project);
    }
}