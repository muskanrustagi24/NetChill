using NetChill.Backend.BusinessLogic;
using NetChill.Backend.Domain;
using NetChill.Backend.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace NetChill.Backend.Presentation.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/mylist")]
    public class MyListController : ApiController
    {
        private readonly MovieListBusinessLogic _movieListBusinessLogic;

        private readonly UserBusinessLogic _userBusinessLogic;

        private readonly MovieBusinessLogic _movieBusinessLogic;

        public MyListController()
        {
            this._movieListBusinessLogic = new MovieListBusinessLogic();
            this._movieBusinessLogic = new MovieBusinessLogic();
            this._userBusinessLogic = new UserBusinessLogic();
        }

        /// <summary>
        /// Handles the request to add movie to user's list
        /// </summary>
        /// <param name="addToMyListModel"></param>
        /// <returns></returns>
        [Route()]
        [HttpPost]
        public IHttpActionResult AddToMyList(AddToMyListModel addToMyListModel)
        {
            try
            {
                
                bool result = this._movieListBusinessLogic.AddMovieToMovieList(addToMyListModel.MovieId, addToMyListModel.UserId);
                if (result)
                {
                    return Ok();
                }
                else {
                    return NotFound();
                }

            }
            catch (Exception exception) {
                Console.WriteLine(exception.Message);
                return InternalServerError();
            }

        }

        /// <summary>
        /// Use to display list of movies added to 'My List' by user
        /// </summary>
        /// <param name="id"></param>
        /// <returns>List of movies</returns>

        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetMyList(Guid id)
        {
            try
            {
                var movies = this._movieListBusinessLogic.GetMyMovies(id);
                if (movies != null)
                {
                    
                    return Ok(movies);
                }
                else {
                    return NotFound();
                }
            }
            catch (Exception exception) {
                Console.WriteLine(exception.Message);
                return InternalServerError();
            }
        }
    
    }
}