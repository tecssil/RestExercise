using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestExercise.Data.IDao;
using RestExercise.Data.Factory;

namespace RestExercise.Control.Commands
{
    /// <summary>
    /// Command to connect to the Dao and Delete a User
    /// </summary>
    class CommandRemoveUser : Command<string, bool>
    {
        /// <summary>
        /// Execution of the Command
        /// </summary>
        /// <param name="param">Id</param>
        /// <returns>Boolean</returns>
        public override bool Execute(string param)
        {
            string strClass = "CommandRemoveUser";
            bool result = false;
            try
            {
                IDaoUser daoUser = FactoryDao.GetDaoUser();
                result = daoUser.Delete(param);

            }
            catch (Exception e)
            {
                IDaoUser daoUser = FactoryDao.GetDaoUser();
                daoUser.CreateLog(strClass, "There was a problem exectuting the command to delete users", true);
                throw new Exception("There was a problem exectuting the command to delete users", e);
            }
            return result;
        }
    }
}