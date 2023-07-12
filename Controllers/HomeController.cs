using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using foodbooking.Models;
using Google.Apis.Sheets.v4;
using foodbooking.Utils;
using foodbooking.Mappers;

namespace foodbooking.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    const string SPREADSHEET_ID = "1QKggcbsR8yrzDVsl7qqsjPI3fOWSNtANnywBqVGMLaU";
    const string SHEET_NAME = "Food";
    SpreadsheetsResource.ValuesResource _googleSheetValues;

    public HomeController(ILogger<HomeController> logger,GoogleSheetsHelper googleSheetsHelper)
    {
        _logger = logger;
        _googleSheetValues = googleSheetsHelper.Service.Spreadsheets.Values;
    }

    public IActionResult Index()
    {        
        var range = $"{SHEET_NAME}!A:D";
        var request = _googleSheetValues.Get(SPREADSHEET_ID, range);
        var response = request.Execute();
        var values = response.Values;
        return View(FoodItemsMapper.MapFromRangeData(values));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
