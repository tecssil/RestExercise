using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestExercise.Data.IDao;
using System.Data;
using System.Data.SqlClient;
using RestExercise.Domain.Entities;


namespace RestExercise.Data.Dao
{
    public class DaoUser : Dao, IDaoUser
    {
        #region GetAllUsers
        /// <summary>
        /// Method that gets all the users from the data base
        /// </summary>
        /// <returns>A DataSet fill with the users</returns>
        public DataSet GetAll()
        {
            string strClass = "GetUsers";
            string strSql = "";
            DataSet dsResult = new DataSet();
            SqlDataAdapter daResult;
            SqlConnection conn = new SqlConnection();

            try
            {
                //Query of the data base
                strSql = " SELECT US.USER_ID, US.USER_NAME, US.USER_BIRTHDATE  ";
                strSql += " FROM [USER] US ";
                //strSql += " ORDER BY US.USER_ID DESC";
                //Opening connection to DB
                conn = OpenConnection();
                //Executing query
                daResult = new SqlDataAdapter(strSql, conn);
                daResult.Fill(dsResult, "DATA");
                //Determine if the query got information
                if (dsResult.Tables["DATA"].Rows.Count > 0)
                {
                    CreateLog(strClass, "Successfully got all users", false);
                }
                //The query didn't return anything
                else
                {
                    CreateLog(strClass, "There are no users", false);
                }
            }
            catch (Exception ex)
            {
                CreateLog(strClass, "There was a problem getting all the users", false);
                throw new Exception("There was a problem getting all the user", ex);
            }
            finally
            {
                CloseConnection();
            }
            return dsResult;
        }
        #endregion

        #region GetUserById
        /// <summary>
        /// Method that gets a user from the data base given the user ID
        /// </summary>
        /// <returns>A DataSet fill with the searched user</returns>
        public DataSet GetById(string id)
        {
            string strClass = "GetUserById";
            string strSql = "";
            DataSet dsResult = new DataSet();
            SqlDataAdapter daResult;
            SqlConnection conn = new SqlConnection();

            try
            {
                //Query of the data base 
                strSql = " SELECT US.USER_ID, US.USER_NAME, US.USER_BIRTHDATE  ";
                strSql += " FROM [USER] US ";
                strSql += " WHERE US.USER_ID = " + id;
                //strSql += " ORDER BY US.USER_ID DESC";
                //Opening connection to DB
                conn = OpenConnection();
                // Executing query
                daResult = new SqlDataAdapter(strSql, conn);
                daResult.Fill(dsResult, "DATA");
                //Determine if the query got information
                if (dsResult.Tables["DATA"].Rows.Count > 0)
                {
                    CreateLog(strClass, "Successfully got the user", false);
                }
                //The query didn't return anything
                else
                {
                    CreateLog(strClass, "The user doesn't exist", false);
                }
            }
            catch (Exception ex)
            {
                CreateLog(strClass, "There was a problem getting the user", false);
                throw new Exception("There was a problem getting the user", ex);
            }
            finally
            {
                CloseConnection();
            }
            return dsResult;
        }
        #endregion

