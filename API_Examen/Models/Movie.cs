namespace API_Examen.Models; 
using System.Text.Json.Serialization;

public class MovieResponse
{
    [JsonPropertyName("results")]
    public List<Movie> Results { get; set; }
}
public class Movie
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("overview")]
    public string Overview { get; set; }

    [JsonPropertyName("poster_path")]
    public string PosterPath { get; set; }

    public string FullPosterPath => $"{PosterPath}";
}
