using System.Collections.Generic;

namespace PerformanceWeb.Models
{
    /// <summary>
    /// The group todo list model class.
    /// </summary>
    public class GroupTodoModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the todo list.
        /// </summary>
        /// <value>
        /// The todo list.
        /// </value>
        public List<TodoItemModel> TodoList { get; set; }
    }
}
