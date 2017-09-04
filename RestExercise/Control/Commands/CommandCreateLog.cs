using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestExercise.Data.IDao;
using RestExercise.Data.Factory;

namespace RestExercise.Control.Commands
{
    /// <summary>
    /// Command to connect to the Dao and Create a Log entry
    /// </summary>
    public class CommandCreateLog : Command<Exception, bool>
    {
        /// <summary>
        /// Execution of the Command
        /// </summary>
        /// <param name="param">Exception</param>
        /// <returns>bool</returns>
        public override bool Execute(Exception ex)
        {
            string strClass = "CommandCreateLog";
            try
            {
                IDaoUser daoUser = FactoryDao.GetDaoUser();
                daoUser.CreateLog(strClass, ex.Message, true);

            }
            catch (Exception e)
            {
                IDaoUser daoUser = FactoryDao.GetDaoUser();
                daoUser.CreateLog(strClass, "There was a problem creating the log entry", true);
                throw new Exception("There was a problem creating the log entry", e);
            }
            return true;
        }
    }
}