using NetChill.Backend.Domain;
using System;
using System.Collections.Generic;

namespace NetChill.Backend.DataAccess.Services
{
    public interface IUserDataAccess
    {
        /// <summary>
        /// Checks if the given users exists or not
        /// </summary>
        /// <param name="user">The user to be checked</param>
        /// <returns>True if user exists else false</returns>
        bool DoesUserExist(User user);

        /// <summary>
        /// Adds a user to the database
        /// </summary>
        /// <param name="user">The user to be added</param>
        /// <returns>True if we are successfully able to add the user else false</returns>
        bool AddUser(User user);

        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>User with given Id</returns>
        User GetUser(Guid id);

        /// <summary>
        /// Get user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns>User with given email</returns>
        User GetUser(string email);

        /// <summary>
        /// Deletes a user having the given user id
        /// </summary>
        /// <param name="userId">The id of the user to be deleted</param>
        /// <returns>true if the user is deleted else false</returns>
        bool DeleteUser(Guid userId);

        /// <summary>
        /// Gets all users that are stored in database
        /// </summary>
        /// <returns>List of users</returns>
        IEnumerable<User> GetAllUsers();
    }
}
