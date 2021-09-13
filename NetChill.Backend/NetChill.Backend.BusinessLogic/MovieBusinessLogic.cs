using NetChill.Backend.DataAccess.Services;
using NetChill.Backend.Domain;
using System;
using System.Collections.Generic;

namespace NetChill.Backend.BusinessLogic
{
   public class MovieBusinessLogic
    {
        private readonly MovieDataAccess _movieDataAccess;

        public MovieBusinessLogic()
        {
            _movieDataAccess = new MovieDataAccess();
        }

        /// <inheritdoc cref="IMovieDataAccess.GetAllMovies()"/>
        public IEnumerable<Movie> GetAllMovies()
        {
            return _movieDataAccess.GetAllMovies();
        }

        /// <inheritdoc cref="IMovieDataAccess.GetFeaturedMovies"/>
        public IEnumerable<Movie> GetFeaturedMovies()
        {
            return _movieDataAccess.GetFeaturedMovies();
        }

        /// <inheritdoc cref="IMovieDataAccess.GetUpcomingMovies()"/>
        public IEnumerable<Movie> GetUpcomingMovies()
        {
            return _movieDataAccess.GetUpcomingMovies();
        }

        /// <inheritdoc cref="IMovieDataAccess.GetNewReleases()"/>
        public IEnumerable<Movie> GetNewReleases()
        {
            return _movieDataAccess.GetNewReleases();
        }

        /// <inheritdoc cref="IMovieDataAccess.GetMovie(Guid)"/>
        public Movie GetMovie(Guid id)
        {
            return _movieDataAccess.GetMovie(id);
        }

        /// <inheritdoc cref="IMovieDataAccess.AddMovie(Movie)"/>
        public bool AddMovie(Movie movie) {
            return _movieDataAccess.AddMovie(movie);
        }

        /// <inheritdoc cref="IMovieDataAccess.UpdateMovie(Movie)"/>
        public bool UpdateMovie(Movie newMovie) {
            return _movieDataAccess.UpdateMovie(newMovie);
        }
    
    }
}
