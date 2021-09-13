using NetChill.Backend.BusinessLogic;
using NetChill.Backend.Domain;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace NetChill.Backend.Presentation.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/signup")]
    public class SignupController : ApiController
    {
        private readonly UserBusinessLogic _userBusinessLogic;

        public SignupController()
        {
            _userBusinessLogic = new UserBusinessLogic();
        }

        /// <summary>
        /// Handles the request to sign up a new user
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Signed in user</returns>
        [HttpPost]
        [Route()]
        public IHttpActionResult SignUp(User user)
        {
            try
            {
                var userExists = _userBusinessLogic.GetUser(user.Email);

                if (userExists != null)
                {
                    return InternalServerError();
                }
                else
                {
                        User newUser = new User
                        {
                            FullName = user.FullName,
                            Email = user.Email,
                            Password = user.Password,
                            Role = user.Role
                        };

                        _userBusinessLogic.AddUser(newUser);
                        return Ok();
                         
                }

            }
            catch (Exception exception)
            {
                return InternalServerError(exception);
            }

        }
    }
}
