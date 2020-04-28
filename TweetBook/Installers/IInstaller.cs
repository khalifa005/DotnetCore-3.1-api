using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TweetBook.Installers
{
    public interface IInstaller
    { 
        public void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
