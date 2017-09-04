using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestExercise.Domain.Entities;
using RestExercise.Domain.Factory;
using RestExercise.Data.IDao;
using RestExercise.Data.Factory;
using System.Data;
using RestExercise.Control.Factory;

namespace RestExercise.Control.Commands
{
    /// <summary>
    /// Command to connect to the Dao and get one user given the id
    /// </summary>
    class CommandGetUser : Command<string, Entity>
    {
        /// <summary>
        /// Execution of the Command
        /// </summary>
        /// <param name="param">Id</param>
        /// <returns>User</returns>
        public override Entity Execute(string param)
        {
            string strClass = "CommandGetUser";
            Entity user = FactoryEntity.GetUser();
            try
            {

                IDaoUser daoUser = FactoryDao.GetDaoUser();
                DataSet dsUser = daoUser.GetById(param);

                Command<DataSet, List<Entity>> commandConvertToJSON = FactoryCommand.GetCommandConvertUserIntoJSON();

                user = commandConvertToJSON.Execute(dsUser)[0];

            }
            catch (Exception e)
            {
                IDaoUser daoUser = FactoryDao.GetDaoUser();
                daoUser.CreateLog(strClass, "There was a problem exectuting the command to get one user", true);
                throw new Exception("There was a problem exectuting the command to get one user", e);
            }
            return user;
        }
    }
}