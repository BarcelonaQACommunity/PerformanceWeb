using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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
            var staticData = JsonConvert.DeserializeObject<GroupTodoListModel>(HttpContext.Session.GetString("User"));

            if (ModelState.IsValid)
            {
                int id = staticData.Groups[staticData.GroupToShow].TodoList.Count + 1;
                itemModel.Id = "item-" + id;

                if (string.IsNullOrEmpty(itemModel.Color))
                {
                    itemModel.Color = "white";
                }

                staticData.Groups[staticData.GroupToShow].TodoList.Add(itemModel);

                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(staticData));

                return RedirectToAction("GroupTodoList", "GroupTodoList", staticData);
            }
            else
            {
                return View("NewTodoItem");
            }
        }
    }
}