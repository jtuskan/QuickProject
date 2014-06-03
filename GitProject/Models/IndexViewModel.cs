
namespace GitProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using GitProject.Models;

    public class IndexViewModel
    {
        public IEnumerable<Project> Projects { get; set; }

        public IEnumerable<Member> Memebers { get; set; }
    }
}