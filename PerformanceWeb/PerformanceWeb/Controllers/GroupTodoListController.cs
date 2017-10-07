using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PerformanceWeb.Models;
using System.Collections.Generic;

namespace PerformanceWeb.Controllers
{
    /// <summary>
    /// The Group Todo list controller.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class GroupTodoListController : Controller
    {
        /// <summary>
        /// Groups the todo list.
        /// </summary>
        /// <returns></returns>
        public IActionResult GroupTodoList()
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

            var staticData = JsonConvert.DeserializeObject<GroupTodoListModel>(HttpContext.Session.GetString("User"));
            return View(staticData);
        }

        // GET: GroupTodoList
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Creates the new group.
        /// </summary>
        /// <param name="groupTodoListModel">The group todo list model.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateNewGroup(GroupTodoListModel groupTodoListModel)
        {
            var staticData = JsonConvert.DeserializeObject<GroupTodoListModel>(HttpContext.Session.GetString("User"));

            if (ModelState.IsValid)
            {
                staticData.Groups.Add(new GroupTodoModel
                {
                    Id = $"group-{staticData.Groups.Count + 1}",
                    Title = groupTodoListModel.NewGroup,
                    TodoList = new List<TodoItemModel>()
                });

                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(staticData));
            }

            return View("GroupTodoList", staticData);
        }

        /// <summary>
        /// Deletes the todo item.
        /// </summary>
        /// <param name="itemId">The item identifier.</param>
        /// <returns></returns>
        public ActionResult DeleteTodoItem(string itemId)
        {
            var staticData = JsonConvert.DeserializeObject<GroupTodoListModel>(HttpContext.Session.GetString("User"));

            TodoItemModel itemToRemove = null;
            foreach (var item in staticData.Groups[staticData.GroupToShow].TodoList)
            {
                if (item.Id == itemId)
                {
                    itemToRemove = item;
                }
            }

            if (itemToRemove != null)
            {
                staticData.Groups[staticData.GroupToShow].TodoList.Remove(itemToRemove);
            }

            HttpContext.Session.SetString("User", JsonConvert.SerializeObject(staticData));

            return View("GroupTodoList", staticData);
        }

        /// <summary>
        /// Shows the group.
        /// </summary>
        /// <param name="groupId">The group identifier.</param>
        /// <returns></returns>
        public ActionResult ShowGroup(string groupId)
        {
            var staticData = JsonConvert.DeserializeObject<GroupTodoListModel>(HttpContext.Session.GetString("User"));

            var id = 0;
            for (int i = 0; i < staticData.Groups.Count; i++)
            {
                if (staticData.Groups[i].Id == groupId)
                {
                    id = i;
                }
            }

            staticData.GroupToShow = id;

            HttpContext.Session.SetString("User", JsonConvert.SerializeObject(staticData));

            return View("GroupTodoList", staticData);
        }
    }
}