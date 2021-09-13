using NetChill.Backend.Domain;
using System;
using System.Collections.Generic;

namespace NetChill.Backend.DataAccess.Services
{
    public interface IMovieDataAccess
    {

        /// <summary>
        ///  Finds all movies in ascending order of their dates
        /// </summary>
        /// <returns>Returns an enumerable containing all the movies</returns>
        IEnumerable<Movie> GetAllMovies();

        /// <summary>
        /// Finds all the featured movies
        /// </summary>
        /// <returns>All Featured Movies</returns>
        IEnumerable<Movie> GetFeaturedMovies();

        /// <summary>
        /// Finds those movies whose dates are in the future
        /// </summary>
        /// <returns>All the upcoming movies</returns>
        IEnumerable<Movie> GetUpcomingMovies();

        /// <summary>
        /// Finds the latest released movies
        /// </summary>
        /// <returns>An enumerable having all the latest movies</returns>
        IEnumerable<Movie> GetNewReleases();

        /// <summary>
        /// Gets the movie corresponding to the movie id
        /// </summary>
        /// <param name="id">Movie id</param>
        /// <returns>Movie having the same id as in the parameter</returns>
        Movie GetMovie(Guid id);

        /// <summary>
        /// Adds Movies to the database
        /// </summary>
        /// <param name="movie">The movie to be added</param>
        /// <returns>true if the movie is saved successfully</returns>
        bool AddMovie(Movie movie);

        /// <summary>
        /// Updates a movie with the new given information
        /// </summary>
        /// <param name="movie">The movie with new information</param>
        /// <returns>true if movie is updated successfully else false</returns>
        bool UpdateMovie(Movie movie);
    }
}
