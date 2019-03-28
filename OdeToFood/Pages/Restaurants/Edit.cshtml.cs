using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData RestaurantData;
        private readonly IHtmlHelper HtmlHelper;

        //bind property se utiliza para llenar una propiedad que va y viene de la pagina web
        //ejemplo para mantener el valor cuando se llena el modelo y que no se borre
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cousines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.RestaurantData = restaurantData;
            this.HtmlHelper = htmlHelper;
        }

        //el get solo se usa para obtener datos
        public IActionResult OnGet(int? restaurantId)
        {
            //este es un utilitario para crear un enum en una lista
            Cousines = HtmlHelper.GetEnumSelectList<CousineType>();
            if (restaurantId.HasValue)
                Restaurant = RestaurantData.GetById(restaurantId.Value);
            else
                Restaurant = new Restaurant();

            return Restaurant != null ? Page() : (IActionResult)RedirectToPage("./NotFound");
        }


        //el post solo se usa para enviar datos
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                //siempre se tiene que enviar cousines ya que no hay estado y los valores se pierden
                Cousines = HtmlHelper.GetEnumSelectList<CousineType>();
                return Page();
            }

            if(Restaurant.Id > 0)
                Restaurant = RestaurantData.Update(Restaurant);
            else
                Restaurant = RestaurantData.Add(Restaurant);
            
            RestaurantData.Commit();

            //aca se llena el temdata que se va a pasar a la pagina de detail
            TempData["Message"] = "Restaurant Saved!";
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}