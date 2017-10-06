using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PerformanceWeb.Models
{
    public class GroupTodoListModel
    {
        public List<GroupTodoModel> Groups { get; set; }

        [Required]
        public string NewGroup { get; set; }
    }
}
