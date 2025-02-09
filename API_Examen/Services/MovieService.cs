using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using API_Examen.Models;

public class MovieService
{
    private readonly HttpClient _httpClient;
    private const string ApiKey = "b8e237100a94330ddd36689c9b3bc65a"; 

    public MovieService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Movie>> GetPopularMoviesAsync()
    {
        var result = await _httpClient.GetFromJsonAsync<MovieResponse>($"https://api.themoviedb.org/3/movie/popular?api_key=b8e237100a94330ddd36689c9b3bc65a");
        return result?.Results ?? new List<Movie>();
    }
}

public class MovieResponse
{
    public List<Movie> Results { get; set; }
}