        #region CreateUser
        /// <summary>
        /// Method to create a user in the DB receiving the user information
        /// </summary>
        /// <returns>An int representing the created user ID</returns>
        public int Create(User param)
        {
            string strClass = "CreateUser";
            string strSql = "";
            int result = 0;
            SqlConnection conn = new SqlConnection();
            SqlCommand command = conn.CreateCommand();

            try
            {
                conn = OpenConnection();
                command.Connection = conn;
                //Insert to the table 
                strSql = " INSERT INTO [USER] ";
                strSql += " (USER_NAME,USER_BIRTHDATE) output INSERTED.[USER_ID] ";
                strSql += " VALUES('" + param.Name + "', CONVERT(datetime,'" + param.Birthdate + "',110)) ";
                //Opening connection to DB
                command.CommandText = strSql;
                //Executing insert and result is the inserted ID of the user
                result = (int)command.ExecuteScalar();
                if (result != 0)
                {
                    CreateLog(strClass, "Successfully created User " + result.ToString(),false);
                }
                else
                {
                    CreateLog(strClass, "There was a problem creating the new user",false);
                }
            }
            catch (Exception ex)
            {
                CreateLog(strClass, "There was a problem creating the new user",false);
                throw new Exception("There was a problem creating the new user",ex);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }
        #endregion

        #region UpdateUser
        /// <summary>
        /// Method to update a user receiving the user information
        /// </summary>
        public bool Update(User param)
        {
            string strClass = "UpdateUser";
            string strSql = "";
            int queryResult;
            bool result = false;
            SqlConnection conn = new SqlConnection();

            try
            {
                //Update for table 
                strSql = " UPDATE [USER] SET ";
                strSql += " USER_NAME = '" + param.Name + "', USER_BIRTHDATE = CONVERT(datetime,'" + param.Birthdate + "',110) ";
                strSql += " WHERE USER_ID = " + param.Id;
                //Opening connection to DB
                conn = OpenConnection();
                SqlCommand mySqlCommand = new SqlCommand(strSql, conn);
                //Executing update
                queryResult = mySqlCommand.ExecuteNonQuery();
                //Determine the update was done
                if (queryResult > 0)
                {
                    result = true;
                    CreateLog(strClass, "Successfully updated User " + param.Id, false);
                }
                else
                {
                    CreateLog(strClass, "There was a problem updating the user " + param.Id, false);
                }
            }
            catch (Exception ex)
            {
                CreateLog(strClass, "There was a problem updating the user " + param.Id, false);
                throw new Exception("There was a problem updating the user " + param.Id, ex);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }
        #endregion

        #region DeleteUser
        /// <summary>
        /// Method to delete a user from the DB given it's ID
        /// </summary>
        public bool Delete(string id)
        {
            string strClass = "DeleteUser";
            string strSql = "";
            int queryResult;
            bool result = false;
            SqlConnection conn = new SqlConnection();

            try
            {
                //Delete from table 
                strSql = " DELETE FROM [USER] ";
                strSql += " WHERE USER_ID = " + id;
                //Opening connection to DB
                conn = OpenConnection();
                SqlCommand mySqlCommand = new SqlCommand(strSql, conn);
                //Executing delete
                queryResult = mySqlCommand.ExecuteNonQuery();
                //Determine the deletion was done
                if (queryResult > 0)
                {
                    result = true;
                    CreateLog(strClass, "Successfully removed User " + id, false);
                }
                else
                {
                    CreateLog(strClass, "There was a problem removing the user " + id, false);
                }
            }
            catch (Exception ex)
            {
                CreateLog(strClass, "There was a problem removing the user " + id,false);
                throw new Exception("There was a problem removing the user " + id, ex);
            }
            finally
            {
                CloseConnection();
            }
            return result;
        }
        #endregion

        #region CreateLog
        /// <summary>
        /// Method to Insert in the Log
        /// </summary>
        /// <param name="lEvent">Event</param>
        /// <param name="description">Description of Event</param>
        public void CreateLog(string lEvent, string description, bool connState)
        {
            string strSql = "";
            int result = 0;
            SqlConnection conn = new SqlConnection();
            SqlCommand command = conn.CreateCommand();

            try
            {
                conn = OpenConnection();
                command.Connection = conn;
                //Insert to the table 
                strSql = " INSERT INTO [LOG] ";
                strSql += " (LOG_EVENT,LOG_DESCRIPTION) ";
                strSql += " VALUES('" + lEvent + "', '" + description + "') ";
                //Opening connection to DB
                command.CommandText = strSql;
                //Executing insert and result is the inserted ID of the user
                result = (int)command.ExecuteNonQuery();
                if (result != 0)
                {
                    //Log event was inserted
                }
                else
                {
                    throw new Exception("The event couldn't be logged");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("The event couldn't be logged", ex);
            }
            finally
            {
                if (connState)
                    CloseConnection();
            }
        }
        #endregion
    }
}