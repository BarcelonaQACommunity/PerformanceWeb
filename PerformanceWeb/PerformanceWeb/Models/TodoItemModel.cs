﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PerformanceWeb.Models
{
    /// <summary>
    /// THe todo item model class.
    /// </summary>
    public class TodoItemModel
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
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the colors.
        /// </summary>
        /// <value>
        /// The colors.
        /// </value>
        public IEnumerable<SelectListItem> Colors = new List<SelectListItem>
            {
                new SelectListItem { Text = "White", Value = "white" },
                new SelectListItem { Text = "Red", Value = "red" },
                new SelectListItem { Text = "Aquamarine", Value = "aquamarine" },
                new SelectListItem { Text = "Burlywood", Value = "burlywood" },
                new SelectListItem { Text = "Yellow", Value = "yellow" },
                new SelectListItem { Text = "Blue", Value = "blue" }
            };
    }
}
