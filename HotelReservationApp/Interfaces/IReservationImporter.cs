﻿// __________________
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

using HotelReservationApp.Models;

namespace HotelReservationApp.Interfaces;

public interface IReservationImporter
{
    Task<List<Reservation>> ImportFromXmlAsync(Stream xmlStream);
}