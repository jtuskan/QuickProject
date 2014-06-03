// -----------------------------------------------------------------------
// <copyright file="ReportService.cs" company="Tuskan & Doss Development LLC">
// Copyright 2013 Tuskan & Doss Development LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace GitProject.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// This class represents a code project.
    /// </summary>
    public class Project
    {
        public int ProjectId { get; set; }

        public string Name { get; set; }

        public IEnumerable<int> MemberIds { get; set; }
    }
}