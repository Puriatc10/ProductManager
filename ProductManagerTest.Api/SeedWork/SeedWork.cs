using Microsoft.EntityFrameworkCore;
using ProductManagerTest.Persistance.Context;

namespace ProductManagerTest.Api.SeedWork
{
    public static class SeedWork
    {

        public static void DbConfigure(WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DataBaseContext>();
            dbContext.Database.Migrate();
        }
    }
}
