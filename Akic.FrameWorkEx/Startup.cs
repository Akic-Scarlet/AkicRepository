using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Akic.FrameWorkEx.Startup))]
namespace Akic.FrameWorkEx
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
