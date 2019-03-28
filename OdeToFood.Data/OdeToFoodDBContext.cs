using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;


namespace OdeToFood.Data
{
    public class OdeToFoodDBContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }

        //esto se inyecto desde el startup
        /*
         services.AddDbContextPool<OdeToFoodDBContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("OdeToFoodDb"));
            });
             */
        public OdeToFoodDBContext(DbContextOptions<OdeToFoodDBContext> options) : base(options)
        {

        }
    }
}

/**
 * C:\PROJECTS\Core\OdeToFood.Data>dotnet ef dbcontext list
 * -> encuentra el archivo dbcontext
 *
 * C:\PROJECTS\Core\OdeToFood.Data>dotnet ef dbcontext info -s ..\OdeToFood\OdeToFood.csproj
 * -> encuentra donde esta la configuracion para la base de datos
 * 
 * C:\PROJECTS\Core\OdeToFood.Data>dotnet ef migrations add initialcreate -s ..\OdeToFood\OdeToFood.csproj
 * 
 * -> crea las migraciones en el proyecto basado en las entidades creadas en dbcontext
 * 
 * C:\PROJECTS\Core\OdeToFood.Data>dotnet ef migrations add initialcreate -s ..\OdeToFood\OdeToFood.csproj
 * 
 * -> ejecuta la creacion de los objetos en la base de datos
 * 
 *                     _/\__
 *               ---==/    \\
 *                    |.    \|\
 *                    |  )   \\\
 *                    \_/ |  //|\\
 *                        /   \\\/\\
 * 
 * **/
