using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceWeb.Models
{
    /// <summary>
    /// The group todo list model class.
    /// </summary>
    public class GroupTodoListModel
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public string Id { get; set; }

        /// <summary>
        /// Gets or sets the todo list.
        /// </summary>
        /// <value>
        /// The todo list.
        /// </value>
        public List<TodoItemModel> TodoList { get; set; }
    }
}
