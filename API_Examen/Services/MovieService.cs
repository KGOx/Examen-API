using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using API_Examen.Models;

public class MovieService
{
    private readonly HttpClient _httpClient;
    private readonly string _bearerToken;

    public MovieService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _bearerToken = configuration["TMDB:BearerToken"];
    }

    public async Task<List<Movie>> GetTrendingMoviesAsync(int totalPages = 10)
    {
        List<Movie> allMovies = new List<Movie>();

        for (int i = 1; i <= totalPages; i++) // Boucle sur plusieurs pages
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.themoviedb.org/3/trending/movie/week?language=fr-FR&page={i}")
            };

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _bearerToken);

            var response = await _httpClient.SendAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new Exception("Erreur 401 : Vérifie ton Bearer Token dans appsettings.json.");
            }

            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var movieResponse = JsonSerializer.Deserialize<MovieResponse>(json, options);

            if (movieResponse?.Results != null)
            {
                allMovies.AddRange(movieResponse.Results);
            }
        }

        return allMovies;
    }
    //     var request = new HttpRequestMessage
    //     {
    //         Method = HttpMethod.Get,
    //         RequestUri = new Uri("https://api.themoviedb.org/3/trending/movie/day?language=fr-FR")
    //     };

    //     request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    //     request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _bearerToken);

    //     var response = await _httpClient.SendAsync(request);

    //     if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
    //     {
    //         throw new Exception("Erreur 401 : Vérifie ton Bearer Token dans appsettings.json.");
    //     }

    //     response.EnsureSuccessStatusCode();
    //     var json = await response.Content.ReadAsStringAsync();

    //     var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    //     var movieResponse = JsonSerializer.Deserialize<MovieResponse>(json, options);

    //     return movieResponse?.Results ?? new List<Movie>();
    // }
}
