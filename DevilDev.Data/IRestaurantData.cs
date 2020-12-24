﻿using DevilDev.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevilDev.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
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
                new Restaurant { Id = 3 , Name = "Mehfil" , Location = "PagathiNagar" , Cusine = CusineType.Biriyani},
                new Restaurant { Id = 4 , Name = "None" , Location = "Earth" , Cusine = CusineType.None}

            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}