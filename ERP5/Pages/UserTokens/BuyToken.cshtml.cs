using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ERP5.Data;
using ERP5.Models;

namespace ERP5.Pages.UserTokens
{
    public class BuyTokenModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly Dbcontext _context;

        public BuyTokenModel(UserManager<ApplicationUser> userManager, Dbcontext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [BindProperty]
        public int Amount { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; private set; }

        public void OnGet() { }

        public DateTime GetCreatedAt()
        {
            return CreatedAt;
        }

        public async Task<IActionResult> OnPostAsync(DateTime createdAt)
        {
            if (Amount <= 0)
            {
                Message = "Invalid amount!";
                return Page();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return RedirectToPage("/Account/Login");

            var token = new UserToken
            {
                UserId = user.Id,
                Amount = Amount,
                createdAt = DateTime.Now
            };

            _context.UserTokens.Add(token);
            await _context.SaveChangesAsync();

            Message = $"You have successfully bought {Amount} tokens!";
            return Page();
        }
    }
}
