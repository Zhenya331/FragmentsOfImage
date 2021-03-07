using System.Web.Http;
using WebApiServer.App_Start;

namespace WebApiServer
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.Configure();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
