using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using foodbooking.Models;

namespace foodbooking.Mappers
{
    public class FoodItemsMapper
    {
        public static List<FoodItemModel> MapFromRangeData(IList<IList<object>> values)
        {
            var items = new List<FoodItemModel>();
            foreach (var value in values)
            {
                FoodItemModel item = new()
                {
                    Id = (int) value[0],
                    Name = value[1].ToString(),
                    Price = (int) value[2],
                    Url = value[3].ToString()
                };
                items.Add(item);
            }
            return items;
        }
        public static IList<IList<object>> MapToRangeData(FoodItemModel item)
        {
            var objectList = new List<object>() { item.Id, item.Name, item.Price, item.Url };
            var rangeData = new List<IList<object>> { objectList };
            return rangeData;
        }
    }
}