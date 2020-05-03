using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using common.Interfaces;
using common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace client {
    public class ListModel : PageModel {
        private readonly ITaskService _taskService;
        private readonly ILogger<ListModel> _logger;

        public List<TaskModel> tasks { get; set; }

        public ListModel(ITaskService taskService, ILogger<ListModel> logger) {
            this._taskService = taskService;
            this._logger = logger;
        }
        public async Task<IActionResult> OnGet() {
            this.tasks = await _taskService.Find(x => true);
            return Page();
        }
    }
}