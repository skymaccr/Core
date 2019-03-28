using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    /// <summary>
    /// Un view component es completamente independiente de la pagina y de los modelos de esta
    /// no es como un partial view que depende de los modelos de la pagina
    /// </summary>
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        /// <summary>
        /// El metodo invoke es el que se va a ejecutar para obtener los datos
        /// </summary>
        /// <returns></returns>
        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetCountOfRestaurants();
            return View(count);
        }
    }
}
