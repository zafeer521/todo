using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewApplication.Model;

namespace NewApplication.Pages.TodoList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Todo Todo { get; set; }
        public void OnGet()
        {
        }
        public async Task<IActionResult> Onpost()
        {
            if (ModelState.IsValid)
            {
                await _db.Todo.AddAsync(Todo);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
                return Page();
        }
    }
}
