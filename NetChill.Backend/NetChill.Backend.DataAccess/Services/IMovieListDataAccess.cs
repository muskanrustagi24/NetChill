using NetChill.Backend.Domain;
using System;
using System.Collections.Generic;

namespace NetChill.Backend.DataAccess.Services
{
    public interface IMovieListDataAccess
    {
        /// <summary>
        /// Adds a movie to the list for the corresponding user
        /// </summary>
        /// <param name="movieId">Movie to be added</param>
        /// <param name="userId">User that adds the movie</param>
        /// <returns>true if sucessfully added else false</returns>
        bool AddMovieToMovieList(Guid movieId , Guid userId);

        /// <summary>
        /// Returns the collection of all the movies which have been added by the given user
        /// </summary>
        /// <param name="userId">The user id of the user</param>
        /// <returns>Collection of movies</returns>
        IEnumerable<MovieList> GetMyMovies(Guid userId);
    }
}
