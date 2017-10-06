using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PerformanceWeb.Data;
using PerformanceWeb.Models;

namespace PerformanceWeb.Controllers
{
    public class GroupTodoListController : Controller
    {
        // GET: GroupTodoList
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateNewGroup()
        {
            StaticData.TodoData.Groups.Add(new GroupTodoModel { Id = $"group-{StaticData.TodoData.Groups.Count}"});

            return View();
        }
    }
}