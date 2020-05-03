using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using common.Interfaces;
using common.Tasks;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace client {
    public class CreateModel : PageModel {
        private readonly ITaskService _taskService;
        private readonly ILogger<CreateModel> _logger;

        public CreateModel(ITaskService taskService, ILogger<CreateModel> logger) {
            this._taskService = taskService;
            this._logger = logger;
        }
        public IActionResult OnGet() {
            return Page();
        }

        [BindProperty]
        public string taskName { get; set; }

        public async Task<IActionResult> OnPostAsync() {
            if (!ModelState.IsValid) {
                return Page();
            }

            var result = await _taskService.RegisterTask(this.taskName);
            var jobId = BackgroundJob.Enqueue<ReverseStringTask>(x => x.Execute(result.Id.ToString(), null));

            // for debugging
            this._logger.LogDebug(System.Text.Json.JsonSerializer.Serialize(result));
            this._logger.LogDebug(System.Text.Json.JsonSerializer.Serialize(new { jobId = jobId }));
            return RedirectToPage("List");
        }
    }
}