
using Microsoft.AspNetCore.Mvc;

namespace RoundTheCode.DotNet6;

[Route("datetime")]
public class DateTimeController : Controller
{
    [HttpGet("date-only")]
    public IActionResult DateOnly()
    {
        var date = new DateOnly(2021, 8, 28);

        var weekLater = date.AddDays(7);

        return Json(weekLater);
    }

    [HttpGet("time-only")]
    public IActionResult TimeOnly()
    {
        var time = new TimeOnly(18, 00);

        var eightHoursLater = time.AddHours(8);

        return Json(eightHoursLater);
    }
}
