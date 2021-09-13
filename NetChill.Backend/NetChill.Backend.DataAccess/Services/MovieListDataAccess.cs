using NetChill.Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetChill.Backend.DataAccess.Services
{
    public class MovieListDataAccess : IMovieListDataAccess
    {
        private readonly NetChillDbContext _context;
        public MovieListDataAccess()
        {
            this._context = new NetChillDbContext();
        }
        
        /// <inheritdoc cref="IMovieListDataAccess.AddMovieToMovieList(Movie, User)"/>
        public bool AddMovieToMovieList(Guid movieId, Guid userId)
        {
            try
            {
                this._context.MovieLists.Add(new MovieList
                {
                    MovieId = movieId,
                    UserId = userId
                });
                this._context.SaveChanges();
                return true;
            }
            catch (Exception exception) 
            {
                Console.WriteLine(exception);
                return false;
            }
        }

        /// <inheritdoc cref="IMovieListDataAccess.GetMyMovies(Guid)"/>
        public IEnumerable<MovieList> GetMyMovies(Guid userId)
        {
            var moviesLists = from movieList in this._context.MovieLists
                              where movieList.UserId.Equals(userId)
                              select movieList;

            return moviesLists;

        }
    }
}