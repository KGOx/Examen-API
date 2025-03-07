using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using API_Examen;

public class MovieServiceTests
{
    [Fact]
    public async Task Test_Liste_Film()
    {
        // Arrange
        var httpClient = new HttpClient();
        string bearerToken = "eyJhbGciOiJIUzI1NiJ9.eyJhdWQiOiJiOGUyMzcxMDBhOTQzMzBkZGQzNjY4OWM5YjNiYzY1YSIsIm5iZiI6MTczOTAxMTQ4My42NDQsInN1YiI6IjY3YTczNTliNWZhNDJkN2U3NmYxMGEwYiIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.b-bLezv2cqVD3H547FfR2nKhZVKsEwEr8yc1dJ3I26Y";

        var movieService = new MovieService(httpClient, bearerToken);
        int totalPages = 10;
        int expectedMaxMovies = totalPages * 20; // 10 pages * 20 films par page
        // Act
        var movies = await movieService.GetTrendingMoviesAsync(totalPages);

        // Assert
        Assert.NotNull(movies);
        Assert.NotEmpty(movies);
        Assert.True(movies.Count <= expectedMaxMovies); // Vérifie qu'on ne dépasse pas {nombre défini} de pages de films (20 film / page)
    }
}
