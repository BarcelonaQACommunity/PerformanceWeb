using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PerformanceWeb.Models
{
    /// <summary>
    /// Group todo list model class.
    /// </summary>
    public class GroupTodoListModel
    {
        /// <summary>
        /// Gets or sets the groups.
        /// </summary>
        /// <value>
        /// The groups.
        /// </value>
        public List<GroupTodoModel> Groups { get; set; }

        /// <summary>
        /// Gets or sets the new group.
        /// </summary>
        /// <value>
        /// The new group.
        /// </value>
        [Required]
        public string NewGroup { get; set; }

        /// <summary>
        /// Gets or sets the group to show.
        /// </summary>
        /// <value>
        /// The group to show.
        /// </value>
        public int GroupToShow { get; set; }

        /// <summary>
        /// Gets or sets the item to show.
        /// </summary>
        /// <value>
        /// The item to show.
        /// </value>
        public string ItemToShow { get; set; }
    }
}
