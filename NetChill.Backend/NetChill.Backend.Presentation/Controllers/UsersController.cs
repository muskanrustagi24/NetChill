using NetChill.Backend.BusinessLogic;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace NetChill.Backend.Presentation.Controllers
{
    [EnableCors(origins: "*"  , headers:"*" , methods:"*")]
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        private readonly UserBusinessLogic _userBusinessLogic;

        public UsersController()
        {
            _userBusinessLogic = new UserBusinessLogic();
        }

        /// <summary>
        /// Handles the request to get all users
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        [Route()]
        public IHttpActionResult GetAllUsers()
        {
            var result = _userBusinessLogic.GetAllUsers();
            return Ok(result);
        }

        /// <summary>
        /// Handles the request to get user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User with given Id</returns>
        [HttpGet]
        [Route("{id}")]
        public IHttpActionResult GetUser(Guid id)
        {
            var result = _userBusinessLogic.GetUser(id);

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        /// <summary>
        /// Handles the request to delete a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult DeleteUser(Guid id)
        {
            try
            {
                bool result = this._userBusinessLogic.DeleteUser(id);
                if (result)
                {
                    return Ok();
                }
                else {
                    return NotFound();
                }
            }
            catch (Exception ex) {
                return InternalServerError(ex);
            }
        }
    
    }
}
