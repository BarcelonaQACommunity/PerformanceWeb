using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PerformanceWeb.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace PerformanceWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var value = HttpContext.Session.GetString("User");

            if (value == null)
            {
                var data = new GroupTodoListModel
                {
                    GroupToShow = 0,

                    Groups = new List<GroupTodoModel>
                    {
                        new GroupTodoModel
                        {
                            Id = "group-1",
                            Title = "Group 1",
                            TodoList = new List<TodoItemModel>()
                        }
                    }
                };

                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(data));
            }
            
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }        

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
