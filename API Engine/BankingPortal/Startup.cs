using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Net451.Microsoft.Extensions.DependencyInjection;

[assembly: OwinStartup(typeof(BankingPortal.Startup))]

namespace BankingPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
        
        
    }
}
