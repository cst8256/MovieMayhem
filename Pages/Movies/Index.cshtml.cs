using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MovieMayhem.DataAccess;

namespace MovieMayhem.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MovieMayhem.DataAccess.MovieMayhemContext _context;

        public IndexModel(MovieMayhem.DataAccess.MovieMayhemContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Movie = await _context.Movies.ToListAsync();
        }
    }
}
