using NetChill.Backend.BusinessLogic;
using NetChill.Backend.Domain;
using System;
using System.Web.Http;
using System.Web.Http.Cors;
namespace NetChill.Backend.Presentation.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/movies")]
    public class MoviesController : ApiController
    {
        private readonly MovieBusinessLogic _movieBusinessLogic;

        public MoviesController()
        {
            this._movieBusinessLogic = new MovieBusinessLogic();
        }

        /// <summary>
        /// Handles the request to fetch all movies
        /// </summary>
        /// <returns>All movies</returns>
        [HttpGet]
        [Route()]
        public IHttpActionResult GetAllMovies() {
            var movies = _movieBusinessLogic.GetAllMovies();
            return Ok(movies);

        }

        /// <summary>
        /// Handles the request to get movie by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Movie with given id</returns>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetMovie(Guid id) {
            Movie movie = (Movie)_movieBusinessLogic.GetMovie(id);
            return Ok(movie);
        }

        /// <summary>
        /// Handles the request to add movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>Movie added</returns>
        [HttpPost]
        [Route()]
        public IHttpActionResult AddMovie(Movie movie) {
            try
            {
                var res = _movieBusinessLogic.AddMovie(movie);
                if (res)
                {
                    return Ok(movie.Name);
                }
                else {
                    return InternalServerError();
                }
            }
            catch (Exception exception) {
                Console.WriteLine(exception);
                return InternalServerError(exception);
            }
        }

        /// <summary>
        /// Handles the request to update movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Updated movie</returns>
        [HttpPut]
        [Route("{id}")]
        public IHttpActionResult UpdateMovie(Guid id) {
            return Ok(new { Movie = "Updated" });
        }
    
    }

}