using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using RestExercise.Domain.Entities;

namespace RestExercise.Data.IDao
{
    /// <summary>
    /// Interface of Users to be implemented
    /// </summary>
    public interface IDaoUser : IDao <User,DataSet>
    {
    }
}
