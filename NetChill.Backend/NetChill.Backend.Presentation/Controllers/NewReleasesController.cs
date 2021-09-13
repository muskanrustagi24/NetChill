using NetChill.Backend.BusinessLogic;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace NetChill.Backend.Presentation.Controllers
{
    [RoutePrefix("api/new")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class NewReleasesController : ApiController
    {
        private readonly MovieBusinessLogic _movieBusinessLogic;

        public NewReleasesController()
        {
            this._movieBusinessLogic = new MovieBusinessLogic();
        }

        /// <summary>
        /// Handles the get request to fetch newly released movies
        /// </summary>
        /// <returns>All new releases</returns>
        [HttpGet]
        [Route()]
        public IHttpActionResult GetNewReleases()
        {
            try
            {
                var newReleases = this._movieBusinessLogic.GetNewReleases();
                if (newReleases != null)
                {
                    return Ok(newReleases);
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
