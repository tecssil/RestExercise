using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestExercise.Control.Commands;
using RestExercise.Domain.Entities;
using System.Data;

namespace RestExercise.Control.Factory
{
    /// <summary>
    /// Class to construct new Commands
    /// </summary>
    public class FactoryCommand
    {
        /// <summary>
        /// Create a ConvertUserIntoJSON Command
        /// </summary>
        /// <returns>Command</returns>
        public static Command<DataSet, List<Entity>> GetCommandConvertUserIntoJSON()
        {
            return new CommandConvertUserIntoJSON();
        }

        /// <summary>
        /// Create a CommandGetAll Command
        /// </summary>
        /// <returns>Command</returns>
        public static Command<bool, List<Entity>> GetCommandGetAll()
        {
            return new CommandGetAll();
        }

        /// <summary>
        /// Create a CommandGetUser Command
        /// </summary>
        /// <returns>Command</returns>
        public static Command<string, Entity> GetCommandGetUser()
        {
            return new CommandGetUser();
        }

        /// <summary>
        /// Create a CommandCreateUser Command
        /// </summary>
        /// <returns>Command</returns>
        public static Command<Entity, Entity> GetCommandCreateUser()
        {
            return new CommandCreateUser();
        }

        /// <summary>
        /// Create a CommandUpdateUser Command
        /// </summary>
        /// <returns>Command</returns>
        public static Command<Entity, Entity> GetCommandUpdateUser()
        {
            return new CommandUpdateUser();
        }

        /// <summary>
        /// Create a CommandRemoveUser Command
        /// </summary>
        /// <returns>Command</returns>
        public static Command<string, bool> GetCommandRemoveUser()
        {
            return new CommandRemoveUser();
        }

        /// <summary>
        /// Create a CommandCreateLog Command
        /// </summary>
        /// <returns>Command</returns>
        public static Command<Exception, bool> GetCommandCreateLog()
        {
            return new CommandCreateLog();
        }
    }
}