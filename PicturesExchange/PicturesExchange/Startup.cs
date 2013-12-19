using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PicturesExchange.Startup))]
namespace PicturesExchange
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
