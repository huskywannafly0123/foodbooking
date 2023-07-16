using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using foodbooking.Entities;
using foodbooking.Mappers;
using foodbooking.Utils;
using Google.Apis.Sheets.v4;
using Microsoft.AspNetCore.Mvc;

namespace foodbooking.Controllers
{
    [ApiController]
    [Route("api/food")]
    public class FoodApiController : ControllerBase
    {
        
        const string SPREADSHEET_ID = "1TEBUcuCy7vIeNB60p3I1HF2SlKk5-IPBMHa2kOfGrhY";
        const string SHEET_NAME = "Food";
        SpreadsheetsResource.ValuesResource _googleSheetValues;
        public FoodApiController(GoogleSheetsHelper googleSheetsHelper){
            _googleSheetValues = googleSheetsHelper.Service.Spreadsheets.Values;
        }
        // GET api/values return List<FoodItemEntity>
        [HttpGet]
        public ActionResult<IEnumerable<FoodItemEntity>> Get()
        {
            var range = $"{SHEET_NAME}!A:D";
            var request = _googleSheetValues.Get(SPREADSHEET_ID, range);
            var response = request.Execute();
            var values = response.Values;
            IEnumerable<FoodItemEntity> foodItems = FoodItemsMapper.MapFromRangeData(values);
            return Ok(foodItems);
        }
    }
}