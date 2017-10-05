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
        /// Initializes the <see cref="StaticData"/> class.
        /// </summary>
        static StaticData()
        {
            if (TodoData == null)
            {
                TodoData = new GroupTodoListModel
                {
                    Id = "1",
                    TodoList = new List<TodoItemModel>
                    {
                        new TodoItemModel { Id = "1", Title = "Title 1", Description = "Description 1"},
                        new TodoItemModel { Id = "2", Title = "Title 2", Description = "Description 2"},
                        new TodoItemModel { Id= "3", Title = "Title 3", Description = "Description 3"}
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
