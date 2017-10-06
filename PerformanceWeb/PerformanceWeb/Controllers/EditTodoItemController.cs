using Microsoft.AspNetCore.Mvc;
using PerformanceWeb.Models;
using PerformanceWeb.Data;

namespace PerformanceWeb.Controllers
{
    /// <summary>
    /// The edit todo item controller class.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
    public class EditTodoItemController : Controller
    {
        /// <summary>
        /// Indexes this instance.
        /// </summary>
        /// <returns></returns>
        public IActionResult EditTodoItem(string todoItemModel)
        {
            if (!string.IsNullOrEmpty(todoItemModel))
            {
                StaticData.TodoData.ItemToShow = todoItemModel;
            }
            
            var model = StaticData.TodoData.Groups[StaticData.TodoData.GroupToShow].TodoList.Find(p => p.Id == StaticData.TodoData.ItemToShow);

            return View(model);
        }

        /// <summary>
        /// Edit an item.
        /// </summary>
        /// <param name="itemModel">The item model.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EditItem(TodoItemModel itemModel)
        {
            if (ModelState.IsValid)
            {
                var item = StaticData.TodoData.Groups[StaticData.TodoData.GroupToShow].TodoList.Find(p => p.Id == StaticData.TodoData.ItemToShow);

                if (string.IsNullOrEmpty(itemModel.Color))
                {
                    itemModel.Color = "white";
                }
                else
                {
                    item.Color = itemModel.Color;
                }

                item.Title = itemModel.Title;
                item.Description = itemModel.Description;

                return RedirectToAction("GroupTodoList", "GroupTodoList", StaticData.TodoData);
            }
            else
            {
                return View("EditTodoItem", itemModel);
            }
        }
    }
}