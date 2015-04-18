using System;

using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;

using Owin;


namespace Ginger.Server
{
    public sealed class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            //app.MapSignalR();
            var hubConfiguration = new HubConfiguration { EnableDetailedErrors = true };
            app.MapSignalR(hubConfiguration);
        }
    }
}
