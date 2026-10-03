using System;
using System.Collections.Generic;
using System.Text;

namespace Part2_HotelReservationSystem
{
    public class Guest
    {

        private readonly List<Reservation> _reservations = new();
        public string FullName { get; }
        public int GuestId { get; }
        public string PhoneNumber { get; }

        public IReadOnlyList<Reservation> Reservations => _reservations.AsReadOnly();

        public Guest(string FullName, int GuestId, string PhoneNumber)
        {
            if (string.IsNullOrWhiteSpace(FullName))
                throw new ArgumentException("Full name cannot be null or empty.", nameof(FullName));
            if (GuestId <= 0)
                throw new ArgumentException("Guest ID must be strictly positive.", nameof(GuestId));
            if (string.IsNullOrWhiteSpace(PhoneNumber))
                throw new ArgumentException("Phone number must be strictly positive.", nameof(PhoneNumber));
            this.FullName = FullName;
            this.GuestId = GuestId;
            this.PhoneNumber = PhoneNumber;
        }

        public void AddReservation(Reservation reservation)
        {
            if(reservation==null)
                throw new ArgumentNullException(nameof(reservation), "Reservation cannot be null.");

            bool hasOverlap = _reservations.Any(r =>
                r.Room.RoomNumber == reservation.Room.RoomNumber &&
                r.Status != ReservationStatus.Cancelled &&
                r.Status != ReservationStatus.CheckedOut &&
                reservation.CheckInDate < r.CheckOutDate &&
                reservation.CheckOutDate > r.CheckInDate);

            if (hasOverlap)
                throw new InvalidOperationException($"Double-booking detected! Room #{reservation.Room.RoomNumber} is already reserved for overlapping dates.");

            _reservations.Add(reservation);
        }

    }
}
