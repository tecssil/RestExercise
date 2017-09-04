using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestExercise.Domain.Entities;
using RestExercise.Data.IDao;
using RestExercise.Data.Factory;
using System.Data;
using RestExercise.Control.Factory;

namespace RestExercise.Control.Commands
{
    /// <summary>
    /// Command to connect to the Dao and get all users
    /// </summary>
    class CommandGetAll : Command<bool,List<Entity>>
    {
        /// <summary>
        /// Execution of the Command
        /// </summary>
        /// <param name="param">Boolean</param>
        /// <returns>List of Users</returns>
        public override List<Entity> Execute(bool param)
        {
            string strClass = "CommandGetAll";
            List<Entity> list = new List<Entity>();

            try
            {
            IDaoUser daoUser = FactoryDao.GetDaoUser();
            DataSet dsUser = daoUser.GetAll();

            Command<DataSet, List<Entity>> commandConvertToJSON = FactoryCommand.GetCommandConvertUserIntoJSON();

            list = commandConvertToJSON.Execute(dsUser);

            }
            catch (Exception e)
            {
                IDaoUser daoUser = FactoryDao.GetDaoUser();
                daoUser.CreateLog(strClass, "There was a problem exectuting the command to get all users", true);
                throw new Exception("There was a problem exectuting the command to get all users", e);
            }
            return list;

        }
    }
}