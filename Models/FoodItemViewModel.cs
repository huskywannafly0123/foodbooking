using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using foodbooking.Entities;

namespace foodbooking.Models
{
    public class FoodItemViewModel
    {
        public List<FoodItemEntity> foodItems { get; set; }
        public FoodItemViewModel(List<FoodItemEntity> foodItemsParam)
        {
            this.foodItems = foodItemsParam;
        }
    }
}