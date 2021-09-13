using NetChill.Backend.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetChill.Backend.DataAccess.Services
{
    public class MovieDataAccess : IMovieDataAccess
    {

        private readonly NetChillDbContext _context;

        public MovieDataAccess()
        {
            this._context = new NetChillDbContext();
        }

        /// <inheritdoc cref="IMovieDataAccess.AddMovie(Movie)"/>
        public bool AddMovie(Movie movie)
        {
            try
            {
                this._context.Movies.Add(movie);
                this._context.SaveChanges();
                return true;
            }
            catch (Exception exception) {
                Console.WriteLine(exception);
                return false;
            }
        }

        /// <inheritdoc cref="IMovieDataAccess.GetAllMovies"/>
        public IEnumerable<Movie> GetAllMovies()
        {
            try {
                return this._context.Movies.OrderBy(movie => movie.AvailabilityStarts);
            }
            catch (Exception exception) 
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }


        /// <inheritdoc cref="IMovieDataAccess.GetFeaturedMovies"/>
        public IEnumerable<Movie> GetFeaturedMovies()
        {
            try
            {
                return this._context.Movies.Where(movie => movie.IsFeatured == true);
            }
            catch (Exception exception) 
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }


        /// <inheritdoc cref="IMovieDataAccess.GetMovie(Guid id)"/>
        public Movie GetMovie(Guid id)
        {
            try
            {
                Movie movie = (Movie)_context.Movies.FirstOrDefault(m => m.Id.Equals(id));
                return movie;
            }
            catch (Exception exception) {
                Console.WriteLine(exception.Message);
                return null;
            }
        }


        /// <inheritdoc cref="IMovieDataAccess.GetNewReleases"/>
        public IEnumerable<Movie> GetNewReleases()
        {
            try
            {
                 var query = from movie in this._context.Movies
                            where movie.AvailabilityStarts <= DateTime.Now
                            orderby movie.AvailabilityStarts descending
                            select movie;
                 return query;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }


        /// <inheritdoc cref="IMovieDataAccess.GetUpcomingMovies"/>
        public IEnumerable<Movie> GetUpcomingMovies()
        {
            try
            {
                var query = from movie in this._context.Movies
                           where movie.AvailabilityStarts > DateTime.Now
                           select movie;
                return query;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        /// <inheritdoc cref="IMovieDataAccess.UpdateMovie(Movie)"/>
        public bool UpdateMovie(Movie movie)
        {
            try
            {
                var entry = _context.Entry(movie);
                entry.State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception exception) {
                Console.WriteLine(exception);
                return false;
            }
        }
    }
}
