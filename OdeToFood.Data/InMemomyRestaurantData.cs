using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemomyRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemomyRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                 new Restaurant(){ Id = 1, Cousine = CousineType.Italian, Location="San Jose", Name="Pan e vino"},
                 new Restaurant(){ Id = 2, Cousine= CousineType.Mexican, Location="Cartago", Name="Antojitos"},
                 new Restaurant(){ Id = 3, Cousine= CousineType.Indian, Location="San Jose", Name="Jama que Jame"}
            };
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            restaurants.Add(newRestaurant);            
            return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public int GetCountOfRestaurants()
        {
            return restaurants.Count;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cousine = updatedRestaurant.Cousine;
            }
            return restaurant;
        }
    }
}
