using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(News.Web.Startup))]
namespace News.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
