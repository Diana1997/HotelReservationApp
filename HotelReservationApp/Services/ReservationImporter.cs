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

using System.Xml.Linq;
using HotelReservationApp.Data;
using HotelReservationApp.Interfaces;
using HotelReservationApp.Models;

namespace HotelReservationApp.Services;

public class ReservationImporter : IReservationImporter
{
    private readonly ReservationContext _context;

    public ReservationImporter(ReservationContext context)
    {
        _context = context;
    }

    public async Task<List<Reservation>> ImportFromXmlAsync(Stream xmlStream)
    {
        var doc = XDocument.Load(xmlStream);

        var reservations = doc.Descendants("reservation").Select(x => new Reservation
        {
            GuestName = x.Element("guestName")?.Value ?? "",
            RoomNumber = x.Element("roomNumber")?.Value ?? "",
            CheckInDate = Convert.ToDateTime(x.Element("checkIn")?.Value ?? ""),
            CheckOutDate = Convert.ToDateTime(x.Element("checkOut")?.Value ?? "")
        }).ToList();

        await _context.Reservations.AddRangeAsync(reservations);
        await _context.SaveChangesAsync();

        return reservations;
    }
}