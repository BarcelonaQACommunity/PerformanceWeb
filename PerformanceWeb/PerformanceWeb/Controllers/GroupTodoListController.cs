using Microsoft.AspNetCore.Mvc;
using PerformanceWeb.Data;
using PerformanceWeb.Models;

namespace PerformanceWeb.Controllers
{
    /// <summary>
    /// The Group Todo list controller.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class GroupTodoListController : Controller
    {
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
                StaticData.TodoData.Groups.Add(new GroupTodoModel { Id = $"group-{StaticData.TodoData.Groups.Count + 1}", Title = groupTodoListModel.NewGroup });
            }

            //return RedirectToAction("GroupTodoList");
            return View("GroupTodoList", StaticData.TodoData);
        }

        public IActionResult GroupTodoList()
        {
            return View(StaticData.TodoData);
        }
    }
}