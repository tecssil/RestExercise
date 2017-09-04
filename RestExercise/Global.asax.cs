using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using System.ServiceModel.Activation;

namespace RestExercise
{
    /// <summary>
    /// Global class
    /// </summary>
    public class Global : System.Web.HttpApplication
    {

        /// <summary>
        /// Start of the application to enable the wrap of the route from "server/Service.svc" to "server/api"
        /// </summary>
        /// <param name="sender">Executor</param>
        /// <param name="e">Event</param>
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.Add(new ServiceRoute("api", new WebServiceHostFactory(), typeof(Service)));
        }

    }
}