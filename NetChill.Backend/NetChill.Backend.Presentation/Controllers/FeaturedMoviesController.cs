using NetChill.Backend.BusinessLogic;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace NetChill.Backend.Presentation.Controllers
{
    [RoutePrefix("api/featured")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FeaturedMoviesController : ApiController
    {
        private readonly MovieBusinessLogic _movieBusinessLogic;
        public FeaturedMoviesController()
        {
            this._movieBusinessLogic = new MovieBusinessLogic();
        }

        /// <summary>
        /// Handles the get request to fetch featured movies
        /// </summary>
        /// <returns>All featured movies</returns>
        [HttpGet]
        [Route()]
        public IHttpActionResult GetFeaturedMovies()
        {
            try
            {
                var featuredMovies = this._movieBusinessLogic.GetFeaturedMovies();
                if (featuredMovies != null)
                {
                    return Ok(featuredMovies);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return InternalServerError();
            }

        }
    }
}
