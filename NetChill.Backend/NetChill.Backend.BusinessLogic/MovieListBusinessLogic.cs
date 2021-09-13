using NetChill.Backend.DataAccess.Services;
using NetChill.Backend.Domain;
using System;
using System.Collections.Generic;

namespace NetChill.Backend.BusinessLogic
{
    public class MovieListBusinessLogic
    {
        private readonly MovieListDataAccess _movieListDataAcces;
        private readonly MovieDataAccess _movieDataAccess;

        public MovieListBusinessLogic()
        {
            _movieListDataAcces = new MovieListDataAccess();
            _movieDataAccess = new MovieDataAccess();
        }

        /// <inheritdoc cref="IMovieListDataAccess.AddMovieToMovieList(Guid, Guid)"/>
        public bool AddMovieToMovieList(Guid movieId, Guid userId)
        {
            return _movieListDataAcces.AddMovieToMovieList(movieId, userId);
        }

        /// <inheritdoc cref="IMovieListDataAccess.GetMyMovies(Guid)"/>
        public List<Movie> GetMyMovies(Guid userId) {
           var movieLists = _movieListDataAcces.GetMyMovies(userId);

           List<Movie> myMovies = new List<Movie>();

            foreach (MovieList movieList in movieLists) {
                myMovies.Add(_movieDataAccess.GetMovie(movieList.MovieId));        
            }
            return myMovies;
        }
    }
}
