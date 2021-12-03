using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewApplication.Model;

namespace NewApplication.Pages.TodoList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Todo> Todos  { get; set; }
        public async Task OnGet()
        {
            Todos = await _db.Todo.ToListAsync(); 
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Todo.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            _db.Todo.Remove(book);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
