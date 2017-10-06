using Microsoft.AspNetCore.Mvc;
using PerformanceWeb.Data;
using PerformanceWeb.Models;

namespace PerformanceWeb.Controllers
{
    /// <summary>
    /// The new todo item controller class.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class NewTodoItemController : Controller
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public IActionResult NewTodoItem()
        {
            return View(new TodoItemModel());
        }

        /// <summary>
        /// Creates the new item.
        /// </summary>
        /// <param name="itemModel">The item model.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CreateNewItem(TodoItemModel itemModel)
        {
            if (ModelState.IsValid)
            {
                int id = StaticData.TodoData.Groups[StaticData.TodoData.GroupToShow].TodoList.Count + 1;
                itemModel.Id = "item-" + id;

                if (string.IsNullOrEmpty(itemModel.Color))
                {
                    itemModel.Color = "white";
                }

                StaticData.TodoData.Groups[StaticData.TodoData.GroupToShow].TodoList.Add(itemModel);

                return RedirectToAction("GroupTodoList", "GroupTodoList", StaticData.TodoData);
            }
            else
            {
                return View("NewTodoItem");
            }
        }
    }
}