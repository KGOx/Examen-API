namespace API_Examen.Models; 

public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Overview { get; set; }
    public string PosterPath { get; set; }

    public string FullPosterPath => $"https://image.tmdb.org/t/p/w500{PosterPath}";
}
