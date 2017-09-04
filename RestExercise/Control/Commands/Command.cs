using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestExercise.Control.Commands
{
    /// <summary>
    /// Abstract class to be implemented as needed
    /// </summary>
    /// <typeparam name="Param">Parameters of the Command</typeparam>
    /// <typeparam name="Result">Result of the Command</typeparam>
    public abstract class Command<Param, Result>
    {
        /// <summary>
        /// Method for the Command execution
        /// </summary>
        /// <param name="param">Param</param>
        /// <returns>A Result</returns>
        public abstract Result Execute(Param param);
    }
}