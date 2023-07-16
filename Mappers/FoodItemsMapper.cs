using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using foodbooking.Entities;
using foodbooking.Models;

namespace foodbooking.Mappers
{
    public class FoodItemsMapper
    {
        public static List<FoodItemEntity> MapFromRangeData(IList<IList<object>> values)
        {
            var items = new List<FoodItemEntity>();
            foreach (var value in values)
            {
                FoodItemEntity item = new()
                {
                    Id = int.Parse(value[0].ToString()),
                    Name = value[1].ToString(),
                    Price = int.Parse(value[2].ToString()),
                    Url = value[3].ToString()
                };
                items.Add(item);
            }
            return items;
        }
        public static IList<IList<object>> MapToRangeData(FoodItemEntity item)
        {
            var objectList = new List<object>() { item.Id, item.Name, item.Price, item.Url };
            var rangeData = new List<IList<object>> { objectList };
            return rangeData;
        }
    }
}