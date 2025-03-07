using System.Net.Http.Headers; // Gère les en-têtes des requêtes HTTP.
using System.Text.Json; // Fournit des outils pour la sérialisation/désérialisation JSON.
using API_Examen.Models;

public class MovieService
{
    private readonly HttpClient _httpClient; // Client HTTP utilisé pour envoyer des requêtes à l'API.
    private readonly string _bearerToken; // Token d'authentification pour accéder à l'API.

    public MovieService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient; 
        _bearerToken = configuration["TMDB:BearerToken"]; 
    }

    // Nouveau constructeur pour les tests unitaires
    public MovieService(HttpClient httpClient, string bearerToken) // Permet l'acceptation du token directement en paramètre pour les tests
    {
        _httpClient = httpClient;
        _bearerToken = bearerToken;
    }

    public async Task<List<Movie>> GetTrendingMoviesAsync(int totalPages = 10)
    {
        List<Movie> allMovies = new List<Movie>(); // Liste pour stocker tous les films récupérés.

        for (int i = 1; i <= totalPages; i++) // Boucle sur plusieurs pages de résultats (par défaut, 10 pages).
        {
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get, // Définit la méthode HTTP comme GET.
                RequestUri = new Uri($"https://api.themoviedb.org/3/trending/movie/week?language=fr-FR&page={i}") // URL pour récupérer les films tendances de la semaine, en français, avec pagination.
            };

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // Indique que la réponse attendue est au format JSON.
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _bearerToken); // Ajoute le token d'authentification dans l'en-tête.

            var response = await _httpClient.SendAsync(request); // Envoie la requête HTTP et attend la réponse.

            if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new Exception("Erreur 401 : Vérifie ton Bearer Token dans appsettings.json."); // Gère le cas où le token est invalide ou expiré.
            }

            response.EnsureSuccessStatusCode();  // Vérifie que la réponse est un succès (code 2xx), sinon lève une exception.
            var json = await response.Content.ReadAsStringAsync(); // Lit le contenu de la réponse sous forme de chaîne JSON.

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true }; // Options pour ignorer la casse des noms de propriétés lors de la désérialisation.
            var movieResponse = JsonSerializer.Deserialize<MovieResponse>(json, options);  // Désérialise la réponse JSON en un objet `MovieResponse`.

            if (movieResponse?.Results != null)
            {
                allMovies.AddRange(movieResponse.Results); // Ajoute les films récupérés à la liste globale.
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
