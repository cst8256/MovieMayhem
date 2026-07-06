using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieMayhem.DataAccess;

namespace MovieMayhem.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly MovieMayhem.DataAccess.MovieMayhemContext _context;

        public CreateModel(MovieMayhem.DataAccess.MovieMayhemContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["Genres"] = new SelectList(_context.Genres, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["GenreId"] = new SelectList(_context.Genres, "Id", "Name", Movie.GenreId);
                return Page();
            }

            _context.Movies.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
