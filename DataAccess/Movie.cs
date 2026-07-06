using System;
using System.Collections.Generic;

namespace MovieMayhem.DataAccess;

public partial class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Director { get; set; } = null!;

    public int Year { get; set; }

    public int GenreId { get; set; }

    public virtual Genre Genre { get; set; } = null!;
}
