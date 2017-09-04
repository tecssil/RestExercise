using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestExercise.Domain.Entities;

namespace RestExercise.Domain.Factory
{
    /// <summary>
    /// Class to construct new Entities
    /// </summary>
    public class FactoryEntity
    {
        /// <summary>
        /// Create a blank user
        /// </summary>
        /// <returns>User</returns>
        public static Entity GetUser()
        {
            return new User();
        }

        /// <summary>
        /// Create a user from it's attributes
        /// </summary>
        /// <param name="id">Id of user</param>
        /// <param name="name">Name of user</param>
        /// <param name="birthdate">Birthdate of user</param>
        /// <returns>User</returns>
        public static Entity GetUser(int id, string name, string birthdate)
        {
            return new User(id, name, birthdate);
        }
    }
}