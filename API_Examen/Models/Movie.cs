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
    
    public string Status {get; set; } = "Neutre";

    [JsonPropertyName("overview")]
    public string Overview { get; set; }

    [JsonPropertyName("poster_path")]
    public string PosterPath { get; set; }

    [JsonPropertyName("vote_average")]
    public float Vote_Average {get; set; }
    public string GetFormattedVoteAverage()
    {
        if (Vote_Average % 1 == 0)
        {
            return ((int)Vote_Average).ToString();
        }
        else
        {
            return Vote_Average.ToString("F1");
        }
    }
    public string FullPosterPath => $"{PosterPath}";

    [JsonPropertyName("release_date")]
    public string Release_Date {get; set; }

    [JsonPropertyName("id")]
    public int ID {get; set; }
}
