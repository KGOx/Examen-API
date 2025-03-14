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
        // Arrange = C'est ici qu'on prépare ce qu'on a besoin pour le test, ici un film test pour exemple (objet, initialisation des valeurs, config de l'environnement)
        var movie = new Movie {Title = "Film Test", Status = "Neutre", Overview = "Ceci est un bon film" };

        // Act = Ici qu'on exécute l'action, donc on fait appel a une méthode, modification de donnée, simuler une interaction (Ici on ajoute au favoris et on convertit en JSON)
        favoriteMovies.Add(movie);
        var json = JsonSerializer.Serialize(favoriteMovies);

        // Assert = Et c'est ici qu'on vérifie si le test passe ou échoue, ici par exemple contain = la liste contient bien le film ajouter, equal = la liste contient bien 1 film (un seul ajouter)
        Assert.Contains(favoriteMovies, m => m.Title == "Film Test");
        Assert.Equal(1, favoriteMovies.Count);
    }
}