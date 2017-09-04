using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.ServiceModel.Activation;
using RestExercise.Data;
using RestExercise.Domain.Entities;
using RestExercise.Control.Commands;
using RestExercise.Control.Factory;
using System.Web;

namespace RestExercise
{
    /// <summary>
    /// REST Service that receives and generates the responses
    /// </summary>
    //The following line enables the using of the route in the Global.asax file
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service : IService
    {

        /// <summary>
        /// Method to get all Users using the Commands
        /// </summary>
        /// <returns>List of user</returns>wfc
        public List<User> GetAll()
        {
            try
            {
                Command<bool, List<Entity>> CommandGetAll;
                CommandGetAll = FactoryCommand.GetCommandGetAll();

                return CommandGetAll.Execute(true).Cast<User>().ToList();
            }
            catch (Exception e)
            {
                Command<Exception, bool> CommandCreateLog;
                CommandCreateLog = FactoryCommand.GetCommandCreateLog();
                CommandCreateLog.Execute(e);
            }

            return null;
        }

        /// <summary>
        /// Method to get one user using the Commands
        /// </summary>
        /// <param name="id">Id of the user</param>
        /// <returns>User</returns>
        public User GetUser(string id)
        {
            try
            {
                Command<string, Entity> CommandGetUser;
                CommandGetUser = FactoryCommand.GetCommandGetUser();

                return (User)CommandGetUser.Execute(id);
            }
            catch (Exception e)
            {
                Command<Exception, bool> CommandCreateLog;
                CommandCreateLog = FactoryCommand.GetCommandCreateLog();
                CommandCreateLog.Execute(e);
            }

            return null;
        }

        /// <summary>
        /// Method to Create users using the Commands
        /// </summary>
        /// <param name="user">User to be created</param>
        /// <returns>User</returns>
        public User CreateUser(User user)
        {
            try
            {
                Command<Entity, Entity> CommandCreateUser;
                CommandCreateUser = FactoryCommand.GetCommandCreateUser();

                return (User)CommandCreateUser.Execute(user);
            }
            catch (Exception e)
            {
                Command<Exception, bool> CommandCreateLog;
                CommandCreateLog = FactoryCommand.GetCommandCreateLog();
                CommandCreateLog.Execute(e);
            }

            return null;
        }

        /// <summary>
        /// Method to update users using the Commands
        /// </summary>
        /// <param name="user">User to be updated</param>
        /// <returns>User</returns>
        public User UpdateUser(User user)
        {
            try
            {
                Command<Entity, Entity> CommandUpdateUser;
                CommandUpdateUser = FactoryCommand.GetCommandUpdateUser();

                return (User)CommandUpdateUser.Execute(user);
            }
            catch (Exception e)
            {
                Command<Exception, bool> CommandCreateLog;
                CommandCreateLog = FactoryCommand.GetCommandCreateLog();
                CommandCreateLog.Execute(e);
            }

            return null;
        }

        /// <summary>
        /// Method to delete usersusing the Commands
        /// </summary>
        /// <param name="id">Id of the user</param>
        public void RemoveUser(string id)
        {
            try
            {
                Command<string, bool> CommandRemoveUser;
                CommandRemoveUser = FactoryCommand.GetCommandRemoveUser();

                CommandRemoveUser.Execute(id);
            }
            catch (Exception e)
            {
                Command<Exception, bool> CommandCreateLog;
                CommandCreateLog = FactoryCommand.GetCommandCreateLog();
                CommandCreateLog.Execute(e);
            }

        }
    }
}
