using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestExercise.Data.IDao;
using RestExercise.Data.Dao;

namespace RestExercise.Data.Factory
{
    /// <summary>
    /// Class to construct new Dao
    /// </summary>
    public class FactoryDao
    {
        /// <summary>
        /// Create a DaoUser
        /// </summary>
        /// <returns>Dao Interface</returns>
        public static IDaoUser GetDaoUser()
        {
            return new DaoUser();
        }
    }
}