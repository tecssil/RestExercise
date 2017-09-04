using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using RestExercise.Domain.Entities;
using RestExercise.Domain.Factory;
using RestExercise.Data.Factory;
using RestExercise.Data.IDao;

namespace RestExercise.Control.Commands
{
    /// <summary>
    /// Commands that converts a DataSet from the Query into a Object User to be shown as a JSON
    /// </summary>
    class CommandConvertUserIntoJSON : Command<DataSet, List<Entity>>
    {
        /// <summary>
        /// Execution of the Command
        /// </summary>
        /// <param name="param">DataSet from DB</param>
        /// <returns>List of Users</returns>
        public override List<Entity> Execute(DataSet param)
        {
            string strClass = "CommandConvertUserIntoJSON";
            List<Entity> list = new List<Entity>();
            int result;
            DateTime resultDT;

            try
            {
                if (param != null)
                {
                    foreach (DataRow dr in param.Tables["DATA"].Rows)
                    {
                        Entity user = FactoryEntity.GetUser();

                        ((User)user).Id = (dr["USER_ID"] != null && !String.IsNullOrEmpty(dr["USER_ID"].ToString())) ? 
                            (int.TryParse(dr["USER_ID"].ToString(), out result) ? int.Parse(dr["USER_ID"].ToString()) : -1) : -1;
                        ((User)user).Name = (dr["USER_NAME"] != null && !String.IsNullOrEmpty(dr["USER_NAME"].ToString())) ? 
                            dr["USER_NAME"].ToString() : "";
                        ((User)user).Birthdate = (dr["USER_BIRTHDATE"] != null && !String.IsNullOrEmpty(dr["USER_BIRTHDATE"].ToString())) ?
                            (DateTime.TryParse(dr["USER_BIRTHDATE"].ToString(), out resultDT) ?
                            DateTime.Parse(dr["USER_BIRTHDATE"].ToString()).Month.ToString() + "-" +
                            DateTime.Parse(dr["USER_BIRTHDATE"].ToString()).Day.ToString() + "-" +
                            DateTime.Parse(dr["USER_BIRTHDATE"].ToString()).Year.ToString() : "") : "";

                        list.Add(user);

                    }
                }
            }
            catch (Exception e)
            {
                IDaoUser daoUser = FactoryDao.GetDaoUser();
                daoUser.CreateLog(strClass, "There was a problem converting the user into a JSON", true);
                throw new Exception("There was a problem converting the user into a JSON", e);
            }
            return list;
        }
    }
}