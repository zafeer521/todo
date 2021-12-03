using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewApplication.Model;

namespace NewApplication.Pages.TodoList
{
    public class EditModel : PageModel
    {
        private ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Todo Todo { get; set; }
        public async Task OnGet(int id)
        {
           Todo = await _db.Todo.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var TodoFromDb = await _db.Todo.FindAsync(Todo.Id);
                TodoFromDb.Name = Todo.Name;
                TodoFromDb.Description = Todo.Description;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }

            return RedirectToPage();
        }
    }
}
