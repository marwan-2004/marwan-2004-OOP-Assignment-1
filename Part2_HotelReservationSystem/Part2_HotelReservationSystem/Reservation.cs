using System;

namespace Part2_HotelReservationSystem
{
    public class Reservation
    {
        public int ReservationId { get; }
        public DateTime CheckInDate { get; }
        public DateTime CheckOutDate { get; }
        public Room Room { get; }
        public ReservationStatus Status { get; private set; }

        // Calculated property: Nights * Nightly Rate
        public int Nights => (CheckOutDate - CheckInDate).Days;
        public decimal TotalCost => Nights * Room.NightlyRate;

        public Reservation(int reservationId, DateTime checkInDate, DateTime checkOutDate, Room room)
        {
            if (checkOutDate <= checkInDate)
                throw new ArgumentException("CheckOutDate must be strictly after CheckInDate.");

            if (room == null)
                throw new ArgumentNullException(nameof(room));

            if (room.IsUnderMaintenance)
                throw new InvalidOperationException("Cannot create a reservation for a room currently under maintenance.");

            ReservationId = reservationId;
            CheckInDate = checkInDate;
            CheckOutDate = checkOutDate;
            Room = room;
            Status = ReservationStatus.Pending;
        }

        // Status Transition Methods
        public void Confirm()
        {
            if (Status != ReservationStatus.Pending)
                throw new InvalidOperationException($"Cannot confirm reservation from status '{Status}'. Must be Pending.");

            Status = ReservationStatus.Confirmed;
        }

        public void CheckIn()
        {
            if (Status != ReservationStatus.Confirmed)
                throw new InvalidOperationException($"Cannot check in. Reservation status is '{Status}', but must be Confirmed.");

            Status = ReservationStatus.CheckedIn;
        }

        public void CheckOut()
        {
            if (Status != ReservationStatus.CheckedIn)
                throw new InvalidOperationException($"Cannot check out unless status is CheckedIn. Current status: '{Status}'.");

            Status = ReservationStatus.CheckedOut;
        }

        public void Cancel()
        {
            if (Status != ReservationStatus.Pending && Status != ReservationStatus.Confirmed)
                throw new InvalidOperationException($"Cannot cancel reservation in '{Status}' state. Only Pending or Confirmed reservations can be cancelled.");

            Status = ReservationStatus.Cancelled;
        }
    }
}