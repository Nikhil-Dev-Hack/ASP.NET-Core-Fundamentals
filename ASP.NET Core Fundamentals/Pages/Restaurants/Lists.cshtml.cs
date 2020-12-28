using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevilDev.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using DevilDev.Core;

namespace ASP.NET_Core_Fundamentals.Pages.Restaurants
{
    public class ListsModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public IEnumerable<Restaurant> Restaurants { get; set; }
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }



        public ListsModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public void OnGet()
        {
            //SearchTerm = searchTerm;
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
