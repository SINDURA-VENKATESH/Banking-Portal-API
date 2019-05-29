using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using Net451.Microsoft.Extensions.DependencyInjection;
using NLog;
using Castle.Core.Configuration;
using System.IO;


[assembly: OwinStartup(typeof(BankingPortal.Startup))]

namespace BankingPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        

      

        public void ConfigureServices(IServiceCollection services)
        {

           
            
        }


    }
}
