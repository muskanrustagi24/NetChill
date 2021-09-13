using NetChill.Backend.DataAccess.Services;
using NetChill.Backend.Domain;
using System;
using System.Collections.Generic;

namespace NetChill.Backend.BusinessLogic
{
    public class UserBusinessLogic
    {
        private readonly IUserDataAccess _userDataAccess;
        public UserBusinessLogic()
        {
            this._userDataAccess = new UserDataAccess();
        }

        /// <inheritdoc cref="IUserDataAccess.DoesUserExist(User)"/>
        public bool DoesUserExist(User user)
        {
            return _userDataAccess.DoesUserExist(user);
        }

        /// <inheritdoc cref="IUserDataAccess.AddUser(User)"/>
        public void AddUser(User user)
        {
            _userDataAccess.AddUser(user);
        }

        /// <inheritdoc cref="IUserDataAccess.GetUser(Guid)"/>
        public User GetUser(Guid id)
        {
            return _userDataAccess.GetUser(id);
        }

        /// <inheritdoc cref="IUserDataAccess.GetUser(string)"/>
        public User GetUser(string email)
        {
            return _userDataAccess.GetUser(email);
        }

        /// <inheritdoc cref="IUserDataAccess.DeleteUser(Guid)"/>
        public bool DeleteUser(Guid userId) {
            return _userDataAccess.DeleteUser(userId);
        }

        /// <inheritdoc cref="IUserDataAccess.GetAllUsers()"/>
        public IEnumerable<User> GetAllUsers()
        {
            return _userDataAccess.GetAllUsers();
        }
    }
}
