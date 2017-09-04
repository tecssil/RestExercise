using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestExercise.Domain.Entities;
using RestExercise.Data.IDao;
using RestExercise.Data.Factory;

namespace RestExercise.Control.Commands
{
    /// <summary>
    /// Command to connect to the Dao and Update a User
    /// </summary>
    class CommandUpdateUser : Command<Entity, Entity>
    {
        /// <summary>
        /// Execution of the Command
        /// </summary>
        /// <param name="param">User</param>
        /// <returns>User</returns>
        public override Entity Execute(Entity param)
        {
            string strClass = "CommandUpdateUser";
            try
            {
                IDaoUser daoUser = FactoryDao.GetDaoUser();
                daoUser.Update((User)param);
            }
            catch (Exception e)
            {
                IDaoUser daoUser = FactoryDao.GetDaoUser();
                daoUser.CreateLog(strClass, "There was a problem exectuting the command to update users", true);
                throw new Exception("There was a problem exectuting the command to update users", e);
            }
            return param;
        }
    }
}