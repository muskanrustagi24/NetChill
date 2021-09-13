using NetChill.Backend.BusinessLogic;
using NetChill.Backend.Domain;
using NetChill.Backend.Presentation.Models;
using System;
using System.Web.Http;
using System.Web.Http.Cors;

namespace NetChill.Backend.Presentation.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/login")]
    public class LoginController: ApiController
    {
        private readonly UserBusinessLogic _userBusinessLogic;

        public LoginController()
        {
            _userBusinessLogic = new UserBusinessLogic();
        }

        /// <summary>
        /// Handles the login request of user 
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns>Logged in user</returns>
        [HttpPost]
        [Route()]
        public IHttpActionResult Login(LoginUserModel loginUser)
        {
            try
            {
                User user = new User
                {
                    Email = loginUser.Email,
                    Password = loginUser.Password
                };

                bool result =  _userBusinessLogic.DoesUserExist(user);
                if (result)
                {
                    user = _userBusinessLogic.GetUser(loginUser.Email);
                    
                    return Ok(user);
                }
                else {
                    return InternalServerError();
                }
                
            }
            catch (Exception exception) {
                Console.WriteLine(exception.Message);
                return InternalServerError();
            }
        }
    
    }
}