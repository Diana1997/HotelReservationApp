// __________________
// 
// [2016] - 2025 ICVR LLC
// All Rights Reserved.
// 
// NOTICE:  All information contained herein is, and remains
// the property of ICVR LLC and its suppliers,
// if any.  The intellectual and technical concepts contained
// herein are proprietary to ICVR LLC
// and its suppliers and may be covered by U.S. and Foreign Patents,
// patents in process, and are protected by trade secret or copyright law.
// Dissemination of this information or reproduction of this material
// is strictly forbidden unless prior written permission is obtained
// from ICVR LLC.

using HotelReservationApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly ReservationImporter _importer;
    private readonly IWebHostEnvironment _env;

    public ReservationsController(ReservationImporter importer, IWebHostEnvironment env)
    {
        _importer = importer;
        _env = env;
    }

    [HttpPost("import-from-file")]
    public async Task<IActionResult> ImportFromProjectFile()
    {
        var filePath = Path.Combine(_env.ContentRootPath, "reservation_sample.xml");

        if (!System.IO.File.Exists(filePath))
            return NotFound("Sample XML file not found in project.");

        await using var stream = System.IO.File.OpenRead(filePath);
        var reservations = await _importer.ImportFromXmlAsync(stream);

        return Ok(new
        {
            message = $"{reservations.Count} reservations imported from local file.",
            data = reservations
        });
    }
}