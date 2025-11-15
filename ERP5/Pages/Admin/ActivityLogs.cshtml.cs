using ERP5.Models; // chứa class ActivityLog
using ERP5.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP5.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class ActivityLogsModel : PageModel
    {
        private readonly IUserService _userService;

        public ActivityLogsModel(IUserService userService)
        {
            _userService = userService;
        }

        public List<ActivityLogViewModel> Logs { get; set; } = new();

        public async Task OnGetAsync()
        {
            // Ép kiểu về ActivityLog
            var logs = await _userService.GetActivityLogsAsync();
            Logs = logs.Cast<ActivityLog>() // hoặc logs.OfType<ActivityLog>()
                       .Select(l => new ActivityLogViewModel
                       {
                           UserName = l.UserName,
                           Action = l.Action,
                           Page = l.Page,
                           Date = l.Date
                       }).ToList();
        }

        public class ActivityLogViewModel
        {
            public string UserName { get; set; } = string.Empty;
            public string Action { get; set; } = string.Empty;
            public string Page { get; set; } = string.Empty;
            public DateTime Date { get; set; }
        }
    }
}
