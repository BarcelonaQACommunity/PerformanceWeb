using Microsoft.AspNetCore.Mvc;
using PerformanceWeb.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

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
            var staticData = JsonConvert.DeserializeObject<GroupTodoListModel>(HttpContext.Session.GetString("User"));

            if (!string.IsNullOrEmpty(todoItemModel))
            {
                staticData.ItemToShow = todoItemModel;

                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(staticData));
            }
            
            var model = staticData.Groups[staticData.GroupToShow].TodoList.Find(p => p.Id == staticData.ItemToShow);

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
                var staticData = JsonConvert.DeserializeObject<GroupTodoListModel>(HttpContext.Session.GetString("User"));

                var item = staticData.Groups[staticData.GroupToShow].TodoList.Find(p => p.Id == staticData.ItemToShow);

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

                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(staticData));

                return RedirectToAction("GroupTodoList", "GroupTodoList", staticData);
            }
            else
            {
                return View("EditTodoItem", itemModel);
            }
        }
    }
}