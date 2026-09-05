using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyStore.Data;
using MyStore.Extensions;
using MyStore.Models;

namespace MyStore.Pages
{
    [Authorize]
    public class UsersModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IEmailSender _emailSender;

        public UsersModel(ApplicationDbContext dbContext, IEmailSender emailSender)
        {
            _dbContext = dbContext;
            _emailSender = emailSender;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchEmail { get; set; } = string.Empty;

        [BindProperty(SupportsGet = true)]
        public int PageIndex { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 10;

        [BindProperty]
        public List<string> SelectedUserIds { get; set; } = new();

        [BindProperty]
        public string EmailSubject { get; set; } = string.Empty;

        [BindProperty]
        public string EmailBody { get; set; } = string.Empty;

        [TempData]
        public string StatusMessage { get; set; } = string.Empty;

        public PaginatedList<AppUser> Users { get; set; } = new(new List<AppUser>(), 0, 1, 10);

        public async Task<IActionResult> OnGetAsync()
        {
            await LoadUsersAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostSendSelectedEmailsAsync()
        {
            await LoadUsersAsync();

            if (SelectedUserIds.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "Please select at least one user.");
                return Page();
            }

            if (string.IsNullOrWhiteSpace(EmailSubject))
            {
                ModelState.AddModelError(string.Empty, "Email subject is required.");
                return Page();
            }

            if (string.IsNullOrWhiteSpace(EmailBody))
            {
                ModelState.AddModelError(string.Empty, "Email body is required.");
                return Page();
            }

            var recipients = await _dbContext.AppUsers
                .AsNoTracking()
                .Where(u => SelectedUserIds.Contains(u.Id) && u.Email != null)
                .ToListAsync();

            if (recipients.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "No valid recipient emails found.");
                return Page();
            }

            foreach (var user in recipients)
            {
                await _emailSender.SendEmailAsync(user.Email!, EmailSubject, EmailBody);
            }

            StatusMessage = $"Email sent to {recipients.Count} selected users.";
            return RedirectToPage(new { SearchEmail, PageIndex, PageSize });
        }

        private async Task LoadUsersAsync()
        {
            var query = _dbContext.AppUsers.AsNoTracking().OrderBy(u => u.Email).AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchEmail))
            {
                query = query.Where(u => u.Email != null && u.Email.Contains(SearchEmail));
            }

            if (PageSize <= 0)
            {
                PageSize = 10;
            }

            if (PageIndex <= 0)
            {
                PageIndex = 1;
            }

            Users = await PaginatedList<AppUser>.CreateAsync(query, PageIndex, PageSize);
        }
    }
}
