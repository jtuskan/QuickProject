// -----------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Tuskan & Doss Development LLC">
// Copyright 2014 Tuskan & Doss Development LLC. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace GitProject.Controllers
{
    using GitProject.Models;
    using GitProject.Services;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class HomeController : Controller
    {
        private readonly IProjectService projectService;

        /// <summary>
        /// IProjectService is injected through Ninject.
        /// </summary>
        /// <param name="projectService"></param>
        public HomeController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View(new IndexViewModel
                {
                    Projects = this.projectService.Projects,
                    Memebers = this.projectService.Members
                });
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Project(int id)
        {
            return View(this.projectService.Projects.First(x => x.ProjectId == id));
        }

        [HttpPost]
        public ActionResult Project(Project model)
        {
            this.projectService.UpdateProject(model);

            return RedirectToAction("Index");
        }
    }
}
