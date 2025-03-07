using System.Collections.Generic;
using Xunit;
using API_Examen.Models;
using System.Text.Json;

public class FavoritesTests
{
    private List<Movie> favoriteMovies = new(); // On va simuler un LocalStorage

    [Fact]
    public void Test_Ajouter_Film_Favoris()
    {
        // Arrange
        var movie = new Movie {Title = "Film Test", Status = "Neutre", Overview = "Ceci est un bon film" };

        // Act
        favoriteMovies.Add(movie);
        var json = JsonSerializer.Serialize(favoriteMovies);

        // Assert
        Assert.Contains(favoriteMovies, m => m.Title == "Film Test");
        Assert.Equal(1, favoriteMovies.Count);
    }
}