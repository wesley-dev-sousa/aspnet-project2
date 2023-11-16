using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence
{
    public class AppInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            var initializer = new AppInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(AppDbContext context)
        {
            context.Database.EnsureCreated();
        }

    }
}
