

namespace GitProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// This class represents a member or contributor to a project.
    /// </summary>
    public class ProjectMember
    {
        public int ProjectMemberId { get; set; }

        public int MemberId { get; set; }

        public int ProjectId { get; set; }
    }
}