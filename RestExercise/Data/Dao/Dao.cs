using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace RestExercise.Data.Dao
{
    /// <summary>
    /// Abstract class to be implemented as needed
    /// </summary>
    public abstract class Dao
    {
        private static SqlConnection conn;

        #region OpenConnection
        /// <summary>
        /// Method to open the connection to the data base
        /// </summary>
        /// <returns>The SqlConnetion to handle operation of the data base</returns>
        public SqlConnection OpenConnection()
        {
            string strConn = "";

            try
            {
                //Get Connection String to the data base
                strConn = ConfigurationManager.ConnectionStrings["strConnDB"].ToString();
                conn = new SqlConnection(strConn);
                conn.Open();

                return conn;
            }
            catch (Exception ex)
            {
                //Connection could not be started
                throw new Exception("The connection to the Data Base failed to open",ex);
            }
        }
        #endregion


        #region CloseConnection
        /// <summary>
        /// Method to close the connetion to the data base if exist
        /// </summary>
        public void CloseConnection()
        {
            if (conn != null)
            {
                //Close Connection to data base
                if (conn.State == ConnectionState.Open)
                    conn.Close();
                else
                    //Connection could not be close
                    throw new Exception("The connection to the Data Base failed to close");
            }
        }
        #endregion

    }
}