namespace API_Examen.Models; 
using System.Text.Json.Serialization;

public class MovieResponse
{
    [JsonPropertyName("results")]
    public List<Movie> Results { get; set; }
}
public class Movie
{
    [JsonPropertyName("title")] // Les JsonPropertyName est utilisé quand, le nom de la propriété n'est pas le même que celui utilisé en C#.
    public string Title { get; set; } // Car quand on fait appel a l'API, il nous fournit des données au format JSON. Et donc ça permet de bien cvonvertir grâce a System.text.json
    
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
            return Vote_Average.ToString("F1"); // Arrondir a 1 chiffre après la virgule 
        }
    }
    public string FullPosterPath => $"{PosterPath}";

    [JsonPropertyName("release_date")]
    public string Release_Date {get; set; }

    [JsonPropertyName("id")]
    public int ID {get; set; }
}
