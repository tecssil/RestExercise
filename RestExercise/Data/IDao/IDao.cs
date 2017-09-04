using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestExercise.Data.IDao
{
    /// <summary>
    /// Interface to be implemented
    /// </summary>
    /// <typeparam name="Param">Parameter</typeparam>
    /// <typeparam name="Result">Result</typeparam>
    public interface IDao<Param,Result>
    {
        Result GetAll();
        Result GetById(string id);
        int Create(Param param);
        bool Update(Param param);
        bool Delete(string id);

        void CreateLog(string lEvent,string description, bool connState);
    }
}
