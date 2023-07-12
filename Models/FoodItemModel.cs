using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace foodbooking.Models
{
    public class FoodItemModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Url { get; set; }
        public int Id { get; set; }
    }
}