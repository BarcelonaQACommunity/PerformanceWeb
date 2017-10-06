using Microsoft.AspNetCore.Mvc;
using PerformanceWeb.Data;
using PerformanceWeb.Models;
using System.Collections.Generic;
using System.Linq;

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
            return View(StaticData.TodoData);
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
        /// <param name="groupName">Name of the group.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateNewGroup(GroupTodoListModel groupTodoListModel)
        {
            if (ModelState.IsValid)
            {
                StaticData.TodoData.Groups.Add(new GroupTodoModel
                {
                    Id = $"group-{StaticData.TodoData.Groups.Count + 1}",
                    Title = groupTodoListModel.NewGroup,
                    TodoList = new List<TodoItemModel>()
                });
            }

            return View("GroupTodoList", StaticData.TodoData);
        }

        /// <summary>
        /// Deletes the todo item.
        /// </summary>
        /// <param name="itemId">The item identifier.</param>
        /// <returns></returns>
        public ActionResult DeleteTodoItem(string itemId)
        {
            TodoItemModel itemToRemove = null;
            foreach (var item in StaticData.TodoData.Groups[StaticData.TodoData.GroupToShow].TodoList)
            {
                if (item.Id == itemId)
                {
                    itemToRemove = item;
                }
            }

            if (itemToRemove != null)
            {
                StaticData.TodoData.Groups[StaticData.TodoData.GroupToShow].TodoList.Remove(itemToRemove);
            }

            return View("GroupTodoList", StaticData.TodoData);
        }

        /// <summary>
        /// Shows the group.
        /// </summary>
        /// <param name="groupId">The group identifier.</param>
        /// <returns></returns>
        public ActionResult ShowGroup(string groupId)
        {
            var id = 0;
            for (int i = 0; i < StaticData.TodoData.Groups.Count; i++)
            {
                if (StaticData.TodoData.Groups[i].Id == groupId)
                {
                    id = i;
                }
            }

            StaticData.TodoData.GroupToShow = id;

            return View("GroupTodoList", StaticData.TodoData);
        }
    }
}