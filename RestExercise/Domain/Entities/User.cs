using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace RestExercise.Domain.Entities
{
    /// <summary>
    /// Object User Class 
    /// </summary>
    public class User : Entity
    {
        #region Attributes
        //USER_ID
        private int id;
        //USER_NAME
        private string name;
        //USER_BIRTHDATE
        private string birthdate;
        #endregion

        #region Gets & Sets
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Birthdate
        {
            get { return birthdate; }
            set { birthdate = value; }
        }
        #endregion

        #region Constructors
        public User()
        {
            id = -1;
            name = "";
            birthdate = "";
        }

        public User(int idUser, string nameUser, string birthdateUser)
        {
            id = idUser;
            name = nameUser;
            birthdate = birthdateUser;
        }
        #endregion

    }
}