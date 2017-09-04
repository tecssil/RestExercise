using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using RestExercise.Domain.Entities;

namespace RestExercise
{
    /// <summary>
    /// Interface that sets the enpoints to be use in the service and it's properties
    /// </summary>
    [ServiceContract]
    public interface IService
    {
        /// <summary>
        /// Endpoint to get all users
        /// </summary>
        /// <returns>List of users</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "/user/getall",
            ResponseFormat = WebMessageFormat.Json,
            Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<User> GetAll();

        /// <summary>
        /// Endpoint to get a user
        /// </summary>
        /// <param name="id">Id of the user</param>
        /// <returns>Searched user</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "/user/get/{id}",
            ResponseFormat = WebMessageFormat.Json,
            Method = "GET",
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        User GetUser(string id);

        /// <summary>
        /// Endpoint to create users
        /// </summary>
        /// <param name="user">To be created</param>
        /// <returns>Created user</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "/user/create",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "POST",
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        User CreateUser(User user);

        /// <summary>
        /// Endpoint to update users
        /// </summary>
        /// <param name="user">To be updated</param>
        /// <returns>Updated user</returns>
        [OperationContract]
        [WebInvoke(UriTemplate = "/user/update",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            Method = "PUT",
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        User UpdateUser(User user);

        /// <summary>
        /// Endpoint to delete users
        /// </summary>
        /// <param name="id">Id of the user</param>
        [OperationContract]
        [WebInvoke(UriTemplate = "/user/remove/{id}",
            Method = "DELETE",
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        void RemoveUser(string id);
    }

}
