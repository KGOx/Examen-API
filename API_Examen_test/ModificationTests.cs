using System.Collections.Generic;
using Xunit;
using API_Examen.Models;

public class ModificationTests
{
    private List<Movie> favoriteMovies = new(); // Ici aussi on simule le localstorage
    [Fact]
    public void Test_Modification_du_Status()
    {
        // Arrange
        var movie = new Movie { Title = "Film Test", Status = "Neutre" };
        favoriteMovies.Add(movie);

        // Act
        movie.Status = "J'aime";
        var updatedMovie = favoriteMovies.Find(m => m.Title == "Film Test");

        // Assert
        Assert.NotNull(updatedMovie);
        Assert.Equal("J'aime", updatedMovie.Status);
    }

    [Fact]
    public void Test_Suppression_Film()
    {
        // Arrange
        var movie = new Movie { Title = "Film Test" };
        favoriteMovies.Add(movie);

        // Act
        favoriteMovies.RemoveAll(m => m.Title == "Film Test");

        // Assert
        Assert.DoesNotContain(favoriteMovies, m => m.Title == "Film Test");
        Assert.Empty(favoriteMovies);
    }
}
