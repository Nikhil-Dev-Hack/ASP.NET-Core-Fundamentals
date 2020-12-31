using DevilDev.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DevilDev.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant UpdatedRestaurant);
        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1 , Name = "Dominos Pizza",Location= "Madhapur" , Cusine = CusineType.Pizza},
                new Restaurant { Id = 2 , Name = "Burger King" , Location = "Hitech city" , Cusine = CusineType.Burger},
                new Restaurant { Id = 3 , Name = "Mehfil" , Location = "PragathiNagar" , Cusine = CusineType.Biriyani},
                new Restaurant { Id = 4 , Name = "None" , Location = "Earth" , Cusine = CusineType.None}

            };
        }
        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant UpdatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == UpdatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = UpdatedRestaurant.Name;
                restaurant.Location = UpdatedRestaurant.Location;
                restaurant.Cusine = UpdatedRestaurant.Cusine;
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public int Commit()
        {
            return 0;
        }

    }
}
