using Alice.Dialogs.Anegdots.Repository.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Alice.Dialogs.Anegdots.Repository
{
    public static class DependencyInjection
    {
        public static void AddMyAliceService(this IServiceCollection services)
        {
            services.AddSingleton<IAnegdotsSerivce, AnegdotsSerivce>();
        }
    }

}