using Microsoft.AspNetCore.Mvc.Rendering;
using PerformanceWeb.Models;
using System.Collections.Generic;

namespace PerformanceWeb.Data
{
    /// <summary>
    /// Static data class.
    /// </summary>
    public class StaticData
    {
        /// <summary>
        /// Initializes the <see cref="StaticData" /> class.
        /// </summary>
        static StaticData()
        {
            if (TodoData == null)
            {
                TodoData = new GroupTodoListModel
                {
                    GroupToShow = 0,

                    Groups = new List<GroupTodoModel>
                    {
                        new GroupTodoModel
                        {
                            Id = "group-1",
                            Title = "Group 1",
                            TodoList = new List<TodoItemModel>
                            {
                                //new TodoItemModel { Id = "item-1", Title = "Title 1", Description = "Description 1", Color = "white" },
                                //new TodoItemModel { Id = "item-2", Title = "Title 2", Description = "Description 2", Color = "red" },
                                //new TodoItemModel { Id= "item-3", Title = "Title 3", Description = "Description 3", Color = "white" }
                            }
                        }
                    }
                };
            }
        }

        /// <summary>
        /// Gets or sets the todo data.
        /// </summary>
        /// <value>
        /// The todo data.
        /// </value>
        public static GroupTodoListModel TodoData { get; set; }
    }
}
